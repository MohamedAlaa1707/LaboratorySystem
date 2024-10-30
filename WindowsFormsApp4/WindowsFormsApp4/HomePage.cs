using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class HomePage : Form
    {
        private Size OriginalSize;
        private Dictionary<Control, Rectangle> OriginalControlSizes = new Dictionary<Control, Rectangle>();
        private const double ButtonSizeReductionRatio = 0.5; // نسبة تصغير ارتفاع الأزرار
        private const double ButtonWidthReductionRatio = 0.8; // نسبة تصغير عرض الأزرار
        private const int LabelTopPadding = 30; // المسافة من أعلى الفورم إلى الـ Label
        public bool role;

        public HomePage()
        {
            InitializeComponent();
            // Set form to be maximized on startup
            this.WindowState = FormWindowState.Maximized;

            // Save original size of the form
            OriginalSize = this.ClientSize;

            // Save original size and location of each control
            foreach (Control ctrl in this.Controls)
            {
                OriginalControlSizes[ctrl] = ctrl.Bounds;
            }

            // Attach the Resize event to the ResizeControls method
            this.Resize += ResizeControls;
            GlobalKeyHandler.RegisterGlobalShortcuts(this);
        }

        private void ResizeControls(object sender, EventArgs e)
        {
            // Calculate change ratios for width and height
            double xRatio = (double)this.ClientSize.Width / OriginalSize.Width;
            double yRatio = (double)this.ClientSize.Height / OriginalSize.Height;

            // Resize and reposition each control based on the change ratios
            foreach (Control ctrl in this.Controls)
            {
                Rectangle originalBounds = OriginalControlSizes[ctrl];

                if (ctrl is PictureBox pictureBox)
                {
                    // Center the PictureBox in the middle of the form
                    pictureBox.Left = (int)(originalBounds.Left * xRatio);
                    pictureBox.Top = (int)(originalBounds.Top * yRatio);
                    pictureBox.Width = (int)(originalBounds.Width * xRatio);
                    pictureBox.Height = (int)(originalBounds.Height * yRatio);

                    // Note: Circular mask code removed
                }
                else if (ctrl.Name == "button5")
                {
                    // Position the exit button at the bottom right corner
                    ctrl.Left = this.ClientSize.Width - (int)(originalBounds.Width * xRatio) - 10; // 10px padding
                    ctrl.Top = this.ClientSize.Height - (int)(originalBounds.Height * yRatio) - 10; // 10px padding
                }
                else if (ctrl.Name == "panel1" || ctrl.Name == "panel2")
                {
                    // Move the panels 100 pixels to the right
                    ctrl.Left = (int)(originalBounds.Left * xRatio) + 100; // Move 100 pixels to the right
                    ctrl.Top = (int)(originalBounds.Top * yRatio);
                    ctrl.Width = (int)(originalBounds.Width * xRatio);
                    ctrl.Height = (int)(originalBounds.Height * yRatio);

                    // Adjust the buttons within the panel
                    if (ctrl is Panel panel)
                    {
                        AdjustButtonsInPanel(panel, yRatio);

                        // Center the Label in Panel2
                        if (panel.Name == "panel2")
                        {
                            foreach (Control c in panel.Controls)
                            {
                                if (c is Label label)
                                {
                                    // Increase the font size of the label
                                    label.Font = new Font(label.Font.FontFamily, label.Font.Size * 1.2f); // Increase font size by 20%

                                    // Center the label horizontally
                                    label.Left = (panel.Width - label.Width) / 2;
                                    // Position the label slightly away from the top
                                    label.Top = LabelTopPadding; // Adjust this value as needed
                                }
                            }
                        }
                    }
                }
                else
                {
                    // General resizing for other controls
                    ctrl.Left = (int)(originalBounds.Left * xRatio);
                    ctrl.Top = (int)(originalBounds.Top * yRatio);
                    ctrl.Width = (int)(originalBounds.Width * xRatio);
                    ctrl.Height = (int)(originalBounds.Height * yRatio);
                }
            }
        }

        private void AdjustButtonsInPanel(Panel panel, double yRatio)
        {
            List<Button> buttons = new List<Button>();
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Button button)
                {
                    buttons.Add(button);
                }
            }

            // Sort buttons based on the predefined order
            buttons = buttons.OrderBy(b =>
            {
                switch (b.Name)
                {
                    case "button1": return 1;
                    case "button2": return 2;
                    case "button4": return 3;
                    case "button3": return 4;
                    case "setting": return 5;
                    default: return 6; // Default case for any other buttons
                }
            }).ToList();

            int buttonCount = buttons.Count;
            if (buttonCount > 0)
            {
                int availableHeight = panel.Height;
                int buttonHeight = (int)((availableHeight - (10 * (buttonCount - 1))) / buttonCount * ButtonSizeReductionRatio); // 10px padding between buttons

                int currentTop = 0; // Start from the top
                foreach (Button button in buttons)
                {
                    button.Top = currentTop;
                    button.Height = (int)(buttonHeight * yRatio);
                    button.Left = (int)(panel.Width * (1 - ButtonWidthReductionRatio) / 2); // Centered with padding on left and right
                    button.Width = (int)(panel.Width * ButtonWidthReductionRatio); // Reduced width
                    currentTop += button.Height + 50; // Move to next position with padding
                }
            }
        }

        private void Alyom_Click(object sender, EventArgs e)
        {
            // Event handler code here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectRegisteration d = new DirectRegisteration(this);
            d.Size = this.Size;
            d.StartPosition = FormStartPosition.Manual;
            d.Location = this.Location;
            d.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Event handler code here
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnterResults er = new EnterResults(this);
            er.Size = this.Size;
            er.StartPosition = FormStartPosition.Manual;
            er.Location = this.Location;
            er.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowResults er = new ShowResults(this);
            er.Size = this.Size;
            er.StartPosition = FormStartPosition.Manual;
            er.Location = this.Location;
            er.Show();
            this.Hide();
        }

        private void setting_Click(object sender, EventArgs e)
        {
            checksetting Mg = new checksetting(this, "MT");
            Mg.Size = this.Size;
            Mg.StartPosition = FormStartPosition.Manual;
            Mg.Location = this.Location;
            Mg.Show();
            this.Hide();


           
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            // Event handler code here

            if (role== true)
            {
                setting.Hide();
            }

        }

        
    }
}
