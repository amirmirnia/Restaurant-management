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
    public partial class register : MetroForm
    {
        public register()
        {
            InitializeComponent();
        }
        winlinqresturanDataContext dc = new winlinqresturanDataContext();
        classresturan claer = new classresturan();
        private void register_Load(object sender, EventArgs e)
        {

            var s = dc.Tableregisters.Count();
            if (s==0)
            {
                s++;
                registeresterak.Text = s.ToString();
            }
            else
            {
                var maxkey = dc.Tableregisters.Max(x => x.subscription);
                maxkey++;
                registeresterak.Text = maxkey.ToString();
            }

        }

        private void registerbuttom_Click(object sender, EventArgs e)
        {
            if (registerfirstname.Text == "" || registerlastname.Text == "" || registeraddres.Text == "" || registermobile.Text == "" || registertel.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this,"لطفا اطلاعات را کامل وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                registerfirstname.Text= registerlastname.Text= registeraddres.Text= registermobile.Text= registertel.Text="";
                registerfirstname.Focus();
            }
            else
            {


                
                Tableregister adduser = new Tableregister();
                adduser.firstname = registerfirstname.Text;
                adduser.lastname = registerlastname.Text;
                adduser.subscription = int.Parse(registeresterak.Text);
                adduser.tel = registertel.Text;
                adduser.mobile = registermobile.Text;
                adduser.addres = registeraddres.Text;
                dc.Tableregisters.InsertOnSubmit(adduser);
                dc.SubmitChanges();
                registerfirstname.Text = registerlastname.Text = registeraddres.Text = registermobile.Text = registertel.Text = "";
                registerfirstname.Focus();
                var maxofkey = dc.Tableregisters.Max(x => x.subscription);
                maxofkey++;
                registeresterak.Text = maxofkey.ToString();

            }
        }
        private void registerfirstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void registerfirstname_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo fr = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(fr);
        }

        private void registertel_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo en = new System.Globalization.CultureInfo("en");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(en);
        }
    }
}
