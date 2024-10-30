using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class UserAccount1 : Form
    {
        settings _settin;

        public UserAccount1(settings s)
        {
            _settin = s;
            InitializeComponent();

            GlobalKeyHandler.RegisterGlobalShortcuts(this);
        }
        private void FillComboBox()
        {
            try
            {
                using (var db = new laboratorySystemEntities1())
                {
                    var usernames = db.Users.Select(u => u.Username).ToList();
                    namelistcomboBox.DataSource = usernames;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the data: {ex.Message}");

            }
        }
        private void FillComboBoxs_Delete()
        {
            using (var db = new laboratorySystemEntities1())
            {
                var usernames = db.Users
                     .Where(u => u.Role == "user")
                     .Select(u => u.Username)
                     .ToList();

                // Set the DataSource of the comboBox
                DeletecomboBox.DataSource = usernames;
            }
        }



        private void UserManagementForm_Load(object sender, EventArgs e)
        {



            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            ///////////////
            //Delete
            //namelistcomboBox.DataSource = null;
            //DeletecomboBox.DataSource = null;

            FillComboBoxs_Delete();

            FillComboBox();


        }



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            _settin.Show();
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            if (password != confirmPassword)
            {
                MessageBox.Show("The password does not match the confirmed password.");
                return; // Exit the method if the passwords do not match
            }
            if (password.Length < 10)
            {
                MessageBox.Show("The password must be at least 10 characters long.");
                return;
            }
          
            using (var db = new laboratorySystemEntities1())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Username == username);

                if (existingUser != null)
                {
                    MessageBox.Show("The username already exists.");
                }
                else
                {
                    // إضافة المستخدم الجديد
                    var newUser = new User
                    {
                        Username = username,
                        Lab_Name = "El youm Elwaheid", // افترض وجود TextBox باسم txtLabName
                        Password = txtPassword.Text,
                        Role = "user"
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    MessageBox.Show("User has been successfully added.");

                    FillComboBoxs_Delete();

                }
                //////////////
                using (var db2 = new laboratorySystemEntities1())
                {
                    // ملء ComboBox بأسماء المستخدمين
                    namelistcomboBox.DataSource = db2.Users.Select(u => u.Username).ToList();
                }
            }
        }





        private void namelistcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUsername = namelistcomboBox.SelectedItem?.ToString();
            if (selectedUsername != null)
            {
                // عرض اسم المستخدم المختار في TextBox
                textBox1.Text = selectedUsername;
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            FillComboBoxs_Delete();

            string password = textBox2.Text;
            if (password.Length < 10)
            {
                MessageBox.Show("The password must be at least 10 characters long.");
                return;
            }


            // التحقق من اختيار اسم مستخدم
            string oldUsername = namelistcomboBox.SelectedItem?.ToString();
            if (oldUsername == null)
            {
                MessageBox.Show("Please select a username from the list.");
                return;
            }


            // الحصول على الاسم الجديد وكلمة المرور
            string newUsername = textBox1.Text;
            string newPassword = textBox2.Text;

            using (var db2 = new laboratorySystemEntities1())
            {
                // التحقق من وجود المستخدم القديم
                var user = db2.Users.FirstOrDefault(u => u.Username == oldUsername);
                if (user != null)
                {
                    // التحقق مما إذا كان الاسم الجديد موجودًا بالفعل
                    var existingUser = db2.Users.FirstOrDefault(u => u.Username == newUsername && u.Username != oldUsername);
                    if (existingUser != null)
                    {
                        MessageBox.Show("The new username already exists.");
                        return;
                    }


                    // حذف المستخدم القديم
                    db2.Users.Remove(user);

                    // إضافة المستخدم الجديد
                    var newUser = new User
                    {
                        Username = newUsername,
                        Password = newPassword,
                        Lab_Name = "El youm Elwaheid", // نسخ بيانات المختبر
                        Role = "user", // نسخ الدور
                    };
                    db2.Users.Add(newUser);
                    db2.SaveChanges();

                    // تحديث ComboBox بعد التعديل
                    FillComboBoxs_Delete();

                    // تحديد العنصر الجديد في ComboBox
                    namelistcomboBox.SelectedItem = newUsername;

                    MessageBox.Show("User details have been successfully updated.");
                }
                else
                {
                    MessageBox.Show("User not found.");

                }
            }

        }
        /////
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string usernameToDelete = DeletecomboBox.SelectedItem.ToString();

            if (string.IsNullOrEmpty(usernameToDelete))
            {
                MessageBox.Show("Please select the username to delete.");

                return;
            }

            // إضافة رسالة تأكيد
            DialogResult result = MessageBox.Show("Are you sure you want to delete the user " + usernameToDelete + "?", "Delete Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                using (var db = new laboratorySystemEntities1())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == usernameToDelete);

                    if (user != null)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();


                        MessageBox.Show("User has been successfully deleted.");


                        // إعادة تعبئة القائمة بعد الحذف
                        FillComboBoxs_Delete();
                    }
                    else
                    {
                        MessageBox.Show("User not found.");

                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DeletecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            _settin.Show();
        }
    }
}
