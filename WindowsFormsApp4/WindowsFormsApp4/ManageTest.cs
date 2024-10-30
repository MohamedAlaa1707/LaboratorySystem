using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class ManageTest : Form
    {
        settings _ManageTest;
        SqlConnection con;
        private readonly string connectionstring = "server=`.;database=LaboratorySystem;integrated security=true";

      
        public ManageTest(settings form1)
        {
            _ManageTest = form1;
            InitializeComponent();
            GlobalKeyHandler.RegisterGlobalShortcuts(this);

            // ربط الأحداث لجميع صناديق النصوص
            textBox3.TextChanged += new EventHandler(textBox3_TextChanged);
            AddNewGroup.TextChanged += new EventHandler(AddNewGroup_TextChanged);
            textBox4.TextChanged += new EventHandler(textBox4_TextChanged);
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);
            textBox3.KeyPress += new KeyPressEventHandler(textBox_EnglishOnly_KeyPress);
            AddNewGroup.KeyPress += new KeyPressEventHandler(textBox_EnglishOnly_KeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(textBox_EnglishOnly_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_EnglishOnly_KeyPress);
        }

        private void ManageTest_Load(object sender, EventArgs e)
        {
            //// الحصول على أبعاد الشاشة
            //int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            //// تحديد المسافة الفاصلة بين البانيلين
            //int spacing = 20; // يمكنك تغيير هذه القيمة حسب الحاجة

            //// ضبط حجم وموقع البانيل الأول
            //panel1.Size = new Size(screenWidth, (screenHeight - spacing) / 2);
            //panel1.Location = new Point(0, 0); // في الجزء العلوي من الشاشة

            //// ضبط حجم وموقع البانيل الثاني
            //panel2.Size = new Size(screenWidth, (screenHeight - spacing) / 2);
            //panel2.Location = new Point(0, panel1.Bottom + spacing);

            // الاتصال بقاعدة البيانات وتحميل المجموعات في comboBox1 و comboBox4
            LoadGroups();
            FillcomboBox2ComboBox();


           


           
            PopulateComboBox3();
            PopulateComboBox6();
            PopulateComboBox5();
            PopulateComboBox7();
            PopulateComboBox8();
            PopulateComboBox9();
            }


        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateComboBox7();
        }

        private void PopulateComboBox3()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "SELECT GroupName FROM Main_Test_Group";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                while (reader.Read())
                {
                    string groupName = reader["GroupName"].ToString();
                    comboBox3.Items.Add(groupName);
                    autoCompleteCollection.Add(groupName);
                }
                reader.Close();

                comboBox3.AutoCompleteCustomSource = autoCompleteCollection;
                comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void PopulateComboBox6()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "SELECT SubTestName FROM Sub_Test";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                while (reader.Read())
                {
                    string subTestName = reader["SubTestName"].ToString();
                    comboBox6.Items.Add(subTestName);
                    autoCompleteCollection.Add(subTestName);
                }
                reader.Close();

                comboBox6.AutoCompleteCustomSource = autoCompleteCollection;
                comboBox6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }





        private void PopulateComboBox5()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "SELECT GroupName FROM Main_Test_Group";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                while (reader.Read())
                {
                    string groupName = reader["GroupName"].ToString();
                    comboBox5.Items.Add(groupName);
                    autoCompleteCollection.Add(groupName);
                }
                reader.Close();

                comboBox5.AutoCompleteCustomSource = autoCompleteCollection;
                comboBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void PopulateComboBox7()
        {
            comboBox7.Items.Clear();

            string selectedGroupName = comboBox5.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedGroupName))
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    string query = @"
            SELECT SubTestName 
            FROM Sub_Test 
            WHERE GroupID = (
                SELECT GroupID 
                FROM Main_Test_Group 
                WHERE GroupName = @GroupName
            )";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@GroupName", selectedGroupName);
                    SqlDataReader reader = cmd.ExecuteReader();

                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();

                    try
                    {
                        while (reader.Read())
                        {
                            string subTestName = reader["SubTestName"].ToString();
                            comboBox7.Items.Add(subTestName);
                            autoCompleteCollection.Add(subTestName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading data: " + ex.Message);
                    }
                    finally
                    {
                        reader.Close();
                    }

                    comboBox7.AutoCompleteCustomSource = autoCompleteCollection;
                    comboBox7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
        }



        private void PopulateComboBox8()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "SELECT GroupName FROM Main_Test_Group";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                comboBox8.Items.Clear(); // Clear existing items before populating

                while (reader.Read())
                {
                    string groupName = reader["GroupName"].ToString();
                    comboBox8.Items.Add(groupName);
                }
                reader.Close();

                // Set AutoComplete settings
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                foreach (var item in comboBox8.Items)
                {
                    autoCompleteCollection.Add(item.ToString());
                }
                comboBox8.AutoCompleteCustomSource = autoCompleteCollection;
                comboBox8.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox8.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateComboBox9();
        }

        private void PopulateComboBox9()
        {
            comboBox9.Items.Clear(); // Clear existing items before populating

            string selectedGroupName = comboBox8.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedGroupName))
                return;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = @"
            SELECT SubTestName 
            FROM Sub_Test 
            WHERE GroupID = (
                SELECT GroupID 
                FROM Main_Test_Group 
                WHERE GroupName = @GroupName
            )";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@GroupName", selectedGroupName);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string subTestName = reader["SubTestName"].ToString();
                    comboBox9.Items.Add(subTestName);
                }
                reader.Close();

                // Set AutoComplete settings
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                foreach (var item in comboBox9.Items)
                {
                    autoCompleteCollection.Add(item.ToString());
                }
                comboBox9.AutoCompleteCustomSource = autoCompleteCollection;
                comboBox9.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox9.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }










        private void LoadGroups()
        {
            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();

                string query = "SELECT GroupName FROM Main_Test_Group";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                comboBox1.Items.Clear();
                comboBox4.Items.Clear(); // إضافة هذه السطر لتحميل أسماء المجموعات في comboBox4
                while (reader.Read())
                {
                    string groupName = reader["GroupName"].ToString();
                    comboBox1.Items.Add(groupName);
                    comboBox4.Items.Add(groupName); // تحميل أسماء المجموعات في comboBox4
                    comboBox10.Items.Add(groupName);
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading groups: " + ex.Message);
            }
        }

        private bool IsEnglishText(string text)
        {
            // تحقق من أن النص يحتوي فقط على أحرف إنجليزية، أرقام، ومسافات باستخدام التعبيرات المنتظمة
            string pattern =@"^[a-zA-Z\s]*$";
            return Regex.IsMatch(text, pattern);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _ManageTest.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newGroupName = textBox3.Text.Trim(); // افترض أن textBox3 يحتوي على اسم الجروب الجديد

            // التحقق من النص باللغة الإنجليزية
            if (!IsEnglishText(newGroupName))
            {
                MessageBox.Show("Please enter the group name in English only.");
                return;
            }

            // التحقق من أن النص غير فارغ
            if (string.IsNullOrEmpty(newGroupName))
            {
                MessageBox.Show("Group name cannot be empty.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();

                    // التحقق مما إذا كان الجروب موجودًا بالفعل
                    string checkQuery = "SELECT COUNT(*) FROM Main_Test_Group WHERE GroupName = @GroupName";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@GroupName", newGroupName);
                    int groupCount = (int)checkCmd.ExecuteScalar();

                    if (groupCount > 0)
                    {
                        MessageBox.Show("Group already exists.");
                    }
                    else
                    {
                        // إضافة الجروب الجديد
                        string insertQuery = "INSERT INTO Main_Test_Group (GroupName) VALUES (@GroupName)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@GroupName", newGroupName);
                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Group added successfully.");
                        LoadGroups(); // تحديث قائمة المجموعات
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //private bool IsEnglishText(string text)
        //{
        //    // التعبير المنتظم للتحقق من النصوص باللغة الإنجليزية
        //    string pattern = @"^[a-zA-Z\s]*$";
        //    Regex regex = new Regex(pattern);
        //    return regex.IsMatch(text);
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedGroupName = comboBox1.SelectedItem?.ToString();
            string newGroupName = AddNewGroup.Text.Trim();

            if (string.IsNullOrEmpty(selectedGroupName))
            {
                MessageBox.Show("Please select a group to update.");
                return;
            }

            if (string.IsNullOrEmpty(newGroupName))
            {
                MessageBox.Show("Please enter the new group name.");
                return;
            }

            if (!IsEnglishText(newGroupName))
            {
                MessageBox.Show("Please enter the new group name in English only.");
                return;
            }

            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();

                // التحقق مما إذا كان الجروب الجديد موجودًا بالفعل
                string checkQuery = "SELECT COUNT(*) FROM Main_Test_Group WHERE GroupName = @NewGroupName";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@NewGroupName", newGroupName);
                int groupCount = (int)checkCmd.ExecuteScalar();

                if (groupCount > 0)
                {
                    MessageBox.Show("New group name already exists.");
                }
                else
                {
                    // تحديث اسم الجروب
                    string updateQuery = "UPDATE Main_Test_Group SET GroupName = @NewGroupName WHERE GroupName = @OldGroupName";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@NewGroupName", newGroupName);
                    updateCmd.Parameters.AddWithValue("@OldGroupName", selectedGroupName);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Group name updated successfully.");
                    LoadGroups(); // تحديث قائمة المجموعات
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating group name: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string selectedGroupName = comboBox4.SelectedItem?.ToString();
            string subTestName = textBox4.Text.Trim();
            string priceText = textBox2.Text.Trim();
            string unitOfMeasurement = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(selectedGroupName))
            {
                MessageBox.Show("Please select a group to add the test to.");
                return;
            }

            if (string.IsNullOrEmpty(subTestName))
            {
                MessageBox.Show("Please enter the test name.");
                return;
            }

            if (!IsEnglishText(subTestName))
            {
                MessageBox.Show("Please enter the test name in English only.");
                return;
            }

            if (string.IsNullOrEmpty(priceText) || !decimal.TryParse(priceText, out decimal testPrice) || testPrice < 10)
            {
                MessageBox.Show("Please enter a valid test price (numeric value greater than or equal to 10).");
                return;
            }

            if (string.IsNullOrEmpty(unitOfMeasurement) || !IsValidUnit(unitOfMeasurement))
            {
                MessageBox.Show("Please enter a valid unit of measurement (must include English letters or symbols and cannot be only numbers).");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();

                    // التحقق مما إذا كان الاختبار موجودًا بالفعل في أي مجموعة
                    string checkDuplicateQuery = @"
        SELECT GroupName 
        FROM Sub_Test 
        INNER JOIN Main_Test_Group ON Sub_Test.GroupID = Main_Test_Group.GroupID
        WHERE SubTestName = @TestName";
                    SqlCommand checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, con);
                    checkDuplicateCmd.Parameters.AddWithValue("@TestName", subTestName);
                    object existingGroup = checkDuplicateCmd.ExecuteScalar();

                    if (existingGroup != null)
                    {
                        if (existingGroup.ToString() != selectedGroupName)
                        {
                            MessageBox.Show($"The test '{subTestName}' already exists in the group '{existingGroup.ToString()}'.");
                            return;
                        }
                    }

                    // التحقق مما إذا كان الاختبار موجودًا بالفعل في المجموعة المحددة
                    string checkQuery = @"
        SELECT Price 
        FROM Sub_Test 
        WHERE SubTestName = @TestName AND GroupID = (
            SELECT GroupID 
            FROM Main_Test_Group 
            WHERE GroupName = @GroupName
        )";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@TestName", subTestName);
                    checkCmd.Parameters.AddWithValue("@GroupName", selectedGroupName);
                    object existingPrice = checkCmd.ExecuteScalar();

                    if (existingPrice != null)
                    {
                        MessageBox.Show("The test with the same name already exists in the selected group.");
                    }
                    else
                    {
                        // إضافة الاختبار الجديد
                        string insertQuery = @"
            INSERT INTO Sub_Test (SubTestName, Price, GroupID, TestUnit) 
            VALUES (@TestName, @TestPrice, (
                SELECT GroupID 
                FROM Main_Test_Group 
                WHERE GroupName = @GroupName
            ), @TestUnit)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@TestName", subTestName);
                        insertCmd.Parameters.AddWithValue("@TestPrice", testPrice);
                        insertCmd.Parameters.AddWithValue("@GroupName", selectedGroupName);
                        insertCmd.Parameters.AddWithValue("@TestUnit", unitOfMeasurement);
                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Test added successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding test: " + ex.Message);
            }
        }

        // دالة للتحقق من صحة وحدة القياس
        private bool IsValidUnit(string unit)
        {
            // التأكد من أن الوحدة تحتوي على حروف أو نسبة مئوية أو حروف مع رموز
            return Regex.IsMatch(unit, @"^[a-zA-Z]+[%]*[a-zA-Z\s]*[^\d]*$") || Regex.IsMatch(unit, @"^%$");
        }

        // دالة للتحقق من أن النص إنجليزي فقط
        //private bool IsEnglishText(string input)
        //{
        //    return Regex.IsMatch(input, @"^[a-zA-Z\s]+$");
        //}


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // لا حاجة لإضافة كود هنا إذا لم يكن هناك عملية خاصة عند تغيير الاختيار في القائمة
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // تحديث قائمة الاختيارات عند الكتابة في comboBox1
            string filter = comboBox1.Text.ToLower();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(comboBox1.Items.Cast<string>().Where(item => item.ToLower().Contains(filter)).ToArray());
            comboBox1.SelectionStart = comboBox1.Text.Length;
            comboBox1.SelectionLength = 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // تحقق من أن النص في textBox3 يحتوي فقط على أحرف إنجليزية
            if (!IsEnglishText(textBox3.Text))
            {
                // حذف الأحرف غير الإنجليزية
                textBox3.Text = new string(textBox3.Text.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
                // ضبط موقع المؤشر
                textBox3.SelectionStart = textBox3.Text.Length;
            }
        }

        private void AddNewGroup_TextChanged(object sender, EventArgs e)
        {
            // تحقق من أن النص في AddNewGroup يحتوي فقط على أحرف إنجليزية
            if (!IsEnglishText(AddNewGroup.Text))
            {
                // حذف الأحرف غير الإنجليزية
                AddNewGroup.Text = new string(AddNewGroup.Text.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
                // ضبط موقع المؤشر
                AddNewGroup.SelectionStart = AddNewGroup.Text.Length;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // تحقق من أن النص في textBox4 يحتوي فقط على أحرف إنجليزية
            if (!IsEnglishText(textBox4.Text))
            {
                // حذف الأحرف غير الإنجليزية
                textBox4.Text = new string(textBox4.Text.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
                // ضبط موقع المؤشر
                textBox4.SelectionStart = textBox4.Text.Length;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // تحقق من أن النص في textBox2 يحتوي فقط على أحرف إنجليزية
            if (!IsEnglishText(textBox2.Text))
            {
                // حذف الأحرف غير الإنجليزية
                textBox2.Text = new string(textBox2.Text.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
                // ضبط موقع المؤشر
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }

        private void textBox_EnglishOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            // تحقق مما إذا كان المفتاح المضغط عليه هو حرف إنجليزي أو رقم أو مسافة
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // إلغاء إدخال المفتاح إذا لم يكن حرفًا إنجليزيًا أو رقمًا أو مسافة
                e.Handled = true;
                MessageBox.Show("Please enter only English letters, numbers, and spaces.");
            }
        }

        //private void ManageTestload(object sender, EventArgs e)
        //{
        //    FillcomboBox2ComboBox();
        //}

        private void FillcomboBox2ComboBox()
        {
            // Clear existing items
            comboBox2.Items.Clear();

            // Add predefined values
            comboBox2.Items.Add("AdultMale");
            comboBox2.Items.Add("AdultFemale");
            comboBox2.Items.Add("ChildMale");
            comboBox2.Items.Add("ChildFemale");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string SubTestName = textBox7.Text.Trim();
            string MinValueText = textBox8.Text.Trim();
            string MaxValueText = textBox9.Text.Trim();
            string Age_gender_cat = comboBox2.SelectedItem?.ToString();

            // Validate input fields
            if (string.IsNullOrWhiteSpace(SubTestName))
            {
                MessageBox.Show("Please enter the sub-test name.");
                return;
            }

            // Check if SubTestName contains only English letters and spaces
            if (!System.Text.RegularExpressions.Regex.IsMatch(SubTestName, @"^[a-zA-Z.\s]+$"))
            {
                MessageBox.Show("Sub-test name should only contain English letters.");
                return;
            }

            // Check if MinValue and MaxValue contain only English digits
            if (!System.Text.RegularExpressions.Regex.IsMatch(MinValueText, @"^\d+(\.\d+)?$"))
            {
                MessageBox.Show("Minimum value should be a valid number.");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(MaxValueText, @"^\d+(\.\d+)?$"))
            {
                MessageBox.Show("Maximum value should be a valid number.");
                return;
            }

            if (!decimal.TryParse(MinValueText, out decimal MinValue))
            {
                MessageBox.Show("Please enter a valid minimum value.");
                return;
            }

            if (!decimal.TryParse(MaxValueText, out decimal MaxValue))
            {
                MessageBox.Show("Please enter a valid maximum value.");
                return;
            }

            if (MinValue >= MaxValue)
            {
                MessageBox.Show("Minimum value should be less than the maximum value.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Age_gender_cat))
            {
                MessageBox.Show("Please select an age and gender category.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();

                    // Get SubTestID based on SubTestName
                    string getSubTestIdQuery = @"
                SELECT [SubTestID]
                FROM [dbo].[Sub_Test]
                WHERE [SubTestName] = @SubTestName";

                    SqlCommand getSubTestIdCmd = new SqlCommand(getSubTestIdQuery, con);
                    getSubTestIdCmd.Parameters.AddWithValue("@SubTestName", SubTestName);

                    object subTestIdObj = getSubTestIdCmd.ExecuteScalar();

                    if (subTestIdObj == null)
                    {
                        MessageBox.Show("Sub-test not found.");
                        return;
                    }

                    int SubTestID = Convert.ToInt32(subTestIdObj);

                    // Check if the record exists
                    string checkExistsQuery = @"
                SELECT COUNT(*)
                FROM [dbo].[Test_Normal_Value]
                WHERE [SubTestID] = @SubTestID AND [Age_gender_cat] = @Age_gender_cat";

                    SqlCommand checkExistsCmd = new SqlCommand(checkExistsQuery, con);
                    checkExistsCmd.Parameters.AddWithValue("@SubTestID", SubTestID);
                    checkExistsCmd.Parameters.AddWithValue("@Age_gender_cat", Age_gender_cat);

                    int count = (int)checkExistsCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Record exists, perform update
                        string updateQuery = @"
                    UPDATE [dbo].[Test_Normal_Value]
                    SET [MinValue] = @MinValue, [MaxValue] = @MaxValue
                    WHERE [SubTestID] = @SubTestID AND [Age_gender_cat] = @Age_gender_cat";

                        SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@MinValue", MinValue);
                        updateCmd.Parameters.AddWithValue("@MaxValue", MaxValue);
                        updateCmd.Parameters.AddWithValue("@SubTestID", SubTestID);
                        updateCmd.Parameters.AddWithValue("@Age_gender_cat", Age_gender_cat);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Normal values updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update normal values.");
                        }
                    }
                    else
                    {
                        // Record does not exist, perform insert
                        string insertQuery = @"
                    INSERT INTO [dbo].[Test_Normal_Value] ([SubTestID], [MinValue], [MaxValue], [Age_gender_cat])
                    VALUES (@SubTestID, @MinValue, @MaxValue, @Age_gender_cat)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@SubTestID", SubTestID);
                        insertCmd.Parameters.AddWithValue("@MinValue", MinValue);
                        insertCmd.Parameters.AddWithValue("@MaxValue", MaxValue);
                        insertCmd.Parameters.AddWithValue("@Age_gender_cat", Age_gender_cat);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Normal values added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add normal values.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        // تنفيذ كود هنا عند النقر على button3


        
        
          
            
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // تنفيذ كود هنا عند رسم البانيل
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // تنفيذ كود هنا عند تغيير اختيار comboBox4
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            // تنفيذ كود هنا عند تغيير النص في textBox9
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!IsEnglishText(textBox3.Text))
            {
                MessageBox.Show("Please enter text in English only.");
                return;
            }

            // متابعة حفظ البيانات أو العمليات الأخرى هنا
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string selectedSubTestName = comboBox6.SelectedItem?.ToString(); // Selected sub-test name
            string newSubTestName = textBox6.Text.Trim(); // New sub-test name

            if (string.IsNullOrEmpty(selectedSubTestName))
            {
                MessageBox.Show("Please select a sub-test from the list.");
                return;
            }

            if (string.IsNullOrEmpty(newSubTestName))
            {
                MessageBox.Show("Please enter the new sub-test name.");
                return;
            }

            // Check that the text contains only English letters and no numbers
            if (!IsEnglishText(newSubTestName))
            {
                MessageBox.Show("Please enter a valid sub-test name in English only, without numbers.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();

                    // Check if the new sub-test name already exists
                    string checkQuery = "SELECT COUNT(*) FROM Sub_Test WHERE SubTestName = @NewSubTestName";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@NewSubTestName", newSubTestName);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The new sub-test name already exists.");
                        return;
                    }

                    // Update the sub-test name
                    string updateQuery = "UPDATE Sub_Test SET SubTestName = @NewSubTestName WHERE SubTestName = @OldSubTestName";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@NewSubTestName", newSubTestName);
                    updateCmd.Parameters.AddWithValue("@OldSubTestName", selectedSubTestName);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sub-test name updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No changes were made.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating sub-test: " + ex.Message);
            }
        }






        private void button4_Click(object sender, EventArgs e)
        {
            string subTestName = comboBox9.SelectedItem?.ToString();

            // Validate input
            if (string.IsNullOrWhiteSpace(subTestName))
            {
                MessageBox.Show("Please select a sub-test to delete.");
                return;
            }

            // Check if the sub-test exists
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();

                    // Get SubTestID based on SubTestName
                    string getSubTestIdQuery = @"
            SELECT [SubTestID]
            FROM [dbo].[Sub_Test]
            WHERE [SubTestName] = @SubTestName";

                    SqlCommand getSubTestIdCmd = new SqlCommand(getSubTestIdQuery, con);
                    getSubTestIdCmd.Parameters.AddWithValue("@SubTestName", subTestName);

                    object subTestIdObj = getSubTestIdCmd.ExecuteScalar();

                    if (subTestIdObj == null)
                    {
                        MessageBox.Show("Sub-test not found.");
                        return;
                    }

                    int subTestID = Convert.ToInt32(subTestIdObj);

                    // Begin transaction
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Delete records from Test_Normal_Value
                            string deleteNormalValuesQuery = @"
                    DELETE FROM [dbo].[Test_Normal_Value]
                    WHERE [SubTestID] = @SubTestID";

                            SqlCommand deleteNormalValuesCmd = new SqlCommand(deleteNormalValuesQuery, con, transaction);
                            deleteNormalValuesCmd.Parameters.AddWithValue("@SubTestID", subTestID);
                            deleteNormalValuesCmd.ExecuteNonQuery();

                            // Delete the sub-test
                            string deleteSubTestQuery = @"
                    DELETE FROM [dbo].[Sub_Test]
                    WHERE [SubTestID] = @SubTestID";

                            SqlCommand deleteSubTestCmd = new SqlCommand(deleteSubTestQuery, con, transaction);
                            deleteSubTestCmd.Parameters.AddWithValue("@SubTestID", subTestID);
                            int rowsAffected = deleteSubTestCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show("Sub-test and related records deleted successfully.");
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("Failed to delete the sub-test.");
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {
            string selectedSubTestName = comboBox7.SelectedItem?.ToString(); // Selected sub-test name
            string newPriceText = textBox10.Text.Trim(); // New sub-test price

            // Check that fields are not empty
            if (string.IsNullOrEmpty(selectedSubTestName))
            {
                MessageBox.Show("Please select a sub-test from the list.");
                return;
            }

            if (string.IsNullOrEmpty(newPriceText))
            {
                MessageBox.Show("Please enter the new test price.");
                return;
            }

            // Check that the new price is a valid number
            if (!int.TryParse(newPriceText, out int newPrice) || newPrice < 0)
            {
                MessageBox.Show("Please enter a valid numeric price.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();

                    // Check if the selected sub-test exists in the database and get the current price
                    string checkQuery = "SELECT Price FROM Sub_Test WHERE SubTestName = @SubTestName";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@SubTestName", selectedSubTestName);

                    SqlDataReader reader = checkCmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        MessageBox.Show("The sub-test name does not exist.");
                        reader.Close();
                        return;
                    }

                    reader.Read();
                    int oldPrice = reader.GetInt32(0); // Reading the old price as int
                    reader.Close();

                    if (newPrice != oldPrice)
                    {
                        // Update the price
                        string updateQuery = "UPDATE Sub_Test SET Price = @NewPrice WHERE SubTestName = @SubTestName";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@NewPrice", newPrice);
                        updateCmd.Parameters.AddWithValue("@SubTestName", selectedSubTestName);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Test price updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("The new price is the same as the old price. No changes were made.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating test price: " + ex.Message);
            }
        }




        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroupName = comboBox3.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedGroupName))
                return;

            comboBox6.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = @"
            SELECT SubTestName 
            FROM Sub_Test 
            INNER JOIN Main_Test_Group ON Sub_Test.GroupID = Main_Test_Group.GroupID
            WHERE Main_Test_Group.GroupName = @GroupName";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@GroupName", selectedGroupName);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox6.Items.Add(reader["SubTestName"].ToString());
                }
                reader.Close();
            }
        }

       

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            laboratorySystemEntities1 le = new laboratorySystemEntities1();
            var tes = le.get_AllNameSubTests(comboBox10.SelectedItem.ToString());
            textBox7.Items.Clear();
            foreach (var item in tes)
            {
                textBox7.Items.Add(item.ToString());


            }
        }
    }
}


