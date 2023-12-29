using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program_resturan
{
    public partial class tableuser : MetroForm
    {
        winlinqresturanDataContext dc = new winlinqresturanDataContext();
        public tableuser()
        {
            InitializeComponent();
        }
        
        private void tableuser_Load(object sender, EventArgs e)
        {
            metroGridtableuser.DataSource = dc.Tableregisters.ToList();
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchname.Text == "" && searchestrak.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "اشتراک یا نام خانوادگی را وارد کنید ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (searchestrak.Text == "")
                {
                    metroGridtableuser.DataSource = dc.Tableregisters.Where(x => x.lastname == searchname.Text).ToList();

                }
                else if (searchname.Text == "")
                {
                    metroGridtableuser.DataSource = dc.Tableregisters.Where(x => x.subscription == int.Parse(searchestrak.Text)).ToList();

                }
                else
                {
                    metroGridtableuser.DataSource = dc.Tableregisters.Where(x => x.subscription == int.Parse(searchestrak.Text)).ToList();

                }
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "اشتراک یا نام خانوادگی را وارد کنید ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }





        }

        private void refresh_Click(object sender, EventArgs e)
        {
            metroGridtableuser.DataSource = dc.Tableregisters.ToList();
        }
    }
}
