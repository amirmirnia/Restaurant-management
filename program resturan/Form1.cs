using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program_resturan
{
    public partial class form1 : MetroFramework.Forms.MetroForm
    {

        public form1()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        int ch1cash = 0;
        int ch2cash = 0;
        int ch3cash = 0;
        int chtotalcash = 0;
        static int somare = 0;
        TextBox chk = new TextBox();
        winlinqresturanDataContext dc = new winlinqresturanDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {

            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(4000, "برنامه مدیریت رستوران", "خوش امدید", ToolTipIcon.None);
            notifyIcon1.Text = "جهت خروج کلیک کنید";


            date.Text = DateTime.Now.ToPeString("dddd, dd MMMM,yyyy");
            time.Text = DateTime.Now.ToShortTimeString();

            dt.Columns.Add("نام غذا");
            dt.Columns.Add("تعداد");
            dt.Columns.Add("(واحد)قیمت");
            metroGridfood.DataSource = dt;

            metroTabseleckfood.SelectedTab = metroTabPage1;

            var count = dc.Tableinsertfoods.Count();
            if (count == 0)
            {
                count = dc.Tableinsertfoods.Count();
            }
            else
            {
                count = dc.Tableinsertfoods.Max(x => x.code);
            }
            for (int i = 1; i <= count; i++)
            {
                Tableinsertfood em = dc.Tableinsertfoods.FirstOrDefault(x => x.code == i);
                if (em != null)
                {
                    if (em.typefood == 1)
                    {

                        checkedListBox1.Items.Add(em.namefood);
                    }
                    else if (em.typefood == 2)
                    {
                        checkedListBox2.Items.Add(em.namefood);
                    }
                    else
                    {
                        checkedListBox3.Items.Add(em.namefood);
                    }
                }



            }



            metroTabPage1.Text = "غذا";
            metroTabPage1.Name = "food1";
            metroTabPage2.Text = "پیش غذا";
            metroTabPage2.Name = "food2";
            metroTabPage3.Text = "نوشیدنی";
            metroTabPage3.Name = "food3";




        }




        private void finalselectfood_Click(object sender, EventArgs e)
        {

            foreach (var item in checkedListBox1.CheckedItems)
            {

                string nam = item.ToString();
                Tableinsertfood cm = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == nam);
                String p = (cm.code).ToString();

                TextBox tbx = this.Controls.Find(p, true).FirstOrDefault() as TextBox;
                if (tbx.Text == "")
                {
                    dt.Rows.Add(nam, "1", cm.fee);
                    metroGridfood.DataSource = dt;
                    ch1cash += int.Parse((cm.fee));
                }
                else
                {
                    dt.Rows.Add(nam, tbx.Text, cm.fee);
                    metroGridfood.DataSource = dt;
                    ch1cash += int.Parse((cm.fee)) * int.Parse((tbx.Text));
                }


            }

            ////////-------------------------------------------------
            foreach (var item in checkedListBox2.CheckedItems)
            {
                string nam = item.ToString();
                Tableinsertfood cm = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == nam);
                String p = (cm.code).ToString();

                TextBox tbx = this.Controls.Find(p, true).FirstOrDefault() as TextBox;
                if (tbx.Text == "")
                {
                    dt.Rows.Add(nam, "1", cm.fee);
                    metroGridfood.DataSource = dt;
                    ch2cash += int.Parse((cm.fee));
                }
                else
                {
                    dt.Rows.Add(nam, tbx.Text, cm.fee);
                    metroGridfood.DataSource = dt;
                    ch2cash += int.Parse((cm.fee)) * int.Parse((tbx.Text));
                }

            }
            ////////---------------------------------------------------------
            foreach (var item in checkedListBox3.CheckedItems)
            {
                string nam = item.ToString();
                Tableinsertfood cm = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == nam);
                String p = (cm.code).ToString();

                TextBox tbx = this.Controls.Find(p, true).FirstOrDefault() as TextBox;
                if (tbx.Text == "")
                {
                    dt.Rows.Add(nam, "1", cm.fee);
                    metroGridfood.DataSource = dt;
                    ch3cash += int.Parse((cm.fee));
                }
                else
                {
                    dt.Rows.Add(nam, tbx.Text, cm.fee);
                    metroGridfood.DataSource = dt;
                    ch3cash += int.Parse((cm.fee)) * int.Parse((tbx.Text));
                }

            }

            chtotalcash = ch1cash + ch2cash + ch3cash;
            dt.Rows.Add("", "قیمت کل", chtotalcash);
            metroGridfood.DataSource = dt;
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            int intialTop = 110;
            foreach (var item in checkedListBox1.Items)
            {



                TextBox chk = new TextBox();
                Label chk1 = new Label();
                string name = item.ToString();
                Tableinsertfood em = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == name);
                chk.Top = intialTop;
                chk1.Top = intialTop;
                chk.Left = 1090;
                chk.Width = 25;
                chk1.Left = 1120;
                chk1.ForeColor = Color.White;
                chk.Name = (em.code).ToString();
                chk1.Text = name;
                this.Controls.Add(chk1);
                this.Controls.Add(chk);
                intialTop += 20;

            }




        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intialTop = 110;

            foreach (var item in checkedListBox2.Items)
            {

                TextBox chk = new TextBox();
                string name = item.ToString();
                Tableinsertfood em = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == name);

                Label chk1 = new Label();
                chk.Top = intialTop;
                chk1.Top = intialTop;
                chk.Left = 950;
                chk.Width = 25;
                chk1.Left = 990;
                chk1.ForeColor = Color.White;
                chk.Name = (em.code).ToString();
                chk1.Text = name;
                this.Controls.Add(chk1);
                this.Controls.Add(chk);
                intialTop += 20;
            }
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intialTop = 110;

            foreach (var item in checkedListBox3.Items)
            {

                TextBox chk = new TextBox();
                string name = item.ToString();
                Tableinsertfood em = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == name);

                Label chk1 = new Label();
                chk.Top = intialTop;
                chk1.Top = intialTop;
                chk.Left = 820;
                chk.Width = 25;
                chk1.Left = 850;
                chk1.ForeColor = Color.White;
                chk.Name = (em.code).ToString();
                chk1.Text = name;
                this.Controls.Add(chk1);
                this.Controls.Add(chk);
                intialTop += 20;
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (metroRadiosend2.Checked || metroRadiosend3.Checked)
            {
                somare += 1;
            }
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            string title = Application.StartupPath + "\\logo.jpg";
            string barcode = Application.StartupPath + "\\code128bar.jpg";
            Graphics g = e.Graphics;
            Graphics es = e.Graphics;
            Font fBody = new Font("Lucida Console", 25, FontStyle.Bold);
            Font fBodytime = new Font("Lucida Console", 25, FontStyle.Bold);
            Font fBodytimeheader = new Font("Lucida Console", 18, FontStyle.Bold);
            Font fBody1 = new Font("Lucida Console", 15, FontStyle.Regular);
            Font rs = new Font("Stencil", 25, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(Color.Black);
            int counthight = metroGridfood.Rows.Count;
            string[] hafez = { "راهیست راه عشـــق کـــه هیچش کـــــناره نیست \nان جـــا جــز آن کـــه جـان بسپارند چـاره نیس", "هـــر آن کــــه جانب اهـــل خدا نگــه دارد\n خداش در همـــه حـــال از بلا نگــــــه دارد", "چو بشنوی سخن اهل دل مگو که خطاست \nسخن شناس نه‌ای جان من خطا این جاست", "المــــنه لله کـــــــه در مــیکـــــده باز است \nکـــــه مـــــــــرا بــــر در او روی نیــــاز است", "حـالیـــا مـــصلحـــت وقــت در آن مـــی‌بـیـنـــم\n که کشم رخت به میخانه و خوش بنشینــم" };
            Random rnd = new Random();
            var time = DateTime.Now.ToPeString("dddd, dd MMMM,yyyy");
            var time2 = DateTime.Now.ToShortTimeString();
            g.DrawString(time, fBodytimeheader, sb, 10, 60);
            g.DrawString(time2, fBodytimeheader, sb, 42, 89);
            g.DrawString("شماره", fBody, sb, 420 + 220, 60);
            g.DrawString((somare).ToString(), fBody, sb, 360 + 220, 60);
            es.DrawRectangle(Pens.Black, 340 + 220, 50, 80, 40);
            g.DrawImage(Image.FromFile(title), 166 + 167, 7);
            var f = dc.Tableinsertlabels.FirstOrDefault(x => x.id == 1);
            if (f != null)
            {
                g.DrawString(f.name, fBody, sb, 170 + 167, 170);
                g.DrawString("-------------------------------------------------------------", fBody1, sb, 10, 195);

            }
            else
            {
                g.DrawString("*************************************************************", fBody1, sb, 10, 170);

            }
            int haf = rnd.Next(1, 5);

            if (metroRadiosend3.Checked)
            {

                if (counthight >= 2)
                {
                    counthight = counthight - 2;
                    int height = counthight * 30;
                    g.DrawRectangle(Pens.Black, 5, 5, 815, 850 + height);
                    g.DrawString("********************فال حافظ******************", fBody1, sb, 814, 398 + height, format);
                    g.DrawString(hafez[haf], fBody, sb, 814, 440 + height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 512 + height, format);
                    g.DrawString("مشتری می برد", fBody, sb, 814, 550 + height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 580 + height, format);
                    g.DrawString("با تشکر از حسن خرید شما", fBody, sb, 814, 600 + height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 630 + height, format);
                    if (f != null)
                    {
                        g.DrawString(f.adres, fBody, sb, 814, 650 + height, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 686 + height, format);

                    }
                    else
                    {
                        g.DrawString("ادرسی ثبت نشد", fBody, sb, 814, 650 + height, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 686 + height, format);

                    }
                    g.DrawImage(Image.FromFile(barcode), 85 + 167, 720 + height);
                    g.DrawString("سید امیر حسین میرنیا-09114596785", fBodytimeheader, sb, 130 + 130, 830 + height);

                }
                else
                {
                    g.DrawRectangle(Pens.Black, 5, 5, 815, 850);
                    g.DrawString("*******************فال حافظ*******************", fBody1, sb, 814, 398 , format);
                    g.DrawString(hafez[haf], fBody, sb, 814, 440, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 512 , format);
                    g.DrawString("مشتری می برد", fBody, sb, 814, 550, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 580, format);
                    g.DrawString("با تشکر از حسن خرید شما", fBody, sb, 814, 600 , format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 630 , format);
                    if (f != null)
                    {
                        g.DrawString(f.adres, fBody, sb, 814, 650);
                        g.DrawString("**********************************************", fBody1, sb, 814, 686, format);

                    }
                    else
                    {
                        g.DrawString("ادرسی ثبت نشد", fBody, sb, 814, 650, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 686, format);

                    }
                    g.DrawImage(Image.FromFile(barcode), 85 + 167, 720);
                    g.DrawString("سید امیر حسین میرنیا-09114596785", fBodytimeheader, sb, 130 + 130, 830);


                }







                int count = metroGridfood.Rows.Count - 1;
                int k = 0;
                int hightrow = 270;
                Graphics h = e.Graphics;
                h.DrawRectangle(Pens.Black, 5, 215, 814, 50);
                g.DrawString("نام غذا", fBody, sb, 320 + 400, 220);
                g.DrawString("تعداد", fBody, sb, 170 + 200, 220);
                g.DrawString("قیمت", fBody, sb, 20 + 40, 220);
                //Pen p = new Pen(Color.Black);

                //g.DrawLine(p,300,50,80,50);
                int t = 265;
                foreach (DataGridViewRow row in metroGridfood.Rows)
                {
                    int r = 320;
                    if (k == count - 1)
                    {
                        string last = metroGridfood.Rows[count - 1].Cells["تعداد"].Value.ToString();
                        if (last == "قیمت کل")
                        {
                            h.DrawRectangle(Pens.Black, 5, t, 430, 50);

                        }
                    }


                    else
                    {
                        if (k == count)
                        {
                            return;
                        }
                        h.DrawRectangle(Pens.Black, 5, t, 814, 50);
                    }


                    int p = 500;
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        string value = cell.Value.ToString();
                        g.DrawString(value, fBody, sb, r + p, hightrow, format);
                        r = r - 200;
                        p -= 200;
                        if (p == 100)
                        {
                            p = 230;
                        }

                    }
                    t = t + 50;
                    hightrow = hightrow + 50;
                    k++;


                }


            }//میل کند
            else if (metroRadiosend2.Checked)
            {

                if (counthight >= 2)
                {
                    counthight = counthight - 2;
                    int height = counthight * 30;
                    g.DrawRectangle(Pens.Black, 5, 5, 815, 850 + height);
                    g.DrawString(name.Text, fBody, sb, 814, 360 + height, format);
                    g.DrawString("*******************فال حافظ*******************", fBody1, sb, 814, 398 + height, format);
                    g.DrawString(hafez[haf], fBody, sb, 814, 440 + height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 512 + height, format);
                    g.DrawString("در مغازه صرف می شود", fBody, sb, 814, 550 + height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 580 + height, format);
                    g.DrawString("با تشکر از حسن خرید شما", fBody, sb, 814, 600 + height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 630 + height, format);
                    if (f != null)
                    {
                        g.DrawString(f.adres, fBody, sb, 814, 650 + height, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 686 + height, format);

                    }
                    else
                    {
                        g.DrawString("ادرسی ثبت نشد", fBody, sb, 814, 650 + height, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 686 + height, format);

                    }
                    g.DrawImage(Image.FromFile(barcode), 85 + 167, 720 + height);
                    g.DrawString("سید امیر حسین میرنیا-09114596785", fBodytimeheader, sb, 130 + 130, 830 + height);

                }
                else
                {
                    g.DrawRectangle(Pens.Black, 5, 5, 815, 850);
                    g.DrawString(name.Text, fBody, sb, 814, 360, format);
                    g.DrawString("*******************فال حافظ*******************", fBody1, sb, 814, 398 , format);
                    g.DrawString(hafez[haf], fBody, sb, 814, 440 , format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 512 , format);
                    g.DrawString("در مغازه صرف می شود", fBody, sb, 814, 550 , format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 580, format);
                    g.DrawString("با تشکر از حسن خرید شما", fBody, sb, 814, 600 , format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 630 , format);
                    if (f != null)
                    {
                        g.DrawString(f.adres, fBody, sb, 814, 650);
                        g.DrawString("**********************************************", fBody1, sb, 814, 686, format);

                    }
                    else
                    {
                        g.DrawString("ادرسی ثبت نشد", fBody, sb, 814, 650, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 686, format);

                    }
                    g.DrawImage(Image.FromFile(barcode), 85 + 167, 720);
                    g.DrawString("سید امیر حسین میرنیا-09114596785", fBodytimeheader, sb, 130 + 130, 830);


                }







                int count = metroGridfood.Rows.Count - 1;
                int k = 0;
                int hightrow = 270;
                Graphics h = e.Graphics;
                h.DrawRectangle(Pens.Black, 5, 215, 814, 50);
                //g.DrawString("تعداد", fBody, sb, 430, 220);
                g.DrawString("نام غذا", fBody, sb, 320 + 400, 220);
                g.DrawString("تعداد", fBody, sb, 170 + 200, 220);
                g.DrawString("قیمت", fBody, sb, 20 + 40, 220);
                //Pen p = new Pen(Color.Black);

                //g.DrawLine(p,300,50,80,50);
                int t = 265;
                foreach (DataGridViewRow row in metroGridfood.Rows)
                {
                    int r = 320;
                    if (k == count - 1)
                    {
                        string last = metroGridfood.Rows[count - 1].Cells["تعداد"].Value.ToString();
                        if (last == "قیمت کل")
                        {
                            h.DrawRectangle(Pens.Black, 5, t, 430, 50);

                        }
                    }


                    else
                    {
                        if (k == count)
                        {
                            return;
                        }
                        h.DrawRectangle(Pens.Black, 5, t, 814, 50);
                    }


                    int p = 500;
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        string value = cell.Value.ToString();
                        g.DrawString(value, fBody, sb, r + p, hightrow, format);
                        r = r - 200;
                        p -= 200;
                        if (p == 100)
                        {
                            p = 230;
                        }
                    }
                    t = t + 50;
                    hightrow = hightrow + 50;
                    k++;


                }
            }
            else
            {

                if (counthight >= 2)
                {
                    counthight = counthight - 2;
                    int height = counthight * 30;
                    g.DrawRectangle(Pens.Black, 5, 5, 815, 870 + height);
                    g.DrawString(phonenumber.Text + "" + name.Text, fBody, sb, 814, 360+height, format);
                    g.DrawString(addres.Text, fBody, sb, 814, 389+height, format);
                    g.DrawString("*******************فال حافظ*******************", fBody1, sb, 814, 427+height, format);
                    g.DrawString(hafez[haf], fBody, sb, 814, 460+height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 552+height, format);
                    g.DrawString("ارسال به منزل مشتری", fBody, sb, 814, 570 + height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 600 + height, format);
                    g.DrawString("با تشکر از حسن خرید شما", fBody, sb, 814, 620 + height, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 650 + height, format);
                    if (f != null)
                    {
                        g.DrawString(f.adres, fBody, sb, 814, 670 + height, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 706 + height, format);

                    }
                    else
                    {
                        g.DrawString("ادرسی ثبت نشد", fBody, sb, 814, 670 + height, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 706 + height, format);

                    }
                    g.DrawImage(Image.FromFile(barcode), 85 + 167, 740 + height);
                    g.DrawString("سید امیر حسین میرنیا-09114596785", fBodytimeheader, sb, 130 + 130, 850 + height);

                }
                else
                {
                    g.DrawRectangle(Pens.Black, 5, 5, 815, 870);
                    g.DrawString(phonenumber.Text + "" + name.Text, fBody, sb, 814, 360 , format);
                    g.DrawString(addres.Text, fBody, sb, 814, 389 , format);
                    g.DrawString("*******************فال حافظ*******************", fBody1, sb, 814, 427 , format);
                    g.DrawString(hafez[haf], fBody, sb, 814, 460, format);
                    g.DrawString("**********************************************", fBody1, sb, 834, 512, format);
                    g.DrawString("ارسال به منزل مشتری", fBody, sb, 814, 570, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 600, format);
                    g.DrawString("با تشکر از حسن خرید شما", fBody, sb, 814, 620, format);
                    g.DrawString("**********************************************", fBody1, sb, 814, 650, format);
                    if (f != null)
                    {
                        g.DrawString(f.adres, fBody, sb, 814, 670);
                        g.DrawString("**********************************************", fBody1, sb, 814, 706, format);

                    }
                    else
                    {
                        g.DrawString("ادرسی ثبت نشد", fBody, sb, 814, 670, format);
                        g.DrawString("**********************************************", fBody1, sb, 814, 706, format);

                    }
                    g.DrawImage(Image.FromFile(barcode), 85 + 167, 740);
                    g.DrawString("سید امیر حسین میرنیا-09114596785", fBodytimeheader, sb, 130 + 130, 850);


                }







                int count = metroGridfood.Rows.Count - 1;
                int k = 0;
                int hightrow = 270;
                Graphics h = e.Graphics;
                h.DrawRectangle(Pens.Black, 5, 215, 814, 50);
                //g.DrawString("تعداد", fBody, sb, 430, 220);
                g.DrawString("نام غذا", fBody, sb, 320 + 400, 220);
                g.DrawString("تعداد", fBody, sb, 170 + 200, 220);
                g.DrawString("قیمت", fBody, sb, 20 + 40, 220);
                //Pen p = new Pen(Color.Black);

                //g.DrawLine(p,300,50,80,50);
                int t = 265;
                foreach (DataGridViewRow row in metroGridfood.Rows)
                {
                    int r = 320;
                    if (k == count - 1)
                    {
                        string last = metroGridfood.Rows[count - 1].Cells["تعداد"].Value.ToString();
                        if (last == "قیمت کل")
                        {
                            h.DrawRectangle(Pens.Black, 5, t, 430, 50);

                        }
                    }


                    else
                    {
                        if (k == count)
                        {
                            return;
                        }
                        h.DrawRectangle(Pens.Black, 5, t, 814, 50);
                    }



                    int p = 500;
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        string value = cell.Value.ToString();
                        g.DrawString(value, fBody, sb, r + p, hightrow, format);
                        r = r - 200;
                        p -= 200;
                        if (p == 100)
                        {
                            p = 230;
                        }

                    }
                    t = t + 50;
                    hightrow = hightrow + 50;
                    k++;


                }

            }
        }

        private void printGrid_Click(object sender, EventArgs e)
        {

            if (!metroRadiosend1.Checked && !metroRadiosend2.Checked && !metroRadiosend3.Checked)
            {
                MetroFramework.MetroMessageBox.Show(this, "نحوه ارسال را مشخص کنید ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {
                if (metroRadiosend1.Checked)
                {
                    if (name.Text == "" || addres.Text == "" || phonenumber.Text == "" || mobilenumber.Text == "")
                    {
                        MetroFramework.MetroMessageBox.Show(this, "برای ارسال بایدتمام اطلاعات را کامل شود ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        PrintDocument pd = new PrintDocument();
                        PaperSize ps = new PaperSize("", 475, 550);
                        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                        pd.PrintController = new StandardPrintController();
                        pd.DefaultPageSettings.Margins.Left = 0;
                        pd.DefaultPageSettings.Margins.Right = 0;
                        pd.DefaultPageSettings.Margins.Top = 0;
                        pd.DefaultPageSettings.Margins.Bottom = 0;
                        pd.DefaultPageSettings.PaperSize = ps;
                        pd.Print();
                    }
                }
                else
                {
                    PrintDocument pd = new PrintDocument();

                    PaperSize ps = new PaperSize("", 475, 550);
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                    pd.PrintController = new StandardPrintController();
                    pd.DefaultPageSettings.Margins.Left = 0;
                    pd.DefaultPageSettings.Margins.Right = 0;
                    pd.DefaultPageSettings.Margins.Top = 0;
                    pd.DefaultPageSettings.Margins.Bottom = 0;
                    pd.DefaultPageSettings.PaperSize = ps;
                    pd.Print();
                }
                esterak.Text = "";
                name.Text = "";
                addres.Text = "";
                phonenumber.Text = "";
                mobilenumber.Text = "";

                ch1cash = 0;
                ch2cash = 0;
                ch3cash = 0;
                chtotalcash = 0;


                try
                {
                    foreach (var item in checkedListBox1.Items)
                    {

                        string nam = item.ToString();
                        Tableinsertfood cm = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == nam);
                        String p = (cm.code).ToString();
                        TextBox tbx = this.Controls.Find(p, true).FirstOrDefault() as TextBox;
                        tbx.Text = "";

                    }

                    foreach (var item in checkedListBox2.Items)
                    {

                        string nam = item.ToString();
                        Tableinsertfood cm = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == nam);
                        String p = (cm.code).ToString();
                        TextBox tbx = this.Controls.Find(p, true).FirstOrDefault() as TextBox;
                        tbx.Text = "";

                    }
                    foreach (var item in checkedListBox3.Items)
                    {

                        string nam = item.ToString();
                        Tableinsertfood cm = dc.Tableinsertfoods.FirstOrDefault(x => x.namefood == nam);
                        String p = (cm.code).ToString();
                        TextBox tbx = this.Controls.Find(p, true).FirstOrDefault() as TextBox;
                        tbx.Text = "";

                    }
                }
                catch (Exception)
                {

                    MetroFramework.MetroMessageBox.Show(this, "ابتدا بر روی سه ایتم منو کلیک کرده تا تمام غذا ها برایتان نشان داده شود ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }




                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
                foreach (int i in checkedListBox2.CheckedIndices)
                {
                    checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
                }
                foreach (int i in checkedListBox3.CheckedIndices)
                {
                    checkedListBox3.SetItemCheckState(i, CheckState.Unchecked);
                }

                for (int i = metroGridfood.Rows.Count - 2; i >= 0; i--)
                {

                    metroGridfood.Rows.RemoveAt(i);
                }
            }


        }


        private void esterak_Click(object sender, EventArgs e)
        {

        }

        private void esterak_Leave(object sender, EventArgs e)
        {

            try
            {
                if (esterak.Text != "")
                {
                    int estrak = int.Parse(esterak.Text.ToString());
                    var cm = dc.Tableregisters.FirstOrDefault(x => x.subscription == estrak);
                    if (cm != null)
                    {
                        name.Text = cm.firstname + "_" + cm.lastname;
                        phonenumber.Text = cm.mobile;
                        mobilenumber.Text = cm.tel;
                        addres.Text = cm.addres;
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "چنین اشتراکی وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "اشتراک را وار کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {

                MetroFramework.MetroMessageBox.Show(this, "اشتراک را وار کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





        }

        private void esterak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }





       
        private void form1_Enter(object sender, EventArgs e)
        {

        }

        private void addres_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo fr = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(fr);
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void ثبتنامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            register register = new register();
            register.Show();
        }

        private void بروزرسنیاشتراکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update update = new update();
            update.Show();
        }

        private void ثبتغذاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertfood insertfood = new insertfood();
            insertfood.Show();
        }

        private void مشترکینToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableuser tableuser = new tableuser();
            tableuser.Show();
        }

        private void ماشینحسابToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            p.WaitForInputIdle();
        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "ایا می خواهید از برنامه خارج شوید", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();

            }
        }

        private void ثبتعنواندرفیشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertname y = new insertname();
            y.Show();
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "ایا می خواهید از برنامه خارج شوید", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void دربارهبرنامهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info info = new info();
            info.Show();
        }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
