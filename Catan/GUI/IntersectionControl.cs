using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Catan.Model;

namespace Catan.GUI
{
    public partial class IntersectionControl : Button, InputSource
    {


        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Index of intersection in array"), Category("Data")]
        public int Index { set; get; } = -1;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("City level of the intersection"), Category("Data")]
        public bool IsCity { set; get; }

        private GraphicsPath gp;
        public IntersectionControl()
        {
            InitializeComponent();
            HandleSizeChange();
        }

        private void HandleSizeChange()
        {
            gp = new GraphicsPath();
            gp.AddEllipse(0,0, ClientSize.Width, ClientSize.Height);
            Region = new Region(gp);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            HandleSizeChange();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var pen = IsCity ? new Pen(Color.Gold, 10f) : new Pen(Color.Black, 10f);

            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.DrawPath(pen, gp);
            pen.Dispose();
        }

        public PlayerAction GetPlayerAction()
        {
            return new PlayerAction(ActionType.Intersection, Index);
        }
    }
}
