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
    public partial class insertname : MetroFramework.Forms.MetroForm
    {
        public insertname()
        {
            InitializeComponent();
        }
        winlinqresturanDataContext db = new winlinqresturanDataContext();
        private void insertname_Load(object sender, EventArgs e)
        {
            var g = db.Tableinsertlabels.FirstOrDefault(x => x.id == 1);
            if (g!=null)
            {
                insertnamefish.Text = g.name;
                adresshop.Text = g.adres;
            }
        }

        private void insertnamefiseh_Click(object sender, EventArgs e)
        {
            
            var f = db.Tableinsertlabels.FirstOrDefault(x=>x.id==1);
            if (insertnamefish.Text==null)
            {
                MetroFramework.MetroMessageBox.Show(this, "عنوان را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (f==null)
                {
                    Tableinsertlabel cm = new Tableinsertlabel();
                    cm.id = 1;
                    cm.name = insertnamefish.Text;
                    cm.adres = adresshop.Text;
                    db.Tableinsertlabels.InsertOnSubmit(cm);
                    db.SubmitChanges();
                    MetroFramework.MetroMessageBox.Show(this, "ثبت شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    f.name= insertnamefish.Text;
                    f.adres = adresshop.Text;
                    db.SubmitChanges();
                    MetroFramework.MetroMessageBox.Show(this, "ثبت شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Close();
        }

        private void insertnamefish_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo fr = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(fr);
        }
    }
}
