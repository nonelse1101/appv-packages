using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppV_Packages
{
    public partial class frmConnection : Form
    {
        public frmConnection()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            
            if (txtServer.Text != "")
            {
                AppV_Packages.Properties.Settings.Default.UserConnectionString = @"Data Source=" + txtServer.Text + ";Initial Catalog=" + txtCatalog.Text + ";Integrated Security=True";
                AppV_Packages.Properties.Settings.Default.Save();
            }
            this.Close();
        }


    }
}
