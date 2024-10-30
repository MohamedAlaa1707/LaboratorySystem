using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Runtime.Remoting.Contexts;
using System.Linq;

namespace WindowsFormsApp4
{
    public partial class ShowResults : Form
    {
        private Size OriginalSize;
        private readonly Dictionary<Control, Rectangle> OriginalControlSizes = new Dictionary<Control, Rectangle>();
        HomePage _homePage;
        public ShowResults(HomePage h)
        {
            _homePage = h;
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            OriginalSize = this.ClientSize;

            foreach (Control ctrl in this.Controls)
            {
                OriginalControlSizes[ctrl] = ctrl.Bounds;
            }

            GlobalKeyHandler.RegisterGlobalShortcuts(this);
            this.Resize += ResizeControls;
        }

        private void ResizeControls(object sender, EventArgs e)
        {
            //double xRatio = (double)this.ClientSize.Width / OriginalSize.Width;
            //double yRatio = (double)this.ClientSize.Height / OriginalSize.Height;

            //foreach (Control ctrl in this.Controls)
            //{
            //    if (OriginalControlSizes.ContainsKey(ctrl))
            //    {
            //        Rectangle originalRect = OriginalControlSizes[ctrl];
            //        ctrl.SetBounds(
            //            (int)(originalRect.X * xRatio),
            //            (int)(originalRect.Y * yRatio),
            //            (int)(originalRect.Width * xRatio),
            //            (int)(originalRect.Height * yRatio)
            //        );
            //    }
            //}

            //// Ensure that DataGridView is sized appropriately
            //dgvShowAllTests.Width = this.ClientSize.Width - 50;
            //dgvShowAllTests.Height = this.ClientSize.Height - 300;

            //// Recenter the Back button
            //Backbutton.Left = (this.ClientSize.Width - Backbutton.Width) / 2;
            //Backbutton.Top = this.ClientSize.Height - Backbutton.Height - 50;
        }

        private void Backbutton_Click(object sender, EventArgs e)
        {
            _homePage.Show();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShowAllTests.Rows.Count == 1  )
            {
                MessageBox.Show("There is no data to display.");
                return;
            }

            //MessageBox.Show(e.RowIndex.ToString());

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                laboratorySystemEntities1 le = new laboratorySystemEntities1();
              
               
                showResult er = new showResult(this);
                er.Size = this.Size;
                er.StartPosition = FormStartPosition.Manual;
                er.Location = this.Location;

                string selectedPatientName = dgvShowAllTests.Rows[e.RowIndex].Cells["PatientNameDAtaGrid"].Value?.ToString();
                string selectedTestName = dgvShowAllTests.Rows[e.RowIndex].Cells["TestNameDAtaGrid"].Value?.ToString();

                if (string.IsNullOrEmpty(selectedPatientName) || string.IsNullOrEmpty(selectedTestName))
                {
                        return;
                }




                var pa = (from p in le.Patients
                          where p.Name == selectedPatientName
                          select p).FirstOrDefault();

                if (pa != null)
                {
                    er.PatientID = pa.PatientID.ToString();
                    er.PatientTitle = pa.Title;
                    er.PatientName = selectedPatientName;
                    er.PatientGender = pa.Gender;
                    er.PatientAge = pa.Age.ToString();
                    er.PatientAgeUnit = pa.AgeUnit;
                    er.PatientRefBy = pa.RefBy;
                    er.PatientPhone = pa.Phone;
                    er.PatientDate = pa.Date.ToString();
                    er.TestName = selectedTestName;
                    er.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No patient found with the provided name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = startDatePicker.Value.Date;
            DateTime endDate = endDatePicker.Value.Date;
            string patientName = searchTextBox.Text.Trim();

            using (laboratorySystemEntities1 db = new laboratorySystemEntities1())
            {
                var results = (from p in db.Patients
                               join prv in db.patientResultValues on p.PatientID equals prv.patient_id
                               join st in db.Sub_Test on prv.testID equals st.SubTestID
                               join pt in db.Patient_Test on prv.patient_test_id equals pt.Patient_Test_ID
                               where pt.TestDate >= startDate && pt.TestDate <= endDate
                                     && p.Name.Contains(patientName)
                               select new
                               {
                                   PatientName = p.Name,
                                   TestName = st.SubTestName,
                                   TestDate = pt.TestDate,
                                   ResultValue = prv.ResultValue
                               }).ToList();

                // Clear the grid view before adding new data
                dgvShowAllTests.Rows.Clear();

                // Add fetched data to the grid view
                foreach (var result in results)
                {
                    dgvShowAllTests.Rows.Add(result.PatientName, result.TestName, result.TestDate, result.ResultValue);
                }
            }
        }

        private void ShowResults_Load(object sender, EventArgs e)
        {
            endDatePicker.Value = DateTime.Now;
        }
    }
    }

