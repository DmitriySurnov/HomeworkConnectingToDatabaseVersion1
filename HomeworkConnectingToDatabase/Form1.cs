using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

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

        private string GettingDesiredRequest(int numberRequest, string value1 = "", int value2 = -1)
        {
            switch (numberRequest)
            {
                case 0: return @"SELECT Characters.Name, CharactersClass.Name 
                                 FROM `Characters`,`CharactersClass` 
                                 WHERE Characters.CharactersClassId = CharactersClass.ID;";

                case 1: return @"SELECT Name FROM `CharactersClass`;";
                case 2: return $@"SELECT Id FROM `CharactersClass` 
                                  WHERE Name = ""{value1}"";";
                case 3: return $@"INSERT INTO `CharactersClass` (`Name`) 
                                        VALUES ('{value1}');";
                case 4: return $@"INSERT INTO `Characters` (`Name`,`CharactersClassId`) 
                                        VALUES ('{value1}',{value2});";
                case 5: return $@"SELECT Name FROM `Characters` 
                                    WHERE Name = ""{value1}""";
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
                ErrorMessages("Неудолось подключиться к базе данных");
                throw new Exception("Неудолось подключиться к базе данных");
            }
        }

        private int ReceiveIdClass(string nameClass)
        {
            _reader = SendRequestWithResponse(GettingDesiredRequest(2, nameClass));
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
            SendingRequest(GettingDesiredRequest(numberRequest: 3, value1: nameClass));
        }

        private void AddDataTheTableCharacters(string playerName, int idClass)
        {
            SendingRequest(GettingDesiredRequest(4, playerName, idClass));
        }

        private static void ErrorMessages(string textMessages)
        {
            MessageBox.Show(
                   textMessages,
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
        }

        private static void InformationMessages()
        {
            MessageBox.Show(
                   "Новый игрок был успешно добавлен",
                   "Оповещение",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
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

        private bool IsUniquePlayerName(string namePlayer)
        {
            _reader = SendRequestWithResponse(GettingDesiredRequest(5, namePlayer));
            while (_reader.Read())
            {
                ErrorMessages($"Игрок с именем {namePlayer} существует");
                RestartDataBase();
                return false;
            }
            RestartDataBase();
            return true;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            SwitchEnabledButtons();
            if (!ValedateTextBoxEmpty(textBoxPlayerName) ||
                !ValedateComboBoxEmpty(comboBoxPlayerClass))
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
                if (IsUniquePlayerName(textBoxPlayerName.Text))
                {
                    int idClass = ReceiveIdClass(comboBoxPlayerClass.Text);
                    RestartDataBase();
                    AddDataTheTableCharacters(textBoxPlayerName.Text, idClass);
                    HideAll();
                    SwitchEnabledButton(buttonAddPlayer);
                    InformationMessages();
                }
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