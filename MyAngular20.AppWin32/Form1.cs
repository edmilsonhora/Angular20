using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAngular20.AppWin32
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkin.MaterialSkinManager manager;
        public Form1()
        {
            InitializeComponent();
            manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.EnforceBackcolorOnAllComponents = true;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500,
                                                               MaterialSkin.Primary.Indigo700, 
                                                               MaterialSkin.Primary.Indigo100, 
                                                               MaterialSkin.Accent.Pink200, 
                                                               MaterialSkin.TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            UserControl1 uc1 = new UserControl1();
            uc1.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(uc1);
            uc1.BringToFront();
        }
    }
}
