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
using static System.Windows.Forms.DataFormats;

namespace program_resturan
{
    public partial class insertfood : MetroForm
    {
       
        winlinqresturanDataContext dc = new winlinqresturanDataContext();
        public insertfood()
        {
            InitializeComponent();
        }

        private void insertfood_Load(object sender, EventArgs e)
        {
            metroGridinsertfood.DataSource = dc.Tableinsertfoods.ToList();
            
           

            var count = dc.Tableinsertfoods.Count();
            if (count == 0)
            {
                count++;
                metroLabelcodefood.Text = count.ToString();
            }
            else
            {
                var maxkey = dc.Tableinsertfoods.Max(x => x.code);
                maxkey++;
                metroLabelcodefood.Text = maxkey.ToString();
            }
        }

        private void metroinsertfood(object sender, EventArgs e)
        {


            string typ = "";
            if (insertfoodfee.Text == "" || insertnamefood.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "تمام اطلاعات را کامل کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Tableinsertfood em = new Tableinsertfood();



                if (food1.Checked)
                {
                    typ = "1";
                }
                else if (food2.Checked)
                {
                    typ = "2";
                }
                else
                {
                    typ = "3";
                }

                em.code = int.Parse(metroLabelcodefood.Text);
                em.fee = insertfoodfee.Text;
                em.namefood = insertnamefood.Text;
                em.typefood = int.Parse(typ);
                dc.Tableinsertfoods.InsertOnSubmit(em);
                dc.SubmitChanges();
                MetroFramework.MetroMessageBox.Show(this, "برای قرار گرفتن اطلاعات در منو باید از برنامه خارج شوید و دوباره وارد شوید", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Question);
                insertfoodfee.Text = insertnamefood.Text = "";
                insertfoodfee.Focus();
                metroGridinsertfood.DataSource = dc.Tableinsertfoods.ToList();

                //this._haschanged = true;



            }

            var maxkey = dc.Tableinsertfoods.Max(x => x.code);
            maxkey++;
            metroLabelcodefood.Text = maxkey.ToString();

         
        }
        private void insertnamefood_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo fr = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(fr);
        }

        private void insertcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void insertfoodfee_Leave(object sender, EventArgs e)
        {
            
            
        }

        private void insertfoodfee_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void metroProgressSpinner1_Click(object sender, EventArgs e)
        {
            
        }

        private void insertnamefood_Click(object sender, EventArgs e)
        {

        }

        private void deletefood_Click(object sender, EventArgs e)
        {
            if (codefooddelete.Text=="")
            {
                MetroFramework.MetroMessageBox.Show(this, "کد غذا مربوط را وارد کنید ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                try
                {
                    var cm = dc.Tableinsertfoods.FirstOrDefault(x => x.code == int.Parse(codefooddelete.Text));
                    if (cm == null)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "چنین کدی موجود نیست ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    else
                    {
                        dc.Tableinsertfoods.DeleteOnSubmit(cm);
                        dc.SubmitChanges();
                        MetroFramework.MetroMessageBox.Show(this, "غذا از منو شما حذف شد ", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MetroFramework.MetroMessageBox.Show(this, "قیمت بروز شد\nجهت به روز شدن از برنامه خارج شوید و دوباره وارد شوید ", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        metroGridinsertfood.DataSource = dc.Tableinsertfoods.ToList();
                    }
                }
                catch 
                {
                    MetroFramework.MetroMessageBox.Show(this, "کد غذا مربوط را وارد کنید ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                   
                }
                


            }
        }

        private void insertnewmony_Click(object sender, EventArgs e)
        {
            if (codefooddelete.Text==""||newmony.Text=="")
            {
                MetroFramework.MetroMessageBox.Show(this, "کدیا قیمت جدید غذا مربوط را وارد کنید ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

            else
            {
                var ne = dc.Tableinsertfoods.FirstOrDefault(x=>x.code==int.Parse(codefooddelete.Text));
                ne.fee = newmony.Text;
                dc.SubmitChanges();
                MetroFramework.MetroMessageBox.Show(this, "قیمت بروز شد\nجهت به روز شدن از برنامه خارج شوید و دوباره وارد شوید ", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metroGridinsertfood.DataSource = dc.Tableinsertfoods.ToList();

            }
        }
    }
}
