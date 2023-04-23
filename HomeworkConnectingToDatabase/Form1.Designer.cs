namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_Result = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Class = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_Select = new System.Windows.Forms.Button();
            this.buttonAddPlayer = new System.Windows.Forms.Button();
            this.panel_add = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxPlayerClass = new System.Windows.Forms.ComboBox();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.labelPlayerClass = new System.Windows.Forms.Label();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.panel_add.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_Result
            // 
            this.listView_Result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.Class});
            this.listView_Result.HideSelection = false;
            this.listView_Result.Location = new System.Drawing.Point(6, 130);
            this.listView_Result.Name = "listView_Result";
            this.listView_Result.Size = new System.Drawing.Size(537, 265);
            this.listView_Result.TabIndex = 0;
            this.listView_Result.UseCompatibleStateImageBehavior = false;
            this.listView_Result.View = System.Windows.Forms.View.Details;
            this.listView_Result.Visible = false;
            // 
            // name
            // 
            this.name.Text = "Имя игрока";
            this.name.Width = 100;
            // 
            // Class
            // 
            this.Class.Text = "Класс игрока";
            this.Class.Width = 100;
            // 
            // button_Select
            // 
            this.button_Select.Location = new System.Drawing.Point(12, 13);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(273, 89);
            this.button_Select.TabIndex = 1;
            this.button_Select.Text = "Вывести информацию  об всех игроках";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.Button_Select_Click);
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.Location = new System.Drawing.Point(305, 13);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(238, 89);
            this.buttonAddPlayer.TabIndex = 2;
            this.buttonAddPlayer.Text = "Добавить игрока";
            this.buttonAddPlayer.UseVisualStyleBackColor = true;
            this.buttonAddPlayer.Click += new System.EventHandler(this.ButtonAddPlayer_Click);
            // 
            // panel_add
            // 
            this.panel_add.Controls.Add(this.buttonCancel);
            this.panel_add.Controls.Add(this.buttonAdd);
            this.panel_add.Controls.Add(this.comboBoxPlayerClass);
            this.panel_add.Controls.Add(this.textBoxPlayerName);
            this.panel_add.Controls.Add(this.labelPlayerClass);
            this.panel_add.Controls.Add(this.labelPlayerName);
            this.panel_add.Location = new System.Drawing.Point(6, 130);
            this.panel_add.Name = "panel_add";
            this.panel_add.Size = new System.Drawing.Size(537, 329);
            this.panel_add.TabIndex = 3;
            this.panel_add.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(292, 179);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(210, 75);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(29, 179);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(210, 75);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // comboBoxPlayerClass
            // 
            this.comboBoxPlayerClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPlayerClass.FormattingEnabled = true;
            this.comboBoxPlayerClass.Location = new System.Drawing.Point(292, 104);
            this.comboBoxPlayerClass.Name = "comboBoxPlayerClass";
            this.comboBoxPlayerClass.Size = new System.Drawing.Size(238, 50);
            this.comboBoxPlayerClass.TabIndex = 3;
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPlayerName.Location = new System.Drawing.Point(292, 32);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(238, 49);
            this.textBoxPlayerName.TabIndex = 2;
            // 
            // labelPlayerClass
            // 
            this.labelPlayerClass.AutoSize = true;
            this.labelPlayerClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlayerClass.Location = new System.Drawing.Point(22, 104);
            this.labelPlayerClass.Name = "labelPlayerClass";
            this.labelPlayerClass.Size = new System.Drawing.Size(250, 42);
            this.labelPlayerClass.TabIndex = 1;
            this.labelPlayerClass.Text = "Класс игрока";
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlayerName.Location = new System.Drawing.Point(22, 32);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(250, 54);
            this.labelPlayerName.TabIndex = 0;
            this.labelPlayerName.Text = "Имя игрока";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 484);
            this.Controls.Add(this.buttonAddPlayer);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.listView_Result);
            this.Controls.Add(this.panel_add);
            this.Name = "Form1";
            this.Text = "Работа с базой данных";
            this.panel_add.ResumeLayout(false);
            this.panel_add.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Result;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader Class;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.Button buttonAddPlayer;
        private System.Windows.Forms.Panel panel_add;
        private System.Windows.Forms.Label labelPlayerClass;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.ComboBox comboBoxPlayerClass;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
    }
}

