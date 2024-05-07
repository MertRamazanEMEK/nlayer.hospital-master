using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.PropertyGridInternal;
using System.Windows.Forms.VisualStyles;

namespace hastane
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            foreach (Form form in Application.OpenForms)
            {
                form.BackColor = System.Drawing.Color.Blue;
            }
            Application.Run(new Presentation.Giris1());
        }
    }
}
