using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE
{
    class ComponentesReusables
    {
        public static void AbrirFormEnPanel(object Formhijo, Panel p)
        {
            if (p.Controls.Count > 0)
                p.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            p.Controls.Add(fh);
            p.Tag = fh;
            fh.Show();
        }
    }
}
