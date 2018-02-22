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
        public Form1(BodyObject[] _ls)
        {
            Size = new Size(500, 500);
            InitializeComponent();
            space = new Space(500, 500, 1);
            Bitmap bm = space.Make(_ls);
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
    }
}
