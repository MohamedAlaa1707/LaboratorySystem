using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp4
{
    public partial class DirectRegisteration : Form
    {
        HomePage _homePage;
        public DirectRegisteration(HomePage h)
        {
            //  ل احتافظ بنسخه من الصفحه التي السابقه لكي نعيد فتحها 
            _homePage = h;
            //لكي يغلق البرنامج في حاله ضغط علي     ctrl + f4
            GlobalKeyHandler.RegisterGlobalShortcuts(this);
            InitializeComponent();


            this.Activated += new System.EventHandler(this.DirectRegisteration_Load);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _homePage.Show();
            this.Close();
        }

      

        private void DirectRegisteration_Load(object sender, EventArgs e)
        {
           
            // connection data base
              laboratorySystemEntities1 le = new laboratorySystemEntities1();
            ////   Assgin date   
            DatetextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            ////     Fetch to new id  last id in table +1
                    var New_ID = (from i in le.Patients
                                  select (int?)i.PatientID).Max() ?? 0;
                    New_ID++;
                    idtxt.Text = New_ID.ToString();
            // total price   intial Vaule
                   totaltxt.Text = "0";
            ///   select all ref in data base   
                    var all_ref = (from i in le.Patients 
                                   select i.RefBy).Distinct();
            if (all_ref != null)
            {

                foreach (var item in all_ref)
                {
                    if (item != null)
                        refcom.Items.Add(item);

                }
            }



            // // Retrieve a list of all main group names 


                        var getGRO = le.fn_GetAllMainGroupNames().ToList();
                        for (int i = 0; i < getGRO.Count; i++)
                        {
                            AddcomboBox.Items.Add(getGRO[i].GroupName);

                        }
                        AddcomboBox.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage p = new HomePage();
            EnterResults eR = new EnterResults(p);

            eR.Size = this.Size;
            eR.StartPosition = FormStartPosition.Manual;
            eR.Location = this.Location;


                 eR.PatientID = idtxt.Text;
                eR.PatientTitle  =TitleCom.Text     ;
                eR.PatientName   =nametxt.Text      ;
                eR.PatientGender =gendercom.Text    ;
                eR.PatientAge    = agetxt.Text      ;
                eR.PatientAgeUnit= unitagecom.Text  ;
                eR.PatientRefBy  = refcom.Text      ;
                eR.PatientPhone  = phonetxt.Text    ;
                eR.PatientDate = DatetextBox.Text   ;
              eR.Show();
            this.Close();
        }

        private void refcom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string enteredText = refcom.Text;


                if (!refcom.Items.Contains(enteredText) && !string.IsNullOrEmpty(enteredText))
                {

                    refcom.Items.Add(enteredText);


                    refcom.SelectedItem = enteredText;
                }
            }
        }

        private void AddcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///checkedListBox1
            GetAllTestForGRoubName();


        }

        private void searchTxtBox_TextChanged(object sender, EventArgs e)
        {
            laboratorySystemEntities1 le = new laboratorySystemEntities1();
            if (string.IsNullOrEmpty(searchTxtBox.Text))
            {

                GetAllTestForGRoubName();

            }
            string grroupName = AddcomboBox.SelectedItem as string;
            var list = le.fn_GetAllSubTestNames(grroupName);
            checkedListBox1.Items.Clear();
            foreach (var item in list)
            {
                string itemText = item.SubTestName;

                if (Regex.IsMatch(itemText, searchTxtBox.Text, RegexOptions.IgnoreCase))
                {
                    checkedListBox1.Items.Add(item.SubTestName);
                }

            }

        }

        private void GetAllTestForGRoubName() {
            laboratorySystemEntities1 lab = new laboratorySystemEntities1();
            var allTestsforGroupName = lab.fn_GetAllSubTestNames(AddcomboBox.SelectedItem.ToString());
            checkedListBox1.Items.Clear();
            foreach (var item in allTestsforGroupName)
            {
                checkedListBox1.Items.Add(item.SubTestName);

            }

        }

        private void AddToListbutton_Click(object sender, EventArgs e)
        {

            laboratorySystemEntities1 s = new laboratorySystemEntities1();
            // to uncheck test  after insert into dgvTestPrice
          

            int total = int.Parse(totaltxt.Text);

            foreach (var item in checkedListBox1.CheckedItems)
            {
                var price = (from i in s.Sub_Test
                             where i.SubTestName == item.ToString()
                             select i.Price).FirstOrDefault();
                bool itemExists = dgvTestPrice.Rows.Cast<DataGridViewRow>()
                           .Any(r => r.Cells[0].Value?.ToString() == item.ToString());
                if (itemExists)
                {
                    continue;
                }
                dgvTestPrice.Rows.Add(item, price);

                total += price;

               
            }

           

           
            totaltxt.Text = total.ToString();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            laboratorySystemEntities1 l = new laboratorySystemEntities1();

            // التحقق من صحة الإدخالات
            if (TitleCom.SelectedItem == null)
            {
                MessageBox.Show("Please choose a Title.");
                TitleCom.Focus();
                return;
            }

            if (nametxt.Text.Length < 16)
            {
                MessageBox.Show("Please enter a valid name (greater than 16 characters).");
                nametxt.Focus();
                return;
            }

            if (gendercom.SelectedItem == null)
            {
                MessageBox.Show("Please choose Gender.");
                gendercom.Focus();
                return;
            }

            if (!int.TryParse(agetxt.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Please enter a valid age (greater than 0).");
                agetxt.Focus();
                return;
            }

            if (unitagecom.SelectedItem == null)
            {
                MessageBox.Show("Please choose Unit Age.");
                unitagecom.Focus();
                return;
            }

            if (refcom.SelectedItem == null)
            {
                MessageBox.Show("Please choose or write Ref By.");
                refcom.Focus();
                return;
            }

            if (phonetxt.Text.Length != 11 || phonetxt.Text[0] != '0' || phonetxt.Text[1] != '1')
            {
                MessageBox.Show("Please enter a valid phone number (11 digits, starts with '01').");
                phonetxt.Focus();
                return;
            }

            if (dgvTestPrice.Rows.Count == 1)
            {
                MessageBox.Show("Please choose a test.");
                return;
            }

            // إضافة مريض جديد
            var newPatient = new Patient()
            {
                Title = TitleCom.SelectedItem.ToString(),
                Name = nametxt.Text,
                RefBy = refcom.SelectedItem.ToString(),
                Age = int.Parse(agetxt.Text),
                AgeUnit = unitagecom.SelectedItem.ToString(),
                Date = DateTime.Now,
                Gender = gendercom.SelectedItem.ToString(),
                Phone = phonetxt.Text,
            };

            l.Patients.Add(newPatient);
            l.SaveChanges(); // حفظ المريض في قاعدة البيانات

            // بعد الحفظ، احصل على المعرف (PatientID) الذي تم توليده تلقائياً
            int patientId = newPatient.PatientID;

            // تسجيل اختبار جديد للمريض
            var PatientTest = new Patient_Test()
            {
                Patient_Test_ID = patientId, // ربط الاختبار بالمريض
                TestDate = DateTime.Now,
            };

            l.Patient_Test.Add(PatientTest);
            l.SaveChanges(); // حفظ بيانات الاختبار

            // احصل على معرف الاختبار الذي تم إنشاؤه
            int patientTestId = PatientTest.Patient_Test_ID;

            // إضافة نتائج الفحوصات للمريض
            foreach (DataGridViewRow row in dgvTestPrice.Rows)
            {
                if (row.Cells["Test"].Value != null)
                {
                    string subTestName = row.Cells["Test"].Value.ToString();
                    int subTestId = (from i in l.Sub_Test
                                     where i.SubTestName == subTestName
                                     select i.SubTestID).FirstOrDefault();

                    var resultValue = new patientResultValue()
                    {
                        testID = subTestId,
                        patient_id = patientId,
                        patient_test_id = patientTestId,
                        ResultValue = "Result Pending"
                    };

                    l.patientResultValues.Add(resultValue);
                }
            }

            // حفظ جميع نتائج الفحوصات في قاعدة البيانات
            l.SaveChanges();

            // رسالة نجاح
            MessageBox.Show("Patient and test data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    



        private void delete_Click_1(object sender, EventArgs e)
        {
            laboratorySystemEntities1 l = new laboratorySystemEntities1();
            int totalPrice = int.Parse(totaltxt.Text);


            if (dgvTestPrice.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in dgvTestPrice.SelectedRows)
                {

                    if (!row.IsNewRow)
                    {
                        string subTestName = row.Cells["Test"].Value.ToString();


                        var price = (from i in l.Sub_Test
                                     where i.SubTestName == subTestName
                                     select i.Price).FirstOrDefault();

                        totalPrice -= price;
                        dgvTestPrice.Rows.Remove(row);


                       
                    }
                }


               
            }
            else
            {
               
                MessageBox.Show("No row selected to delete.");
               
            }
            totaltxt.Text = totalPrice.ToString();
        }

      

        private void New_Click(object sender, EventArgs e)
        {
            laboratorySystemEntities1 l = new laboratorySystemEntities1();
            TitleCom.SelectedIndex = -1;
            nametxt.Clear();
            refcom.SelectedIndex = -1;
            agetxt.Clear();
            unitagecom.SelectedIndex = -1;
            gendercom.SelectedIndex = -1;
            phonetxt.Clear();
            dgvTestPrice.Rows.Clear();
            var New_ID = (from i in l.Patients
                          select (int?)i.PatientID).Max() ?? 0;
            New_ID++;
            idtxt.Text = New_ID.ToString();

        }

       
    }
} 