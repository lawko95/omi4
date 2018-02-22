using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omi3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ls = new BodyObject[2];
            ls[0] = new BodyObject(new Vector(1, 0), 3000000000, new Vector(0, -0.01), "a");
            ls[1] = new BodyObject(new Vector(15, 0), 3000000000, new Vector(0, 0.01), "b");
            //var c = new Controller(ls, 1, 1000);
            Space space = new Space(500, 500, 1);
            Bitmap bm = space.Make(ls);
            PictureBox pb = new PictureBox();
            pb.Size = new Size(500, 500);
            pb.Image = bm;
            Controls.Add(pb);
        }
    }
}
