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
    public partial class checksetting : Form
    {
        HomePage _settings;
        string name;
        public checksetting( HomePage s, string name)
        {
            _settings = s;
            GlobalKeyHandler.RegisterGlobalShortcuts(this);
            InitializeComponent();
            this.name = name;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            _settings.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
             
            if (textBox1.Text=="")
            {
                MessageBox.Show("please enter user name");
                return;
                
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("please enter password");
                return;

            }
            var lab = new laboratorySystemEntities1();
            var user = lab.Users.FirstOrDefault(s => s.Username == textBox1.Text);
            if (user == null) {
                MessageBox.Show("Username not found. Please check your username and try again.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 this.Close();
                _settings.Show();
                return;
            }
            if (user.Password == textBox2.Text)
            {
                settings er = new settings(_settings);
                er.Size = this.Size;
                er.StartPosition = FormStartPosition.Manual;
                er.Location = this.Location;
                er.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Incorrect password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox2.Text = "";
                textBox2.Focus();

            }

        }

        private void checksetting_Load(object sender, EventArgs e)
        {

        }
    }
}
