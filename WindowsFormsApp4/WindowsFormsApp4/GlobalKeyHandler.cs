using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public class GlobalKeyHandler
    {
        public static void RegisterGlobalShortcuts(Form form)
        {
            form.KeyDown += Form_KeyDown;
            form.KeyPreview = true; 
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.Control && e.KeyCode == Keys.F4)
            {
                Application.Exit(); 
            }
        }
    }
}
