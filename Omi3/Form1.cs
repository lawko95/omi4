using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Omi3
{
    public partial class Form1 : Form
    {
        private Space space;
        private PictureBox pb;
        private Controller c;
        public Form1(Controller _c)
        {
            c = _c;
            Size = new Size(500, 500);
            InitializeComponent();
            space = new Space(500, 500, 1);
            Bitmap bm = space.Make(c.bodies);
            pb = new PictureBox();
            pb.Size = new Size(500, 500);
            pb.Image = bm;
            Controls.Add(pb);
        }

        public void UpdateSym(BodyObject[] _ls){
            var bm = space.Make(_ls);
            pb.Image = bm;
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
                var ls = c.DoStep();
                var bm = space.Make(ls);
                pb.Image = bm;
                Refresh();
            }
        }
    }
}
