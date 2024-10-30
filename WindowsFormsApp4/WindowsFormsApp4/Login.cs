using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Login : Form
    {
        private Size OriginalSize;
      
        private readonly Dictionary<Control, Rectangle> OriginalControlSizes = new Dictionary<Control, Rectangle>();

        public Login()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            OriginalSize = this.ClientSize;

            foreach (Control ctrl in this.Controls)
            {
                OriginalControlSizes[ctrl] = ctrl.Bounds;
            }

            this.Resize += ResizeControls;
            this.Load += Login_Load; // Ensure Login_Load is called
        }

        private void ResizeControls(object sender, EventArgs e)
        {
            double xRatio = (double)this.ClientSize.Width / OriginalSize.Width;
            double yRatio = (double)this.ClientSize.Height / OriginalSize.Height;

            // Calculate the new size of panel2 based on its contents
            int panel2Width = 0;
            int panel2Height = 0;
            foreach (Control ctrl in panel2.Controls)
            {
                panel2Width = Math.Max(panel2Width, ctrl.Right);
                panel2Height = Math.Max(panel2Height, ctrl.Bottom);
            }

            // Add padding to panel2
            panel2Width += 20;
            panel2Height += 20;

            panel2.Width = (int)(panel2Width * xRatio) / 2 + 100;
            panel2.Height = (int)(panel2Height * yRatio) / 2 + 100;
            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height - back_BTN.Height) / 4 + 100;
            back_BTN.Left = (this.ClientSize.Width - back_BTN.Width) / 2;
            back_BTN.Top = this.ClientSize.Height - back_BTN.Height - 150;
            GlobalKeyHandler.RegisterGlobalShortcuts(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            using (var circlePath = new System.Drawing.Drawing2D.GraphicsPath())
            {
                circlePath.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Region = new Region(circlePath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public string HashPassword(string password)
        //{
        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage h = new HomePage
            {
                Size = this.Size,
                StartPosition = FormStartPosition.Manual,
                Location = this.Location
            };

            h.Show();
            this.Hide();
        //    if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
        //    {
        //        MessageBox.Show("Username or password is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }


        //    try
        //    {
        //        using (var context = new laboratorySystemEntities1())
        //        {
                  
        //            var user = context.Users.FirstOrDefault(u => u.Username == textBox1.Text.ToString() && u.Password == textBox2.Text);
                    

        //            if (user != null)
        //            {

        //                HomePage h = new HomePage
        //                {
        //                    Size = this.Size,
        //                    StartPosition = FormStartPosition.Manual,
        //                    Location = this.Location
        //                };
        //                if (user.Role == "user")
        //                {

        //                    h.role = true;
        //                }

        //                h.Show();
        //                this.Hide();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                textBox2.PasswordChar = '\0';
            }
            else
            {

                textBox2.PasswordChar = '*';
            }


        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    PrintReport pr = new PrintReport();
        //    pr.Show();
        //}
    }
}