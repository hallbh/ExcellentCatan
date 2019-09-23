using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Catan.Model;

namespace Catan.GUI
{
    public partial class RoadControl : Button, InputSource
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Index of intersection in array"), Category("Data")]
        public int Index { set; get; } = -1;

        public enum RoadDirection
        {
            PositiveSlope,
            NegativeSlope,
            VerticalSlope
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Direction"), Category("Data")]
        public RoadDirection Direction { set; get; }

        public RoadControl()
        {
            InitializeComponent();
            HandleSizeChanged();
        }

        public PlayerAction GetPlayerAction()
        {
            return new PlayerAction(ActionType.Path, Index);
        }

        private PointF[] points;
        private GraphicsPath path;

        private float GetAngle()
        {
            switch (Direction)
            {
                case RoadDirection.VerticalSlope:
                    return 0.0f;
                case RoadDirection.NegativeSlope:
                    return -60.0f;
                case RoadDirection.PositiveSlope:
                    return 60.0f;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Direction),@"Direction should be set");
            }
        }

        private void HandleSizeChanged()
        {
            points = new PointF[4];
            const float width = 12f;
            var height = Height + 1f;
            points[0] = new PointF(Width / 2f - width / 2f, 0);
            points[1] = new PointF(Width / 2f + width / 2f, 0);
            points[2] = new PointF(Width / 2f + width / 2f, height);
            points[3] = new PointF(Width / 2f - width / 2f, height);

            var myMatrix = new Matrix();
            myMatrix.RotateAt(GetAngle(), new PointF(Width / 2f, height / 2f));

            path = new GraphicsPath();
            path.AddPolygon(points);
            path.Transform(myMatrix);
            Region = new Region(path);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            HandleSizeChanged();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
            var brush = new SolidBrush(ForeColor);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.FillPath(brush, path);
            brush.Dispose();
        }
    }
}