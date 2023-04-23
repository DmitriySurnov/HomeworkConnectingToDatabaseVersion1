using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private MySqlConnection _connection = null;

        private MySqlDataReader _reader = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void SwitchEnabledButton(Button button)
        {
            button.Enabled = !button.Enabled;
        }

        private void SwitchEnabledButtons()
        {
            buttonAdd.Enabled = !buttonAdd.Enabled;
            buttonCancel.Enabled = !buttonCancel.Enabled;
        }

        private void ConnectToDataBase()
        {
            MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder()
            {
                Server = "db4free.net",
                Database = "training_base",
                UserID = "dmitriy",
                Password = "qwertyasdfgh",
                OldGuids = true
            };
            try
            {
                _connection = new MySqlConnection(mySqlConnectionStringBuilder.ToString());
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void HideAll()
        {
            listView_Result.Visible = false;
            panel_add.Visible = false;
        }

        private void ShowPartForm(int numberPartForm)
        {
            if (numberPartForm == 0)
            {
                listView_Result.Items.Clear();
                listView_Result.Visible = true;
                buttonAddPlayer.Enabled = true;
            }
            else if (numberPartForm == 1)
            {
                textBoxPlayerName.Text = "";
                comboBoxPlayerClass.Items.Clear();
                comboBoxPlayerClass.Text = "";
                panel_add.Visible = true;
            }
        }

        private void CloseConnectToDataBase()
        {
            _connection?.Close();
            _reader?.Close();
        }

        private MySqlDataReader SendRequestWithResponse(string sqlCommand)
        {
            MySqlCommand cmd = new MySqlCommand(sqlCommand, _connection);
            return cmd.ExecuteReader();
        }

        private void SendingRequest(string sqlCommand)
        {
            MySqlCommand cmd = new MySqlCommand(sqlCommand, _connection);
            cmd.ExecuteNonQuery();
        }

        private string GettingDesiredRequest(int numberRequest)
        {
            switch (numberRequest)
            {
                case 0: return @"SELECT Name AS ""Person Name"", 
                    ClassName AS ""Class Name"" FROM `Characters`, 
                    `CharactersClass` WHERE Characters.CharacterClassID = CharactersClass.ID;";

                case 1: return @"SELECT ClassName FROM `CharactersClass`;";

                default: return "";
            }
        }

        private void FillingListView()
        {
            while (_reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem(_reader.GetString(0));
                listViewItem.SubItems.Add(_reader.GetString(1));
                listView_Result.Items.Add(listViewItem);
            }
        }

        private void FillingComboBox()
        {
            while (_reader.Read())
            {
                comboBoxPlayerClass.Items.Add(_reader.GetString(0));
            }
        }

        private void Button_Select_Click(object sender, EventArgs e)
        {
            SwitchEnabledButton(button_Select);
            ConnectToDataBase();
            if (_connection == null)
            {
                SwitchEnabledButton(button_Select);
                return;
            }
            HideAll();
            ShowPartForm(numberPartForm: 0);
            try
            {
                _reader = SendRequestWithResponse(GettingDesiredRequest(numberRequest: 0));
                FillingListView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CloseConnectToDataBase();
            }
            SwitchEnabledButton(button_Select);
        }

        private void ButtonAddPlayer_Click(object sender, EventArgs e)
        {
            SwitchEnabledButton(buttonAddPlayer);
            ConnectToDataBase();
            if (_connection == null)
            {
                buttonAddPlayer.Enabled = true;
                return;
            }
            HideAll();
            ShowPartForm(numberPartForm: 1);
            try
            {
                _reader = SendRequestWithResponse(GettingDesiredRequest(numberRequest: 1));

                FillingComboBox();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                CloseConnectToDataBase();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            HideAll();
            SwitchEnabledButton(buttonAddPlayer);
        }

        private void RestartDataBase()
        {
            CloseConnectToDataBase();
            ConnectToDataBase();
            if (_connection == null)
            {
                throw new Exception("Неудолось подключиться к базе данных");
            }
        }

        private int ReceiveIdClass(string nameClass)
        {
            string sqlCommand = $@"SELECT Id FROM `CharactersClass` 
                                WHERE ClassName = ""{nameClass}"";";
            _reader = SendRequestWithResponse(sqlCommand);
            int idClass = -1;
            while (_reader.Read())
            {
                idClass = _reader.GetInt32("ID");
            }
            if (idClass == -1)
            {
                RestartDataBase();
                AddDataTheTableCharactersClass(nameClass);
                return ReceiveIdClass(nameClass);
            }
            else
                return idClass;
        }

        private void AddDataTheTableCharactersClass(string nameClass)
        {
            string sqlCommand = $@"INSERT INTO `CharactersClass` (`ClassName`) 
                                        VALUES ('{nameClass}');";
            SendingRequest(sqlCommand);
        }

        private void AddDataTheTableCharacters(string playerName, int idClass)
        {
            string sqlCommand = $@"INSERT INTO `Characters` (`Name`,`CharacterClassId`) 
                                        VALUES ('{playerName}',{idClass});";
            SendingRequest(sqlCommand);
        }

        private static void ErrorMessages(string textMessages)
        {
            MessageBox.Show(
                   textMessages,
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
        }

        private bool ValedateTextBoxEmpty(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                ErrorMessages("Вы не заполнили поле ' Имя игрока '");
                return false;
            }
            else
                return true;
        }
        private bool ValedateComboBoxEmpty(ComboBox comboBox)
        {
            if (string.IsNullOrEmpty(comboBox.Text))
            {
                ErrorMessages("Вы не выбран класс игрока ");
                return false;
            }
            else
                return true;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            SwitchEnabledButtons();
            if (ValedateTextBoxEmpty(textBoxPlayerName) ||
                ValedateComboBoxEmpty(comboBoxPlayerClass))
            {
                SwitchEnabledButtons();
                return;
            }
            ConnectToDataBase();
            if (_connection == null)
            {
                SwitchEnabledButtons();
                return;
            }
            try
            {
                int idClass = ReceiveIdClass(comboBoxPlayerClass.Text);
                RestartDataBase();
                AddDataTheTableCharacters(textBoxPlayerName.Text, idClass);
                HideAll();
                SwitchEnabledButton(buttonAddPlayer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            finally
            {
                CloseConnectToDataBase();
            }
            SwitchEnabledButtons();
        }
    }
}