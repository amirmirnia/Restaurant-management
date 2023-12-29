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
    public partial class update : MetroForm
    {
        public update()
        {
            InitializeComponent();
        }
        winlinqresturanDataContext dc = new winlinqresturanDataContext();
        private void update_Load(object sender, EventArgs e)
        {

        }

        private void updatebuttom_Click(object sender, EventArgs e)
        {
            string candidate = updateinsertestrak.Text;
            if (candidate == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "کد اشتراک را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateinsertestrak.Text = "";
                updateinsertestrak.Focus();
                return;
            }

            else
            {
                if (metroToggleesterak.Checked == true)
                {





                    Tableregister em = dc.Tableregisters.FirstOrDefault(x => x.subscription == int.Parse(updateinsertestrak.Text));



                    if (updatefirstname.Text == "" || updatelastname.Text == "" || updateaddres.Text == "" || updatetel.Text == "" || updatemobile.Text == "")
                    {
                        MetroFramework.MetroMessageBox.Show(this, "اطلاعات را کامل کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        updatefirstname.Text = em.firstname;
                        updatelastname.Text = em.lastname;
                        updatetel.Text = em.tel;
                        updatemobile.Text = em.mobile;
                        updateaddres.Text = em.addres;

                        return;
                    }
                    else
                    {
                        em.firstname = updatefirstname.Text;
                        em.lastname = updatelastname.Text;
                        em.tel = updatetel.Text;
                        em.mobile = updatemobile.Text;
                        em.addres = updateaddres.Text;
                        dc.SubmitChanges();
                        updatefirstname.Text = updatelastname.Text = updatetel.Text = updatemobile.Text = updateaddres.Text = "";
                        metroToggleesterak.Checked = false;
                        updateinsertestrak.Text = "";
                        updateinsertestrak.Focus();

                    }
                }

                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "لطفا گزینه را فعال کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    updateinsertestrak.Text = "";
                    updateinsertestrak.Focus();
                    return;
                }

            }



        }

        private void metroToggleesterak_CheckedChanged(object sender, EventArgs e)
        {
            string candidate = updateinsertestrak.Text;

            if (candidate == "")
            {
                if (metroToggleesterak.Checked == true)
                {
                    MetroFramework.MetroMessageBox.Show(this, "کد اشتراک را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                metroToggleesterak.Checked = false;
                updateinsertestrak.Text = "";
                updateinsertestrak.Focus();



                return;
            }

            else
            {


                double num;
                if (double.TryParse(candidate, out num))
                {

                    Tableregister em = dc.Tableregisters.FirstOrDefault(x => x.subscription == int.Parse(updateinsertestrak.Text));

                    if (em == null)
                    {
                        if (metroToggleesterak.Checked == true)
                        {

                            MetroFramework.MetroMessageBox.Show(this, "جنین اشتراکی وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        metroToggleesterak.Checked = false;
                        updateinsertestrak.Text = "";
                        updateinsertestrak.Focus();
                        return;
                    }
                    else
                    {
                        if (metroToggleesterak.Checked == true)
                        {
                            updatefirstname.Text = em.firstname;
                            updatelastname.Text = em.lastname;
                            updatetel.Text = em.tel;
                            updatemobile.Text = em.mobile;
                            updateaddres.Text = em.addres;
                        }
                        else
                        {
                            updatefirstname.Text = "";
                            updatelastname.Text = "";
                            updatetel.Text = "";
                            updatemobile.Text = "";
                            updateaddres.Text = "";
                        }






                    }

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "کد اشتراک را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    updateinsertestrak.Text = "";
                    updateinsertestrak.Focus();

                    return;
                }


            }
        }

        private void updateinsertestrak_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo en = new System.Globalization.CultureInfo("en");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(en);
        }

        private void updatefirstname_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo fr = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(fr);
        }

        private void updateinsertestrak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void updateinsertestrak_Click(object sender, EventArgs e)
        {

        }
    }
}
