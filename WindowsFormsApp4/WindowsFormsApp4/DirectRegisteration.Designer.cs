namespace WindowsFormsApp4
{
    partial class DirectRegisteration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.search = new System.Windows.Forms.Label();
            this.searchTxtBox = new System.Windows.Forms.TextBox();
            this.dgvTestPrice = new System.Windows.Forms.DataGridView();
            this.Test = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddcomboBox = new System.Windows.Forms.ComboBox();
            this.totaltxt = new System.Windows.Forms.TextBox();
            this.total = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.delete = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewTXT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DatetextBox = new System.Windows.Forms.TextBox();
            this.unitagecom = new System.Windows.Forms.ComboBox();
            this.phonetxt = new System.Windows.Forms.TextBox();
            this.idtxt = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.RefBy = new System.Windows.Forms.Label();
            this.refcom = new System.Windows.Forms.ComboBox();
            this.phone = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.agetxt = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.Label();
            this.gender = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.gendercom = new System.Windows.Forms.ComboBox();
            this.TitleCom = new System.Windows.Forms.ComboBox();
            this.AddToListbutton = new System.Windows.Forms.Button();
            this.Addbtn = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestPrice)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.ForeColor = System.Drawing.Color.Black;
            this.search.Location = new System.Drawing.Point(11, 134);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(154, 29);
            this.search.TabIndex = 0;
            this.search.Text = "Search Test";
            // 
            // searchTxtBox
            // 
            this.searchTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTxtBox.Location = new System.Drawing.Point(241, 133);
            this.searchTxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchTxtBox.Name = "searchTxtBox";
            this.searchTxtBox.Size = new System.Drawing.Size(281, 30);
            this.searchTxtBox.TabIndex = 1;
            this.searchTxtBox.TextChanged += new System.EventHandler(this.searchTxtBox_TextChanged);
            // 
            // dgvTestPrice
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTestPrice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTestPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Test,
            this.Price});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTestPrice.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvTestPrice.Location = new System.Drawing.Point(661, 191);
            this.dgvTestPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTestPrice.Name = "dgvTestPrice";
            this.dgvTestPrice.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTestPrice.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTestPrice.RowTemplate.Height = 24;
            this.dgvTestPrice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTestPrice.Size = new System.Drawing.Size(691, 404);
            this.dgvTestPrice.TabIndex = 2;
            // 
            // Test
            // 
            this.Test.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Test.HeaderText = "Test";
            this.Test.MinimumWidth = 6;
            this.Test.Name = "Test";
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            // 
            // AddcomboBox
            // 
            this.AddcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddcomboBox.FormattingEnabled = true;
            this.AddcomboBox.Location = new System.Drawing.Point(241, 28);
            this.AddcomboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddcomboBox.Name = "AddcomboBox";
            this.AddcomboBox.Size = new System.Drawing.Size(281, 33);
            this.AddcomboBox.TabIndex = 22;
            this.AddcomboBox.SelectedIndexChanged += new System.EventHandler(this.AddcomboBox_SelectedIndexChanged);
            // 
            // totaltxt
            // 
            this.totaltxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaltxt.Location = new System.Drawing.Point(267, 39);
            this.totaltxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.totaltxt.Multiline = true;
            this.totaltxt.Name = "totaltxt";
            this.totaltxt.Size = new System.Drawing.Size(159, 34);
            this.totaltxt.TabIndex = 24;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.ForeColor = System.Drawing.Color.Black;
            this.total.Location = new System.Drawing.Point(85, 39);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(161, 32);
            this.total.TabIndex = 25;
            this.total.Text = "Total Price";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(619, 34);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 47);
            this.button2.TabIndex = 26;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(11, 191);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(509, 379);
            this.checkedListBox1.TabIndex = 27;
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.DarkBlue;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.Color.White;
            this.delete.Location = new System.Drawing.Point(415, 34);
            this.delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(181, 47);
            this.delete.TabIndex = 28;
            this.delete.Text = "DeleteTest";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(3, 34);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 47);
            this.button3.TabIndex = 35;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.NewTXT);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.delete);
            this.panel1.Location = new System.Drawing.Point(565, 698);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 91);
            this.panel1.TabIndex = 37;
            // 
            // NewTXT
            // 
            this.NewTXT.BackColor = System.Drawing.Color.DarkBlue;
            this.NewTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewTXT.ForeColor = System.Drawing.Color.White;
            this.NewTXT.Location = new System.Drawing.Point(3, 34);
            this.NewTXT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewTXT.Name = "NewTXT";
            this.NewTXT.Size = new System.Drawing.Size(181, 47);
            this.NewTXT.TabIndex = 41;
            this.NewTXT.Text = "New";
            this.NewTXT.UseVisualStyleBackColor = false;
            this.NewTXT.Click += new System.EventHandler(this.New_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(213, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 47);
            this.button1.TabIndex = 40;
            this.button1.Text = "Enter Results";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.DatetextBox);
            this.groupBox1.Controls.Add(this.unitagecom);
            this.groupBox1.Controls.Add(this.phonetxt);
            this.groupBox1.Controls.Add(this.idtxt);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Controls.Add(this.RefBy);
            this.groupBox1.Controls.Add(this.refcom);
            this.groupBox1.Controls.Add(this.phone);
            this.groupBox1.Controls.Add(this.Date);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.agetxt);
            this.groupBox1.Controls.Add(this.age);
            this.groupBox1.Controls.Add(this.gender);
            this.groupBox1.Controls.Add(this.title);
            this.groupBox1.Controls.Add(this.nametxt);
            this.groupBox1.Controls.Add(this.gendercom);
            this.groupBox1.Controls.Add(this.TitleCom);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Location = new System.Drawing.Point(661, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(691, 143);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // DatetextBox
            // 
            this.DatetextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.DatetextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.DatetextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatetextBox.Location = new System.Drawing.Point(675, 101);
            this.DatetextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DatetextBox.Name = "DatetextBox";
            this.DatetextBox.ReadOnly = true;
            this.DatetextBox.Size = new System.Drawing.Size(205, 28);
            this.DatetextBox.TabIndex = 29;
            this.DatetextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // unitagecom
            // 
            this.unitagecom.Cursor = System.Windows.Forms.Cursors.Default;
            this.unitagecom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitagecom.FormattingEnabled = true;
            this.unitagecom.Items.AddRange(new object[] {
            "Days",
            "months",
            "Years"});
            this.unitagecom.Location = new System.Drawing.Point(787, 42);
            this.unitagecom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.unitagecom.Name = "unitagecom";
            this.unitagecom.Size = new System.Drawing.Size(93, 30);
            this.unitagecom.TabIndex = 28;
            // 
            // phonetxt
            // 
            this.phonetxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.phonetxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.phonetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonetxt.Location = new System.Drawing.Point(455, 101);
            this.phonetxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phonetxt.MaxLength = 11;
            this.phonetxt.Name = "phonetxt";
            this.phonetxt.Size = new System.Drawing.Size(205, 28);
            this.phonetxt.TabIndex = 26;
            // 
            // idtxt
            // 
            this.idtxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.idtxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.idtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idtxt.Location = new System.Drawing.Point(5, 101);
            this.idtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idtxt.Name = "idtxt";
            this.idtxt.ReadOnly = true;
            this.idtxt.Size = new System.Drawing.Size(205, 30);
            this.idtxt.TabIndex = 25;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.ForeColor = System.Drawing.Color.Black;
            this.ID.Location = new System.Drawing.Point(5, 75);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(33, 25);
            this.ID.TabIndex = 20;
            this.ID.Text = "ID";
            this.ID.UseWaitCursor = true;
            // 
            // RefBy
            // 
            this.RefBy.AutoSize = true;
            this.RefBy.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.RefBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefBy.ForeColor = System.Drawing.Color.Black;
            this.RefBy.Location = new System.Drawing.Point(227, 73);
            this.RefBy.Name = "RefBy";
            this.RefBy.Size = new System.Drawing.Size(81, 25);
            this.RefBy.TabIndex = 21;
            this.RefBy.Text = "Ref. By";
            this.RefBy.UseWaitCursor = true;
            // 
            // refcom
            // 
            this.refcom.Cursor = System.Windows.Forms.Cursors.Default;
            this.refcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refcom.FormattingEnabled = true;
            this.refcom.Location = new System.Drawing.Point(224, 101);
            this.refcom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refcom.Name = "refcom";
            this.refcom.Size = new System.Drawing.Size(215, 30);
            this.refcom.TabIndex = 24;
            this.refcom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.refcom_KeyDown);
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone.ForeColor = System.Drawing.Color.Black;
            this.phone.Location = new System.Drawing.Point(451, 73);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(74, 25);
            this.phone.TabIndex = 22;
            this.phone.Text = "Phone";
            this.phone.UseWaitCursor = true;
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.ForeColor = System.Drawing.Color.Black;
            this.Date.Location = new System.Drawing.Point(669, 75);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(57, 25);
            this.Date.TabIndex = 23;
            this.Date.Text = "Date";
            this.Date.UseWaitCursor = true;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.Black;
            this.name.Location = new System.Drawing.Point(227, 14);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(68, 25);
            this.name.TabIndex = 3;
            this.name.Text = "Name";
            this.name.UseWaitCursor = true;
            // 
            // agetxt
            // 
            this.agetxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.agetxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.agetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agetxt.Location = new System.Drawing.Point(675, 42);
            this.agetxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.agetxt.Multiline = true;
            this.agetxt.Name = "agetxt";
            this.agetxt.Size = new System.Drawing.Size(105, 30);
            this.agetxt.TabIndex = 19;
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.age.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.age.ForeColor = System.Drawing.Color.Black;
            this.age.Location = new System.Drawing.Point(675, 14);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(51, 25);
            this.age.TabIndex = 4;
            this.age.Text = "Age";
            this.age.UseWaitCursor = true;
            // 
            // gender
            // 
            this.gender.AutoSize = true;
            this.gender.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gender.ForeColor = System.Drawing.Color.Black;
            this.gender.Location = new System.Drawing.Point(451, 14);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(83, 25);
            this.gender.TabIndex = 5;
            this.gender.Text = "Gender";
            this.gender.UseWaitCursor = true;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Black;
            this.title.Location = new System.Drawing.Point(5, 14);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(54, 25);
            this.title.TabIndex = 6;
            this.title.Text = "Title";
            this.title.UseWaitCursor = true;
            // 
            // nametxt
            // 
            this.nametxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.nametxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.nametxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nametxt.Location = new System.Drawing.Point(224, 42);
            this.nametxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(215, 28);
            this.nametxt.TabIndex = 15;
            // 
            // gendercom
            // 
            this.gendercom.Cursor = System.Windows.Forms.Cursors.Default;
            this.gendercom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gendercom.FormattingEnabled = true;
            this.gendercom.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.gendercom.Location = new System.Drawing.Point(455, 42);
            this.gendercom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gendercom.Name = "gendercom";
            this.gendercom.Size = new System.Drawing.Size(205, 30);
            this.gendercom.TabIndex = 12;
            // 
            // TitleCom
            // 
            this.TitleCom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.TitleCom.Cursor = System.Windows.Forms.Cursors.Default;
            this.TitleCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleCom.FormattingEnabled = true;
            this.TitleCom.Items.AddRange(new object[] {
            "مهندس ",
            "مهندسه",
            "الحاج",
            "الحاجه",
            " طفل ",
            "طفلة",
            " الآنسة",
            " مدام",
            " السيد ",
            " السيدة ",
            " الاستاذ ",
            "الاستاذة",
            "دكتور",
            "دكتوة"});
            this.TitleCom.Location = new System.Drawing.Point(5, 42);
            this.TitleCom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TitleCom.Name = "TitleCom";
            this.TitleCom.Size = new System.Drawing.Size(205, 30);
            this.TitleCom.TabIndex = 11;
            // 
            // AddToListbutton
            // 
            this.AddToListbutton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.AddToListbutton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.AddToListbutton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddToListbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToListbutton.ForeColor = System.Drawing.Color.White;
            this.AddToListbutton.Location = new System.Drawing.Point(541, 191);
            this.AddToListbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddToListbutton.Name = "AddToListbutton";
            this.AddToListbutton.Size = new System.Drawing.Size(103, 86);
            this.AddToListbutton.TabIndex = 39;
            this.AddToListbutton.Text = "=>";
            this.AddToListbutton.UseVisualStyleBackColor = false;
            this.AddToListbutton.Click += new System.EventHandler(this.AddToListbutton_Click);
            // 
            // Addbtn
            // 
            this.Addbtn.AutoSize = true;
            this.Addbtn.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addbtn.ForeColor = System.Drawing.Color.Black;
            this.Addbtn.Location = new System.Drawing.Point(11, 32);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(211, 29);
            this.Addbtn.TabIndex = 30;
            this.Addbtn.Text = "Choose Package";
            this.Addbtn.UseWaitCursor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(11, 698);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 91);
            this.panel2.TabIndex = 42;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.total);
            this.panel3.Controls.Add(this.totaltxt);
            this.panel3.Location = new System.Drawing.Point(927, 601);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(437, 91);
            this.panel3.TabIndex = 43;
            // 
            // DirectRegisteration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(1419, 791);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.AddToListbutton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddcomboBox);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dgvTestPrice);
            this.Controls.Add(this.searchTxtBox);
            this.Controls.Add(this.search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DirectRegisteration";
            this.Text = "DirectRegisteration";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestPrice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label search;
        private System.Windows.Forms.TextBox searchTxtBox;
        private System.Windows.Forms.DataGridView dgvTestPrice;
        private System.Windows.Forms.ComboBox AddcomboBox;
        private System.Windows.Forms.TextBox totaltxt;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Test;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox unitagecom;
        private System.Windows.Forms.TextBox phonetxt;
        private System.Windows.Forms.TextBox idtxt;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label RefBy;
        private System.Windows.Forms.ComboBox refcom;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox agetxt;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.Label gender;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.ComboBox gendercom;
        private System.Windows.Forms.ComboBox TitleCom;
        private System.Windows.Forms.Button AddToListbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox DatetextBox;
        private System.Windows.Forms.Button NewTXT;
        private System.Windows.Forms.Label Addbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}