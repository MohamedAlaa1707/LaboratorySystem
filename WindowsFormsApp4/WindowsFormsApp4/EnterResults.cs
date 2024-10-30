using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class EnterResults : Form
    {
        HomePage _homePage;
        private string selectedGroupName;
        List<PRval> PResVAlues = new List<PRval>();
        public string PatientID
        {
            get { return idtxt.Text; }
            set { idtxt.Text = value; }
        }
        public string PatientTitle
        {
            get { return TitleCom.Text; }
            set { TitleCom.Text = value; }
        }
        public string PatientName
        {
            get { return nametxt.Text; }
            set { nametxt.Text = value; }
        }
        public string PatientGender
        {
            get { return gendercom.Text; }
            set { gendercom.Text = value; }
        }
        public string PatientAge
        {
            get { return agetxt.Text; }
            set { agetxt.Text = value; }
        }
        public string PatientAgeUnit
        {
            get { return unitagecom.Text; }
            set { unitagecom.Text = value; }
        }
        public string PatientRefBy
        {
            get { return refcom.Text; }
            set { refcom.Text = value; }
        }
        public string PatientPhone
        {
            get { return phonetxt.Text; }
            set { phonetxt.Text = value; }
        }
        public string PatientDate
        {
            get { return DatetextBox.Text; }
            set { DatetextBox.Text = value; }
        }



        public EnterResults(HomePage h)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _homePage = h;
            ResultSDataGridView.DefaultCellStyle.Font = new Font("Arial", 20);
            // Group Name
            PatienstDataGridView2.SelectionChanged += PatienstDataGridView2_SelectionChanged;
            PatienstDataGridView2.CellClick += PatienstDataGridView2_CellClick;


        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _homePage.Show();
            this.Close();
        }


        private void searchByDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = searchByDateTimePicker.Value.Date; // Get the selected date

            using (laboratorySystemEntities1 db = new laboratorySystemEntities1())
            {
                // Fetch patient names and corresponding TestIDs where PatientID matches and date is selectedDate
                var results = (from pr in db.patientResultValues
                              join s in db.Sub_Test on pr.testID equals s.SubTestID
                              join g in db.Main_Test_Group on s.GroupID equals g.GroupID
                              join p in db.Patients on pr.patient_id equals p.PatientID
                              where p.Date == selectedDate // Assuming Date is a string property. Adjust accordingly.
                              select new
                              {
                                  PatientName = p.Name,
                                  GroupName = g.GroupName
                              }).Distinct();

                // Clear the grid view before adding new data
                PatienstDataGridView2.Rows.Clear();

                // Add fetched patient names and TestIDs to the grid view
                foreach (var result in results)
                {
                    PatienstDataGridView2.Rows.Add(result.PatientName, result.GroupName);
                }
            }

        }

        private void ResultSDataGridView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void PatienstDataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PatienstDataGridView2.Rows.Count == 0 || e.RowIndex < 0)
            {
                MessageBox.Show("There is no data to display.");
                return;
            }
            var patientCell = PatienstDataGridView2.Rows[e.RowIndex].Cells["PnameDataGridView"].Value;
            if (patientCell == null)
            {
                MessageBox.Show("Patient name is not available in the selected row.");
                return;
            }

            if (e.RowIndex >= 0)
            {
                laboratorySystemEntities1 le = new laboratorySystemEntities1();
                // Get selected patient name from the clicked row
                string selectedPatientName = PatienstDataGridView2.Rows[e.RowIndex].Cells["PnameDataGridView"].Value.ToString();
                string selectedGroup = PatienstDataGridView2.Rows[e.RowIndex].Cells["GroupNameDGV"].Value.ToString();

                var pa = (from p in le.Patients
                          where p.Name == selectedPatientName
                          select p).FirstOrDefault();
                TitleCom.Text = pa.Title;
                nametxt.Text = pa.Name;
                gendercom.Text = pa.Gender;
                agetxt.Text = pa.Age.ToString();
                unitagecom.Text = pa.AgeUnit;
                idtxt.Text = pa.PatientID.ToString();
                refcom.Text = pa.RefBy;
                phonetxt.Text = pa.Phone;
                DatetextBox.Text = pa.Date.ToString();

                using (laboratorySystemEntities1 db = new laboratorySystemEntities1())
                {
                    // Fetch the patient information
                    var patient = db.Patients.FirstOrDefault(p => p.Name == selectedPatientName);
                    if (patient == null) return;

                    // Fetch the corresponding test results
                    var results = (from pr in db.patientResultValues
                                   join st in db.Sub_Test on pr.testID equals st.SubTestID
                                   join pt in db.Patient_Test on pr.patient_test_id equals pt.Patient_Test_ID
                                   join gn in db.Main_Test_Group on st.GroupID equals gn.GroupID
                                   where pr.patient_id == patient.PatientID && gn.GroupName== selectedGroup
                                   select new
                                   {
                                       TestName = st.SubTestName,
                                       pr.ResultValue,
                                       pt.TestDate, // Get the test date
                                       pr.testID,
                                       pr.patient_id,
                                       pr.patient_test_id
                                   }).ToList().Distinct();


                    // Clear ResultSDataGridView before adding new data
                    ResultSDataGridView.Rows.Clear();

                    foreach (var result in results)
                    {
                        int rowIndex = 0;
                        string resultValueStr;
                        // Ensure the TestDate is not null
                        if (result.TestDate != null)
                        {
                            DateTime testDate = result.TestDate.Value;
                            if (result.ResultValue == "Result Pending")
                            {
                                resultValueStr = "0";

                            }
                            else
                            {

                                resultValueStr = result.ResultValue;


                            }
                            rowIndex = ResultSDataGridView.Rows.Add(result.TestName, resultValueStr, "N", "");


                            // Add a new row and get the row index

                            // Check if more than two weeks have passed since the test date
                            if ((DateTime.Now - testDate).TotalDays > 14)
                            {
                                // Make all cells in the row read-only
                                foreach (DataGridViewCell cell in ResultSDataGridView.Rows[rowIndex].Cells)
                                {
                                    cell.ReadOnly = true;
                                }
                            }
                            else
                            {
                                if (result.TestName== "Glycosylated Hb.") { 
                                
                                
                                
                                
                                }





                                // Get normal value
                                var normalValue = db.fn_GetNormalValueForTest(result.TestName, patient.Age, patient.Gender).FirstOrDefault();

                                if (normalValue != null)
                                {
                                    // Log values for debugging
                                    string minValueStr = normalValue.MinValue;
                                    string maxValueStr = normalValue.MaxValue;


                                    // Attempt to parse the string values
                                    double minValue, maxValue, resultValue;
                                    bool isMinValueParsed = double.TryParse(minValueStr, out minValue);
                                    bool isMaxValueParsed = double.TryParse(maxValueStr, out maxValue);

                                    bool isResultValueParsed = double.TryParse(resultValueStr, out resultValue);

                                    if (isMinValueParsed && isMaxValueParsed && isResultValueParsed)
                                    {
                                        // Determine L/H/N status
                                        string lhStatus = "N";
                                        if (resultValue < minValue)
                                        {
                                            lhStatus = "L";
                                        }
                                        else if (resultValue > maxValue)
                                        {
                                            lhStatus = "H";
                                        }

                                        // Update the L/H/N status and normal value range in the grid
                                        ResultSDataGridView.Rows[rowIndex].Cells["StateDAtaGrid"].Value = lhStatus;
                                        ResultSDataGridView.Rows[rowIndex].Cells["NormalValueDAtaGrid"].Value = $"{minValue} - {maxValue}";
                                        PResVAlues.Add(new PRval() { testID = result.testID.GetValueOrDefault(), patient_id = result.patient_id.GetValueOrDefault(), patient_test_id = result.patient_test_id.GetValueOrDefault() });

                                    }
                                    else
                                    {
                                        // Output detailed debug information
                                        string message = "One of the values could not be parsed to a number.\n";
                                        if (!isMinValueParsed) message += $"MinValue: {minValueStr}\n";
                                        if (!isMaxValueParsed) message += $"MaxValue: {maxValueStr}\n";
                                        if (!isResultValueParsed) message += $"ResultValue: {resultValueStr}\n";
                                        MessageBox.Show(message);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        // save
        private void button2_Click(object sender, EventArgs e)
        {
            using (laboratorySystemEntities1 l = new laboratorySystemEntities1())
            {
                int patientId = int.Parse(idtxt.Text);

                DateTime testDate;
                if (!DateTime.TryParse(DatetextBox.Text, out testDate))
                {
                    MessageBox.Show("Invalid test date. Please check the date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Find the Patient_Test entry based on test date and patientId
                var patientTest = (from pt in l.Patient_Test
                                   join pr in l.patientResultValues on pt.Patient_Test_ID equals pr.patient_test_id
                                   where pr.patient_id == patientId && pt.TestDate == testDate
                                   select pt).FirstOrDefault();

                if (patientTest == null)
                {
                    MessageBox.Show("No test found for the given patient on this date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int patientTestId = patientTest.Patient_Test_ID;

                foreach (DataGridViewRow row in ResultSDataGridView.Rows)
                {
                    if (row.Cells["TestDAtaGrid"].Value != null) // Assuming the column name for the test name is "TestDAtaGrid"
                    {
                        string subTestName = row.Cells["TestDAtaGrid"].Value.ToString();

                        int subTestId = (from i in l.Sub_Test
                                         where i.SubTestName == subTestName
                                         select i.SubTestID).FirstOrDefault();

                        if (subTestId != 0)
                        {
                            string resultValue = row.Cells["ResultDAtaGrid"].Value?.ToString() ?? "Result Pending";

                            // Find the existing result entry
                            var existingResult = l.patientResultValues
                                                .FirstOrDefault(pr => pr.testID == subTestId &&
                                                                      pr.patient_id == patientId &&
                                                                      pr.patient_test_id == patientTestId);

                            if (existingResult != null)
                            {
                                // Update the result value
                                existingResult.ResultValue = resultValue;
                            }
                            else
                            {
                                MessageBox.Show($"No existing result found for {subTestName}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                l.SaveChanges();

                MessageBox.Show("Test results updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void WhatsappButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = phonetxt.Text;

            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

                if (!phoneNumber.StartsWith("+2"))
                {
                    phoneNumber = "+2" + phoneNumber;
                }
                string url = $"https://wa.me/{phoneNumber}";

                System.Diagnostics.Process.Start(url);
            }
            else
            {
                MessageBox.Show("Please enter a valid phone number.");
            }
        }



        private void PatienstDataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (PatienstDataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = PatienstDataGridView2.SelectedRows[0];
                selectedGroupName = selectedRow.Cells["GroupNameDGV"].Value?.ToString() ?? string.Empty;
            }
        }

        // لارجاع اسم الجروب عند تحديد خلية فقط
        private void PatienstDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var selectedRow = PatienstDataGridView2.Rows[e.RowIndex];
                selectedGroupName = selectedRow.Cells["GroupNameDGV"].Value?.ToString() ?? string.Empty;
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            List<ReportData> reportDataList = new List<ReportData>();

            foreach (DataGridViewRow row in ResultSDataGridView.Rows)
            {
                if (row.Cells["TestDAtaGrid"].Value != null)
                {
                    reportDataList.Add(new ReportData
                    {
                        Test = row.Cells["TestDAtaGrid"].Value.ToString(),
                        Result = row.Cells["ResultDAtaGrid"].Value.ToString(),
                        NormalValue = row.Cells["NormalValueDAtaGrid"].Value.ToString()
                    });
                }
            }

            ReportViewer reportViewerForm = new ReportViewer(reportDataList, PatientName, PatientRefBy, PatientDate, PatientGender, PatientAge, PatientAgeUnit, selectedGroupName);
            reportViewerForm.Show();
        }

        private void ResultSDataGridView_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.ColumnIndex == ResultSDataGridView.Columns["ResultDAtaGrid"].Index)
            {
                var resultCell = ResultSDataGridView.Rows[e.RowIndex].Cells["ResultDAtaGrid"].Value;
                if (resultCell != null && double.TryParse(resultCell.ToString(), out double result))
                {
                    if (result < 0)
                    {
                        MessageBox.Show("Please enter a positive number.");
                        ResultSDataGridView.Rows[e.RowIndex].Cells["ResultDAtaGrid"].Value = "0";
                        return;
                    }

                    var normalValue = ResultSDataGridView.Rows[e.RowIndex].Cells["NormalValueDAtaGrid"].Value?.ToString();
                    if (!string.IsNullOrEmpty(normalValue))
                    {
                        var normalRange = normalValue.Split('-');
                        if (normalRange.Length == 2 &&
                            double.TryParse(normalRange[0], out double lowerBound) &&
                            double.TryParse(normalRange[1], out double upperBound))
                        {
                            string lhStatus = "N"; // Default to Normal

                            if (result < lowerBound)
                            {
                                lhStatus = "L"; // Low
                            }
                            else if (result > upperBound)
                            {
                                lhStatus = "H"; // High
                            }

                            ResultSDataGridView.Rows[e.RowIndex].Cells["StateDAtaGrid"].Value = lhStatus;

                            // Ensure PResVAlues has enough items
                            if (PResVAlues != null && e.RowIndex < PResVAlues.Count && PResVAlues[e.RowIndex] != null)
                            {
                                PResVAlues[e.RowIndex].ResultValue = result.ToString();
                            }
                            else
                            {
                                MessageBox.Show("PResVAlues is not initialized or the index is out of range.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid normal value range.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number in the Result field.");
                }
            }
        }

        private void EnterResults_Load(object sender, EventArgs e)
        {

        }

       
    }
    public class PRval
    {
        public int testID;
        public int patient_test_id;
        public int SubTestID;
        public int patient_id;

        public string ResultValue;

        public override string ToString()
        {
            return $"testID :{testID} , patient_test_id:{patient_test_id}, SubTestID:{SubTestID} ,patient_id{patient_id} , ResultValue: {ResultValue} ";
        }

    }
}


 
