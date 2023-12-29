using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program_resturan
{
    class classresturan
    {
        public void clear(Form fr)
        {

            foreach (Control t in fr.Controls)
            {
                if (t is TextBox)
                {
                    t.Text = "";
                }
            }

        }
    }
}
