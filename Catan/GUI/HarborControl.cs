using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Catan.Model;

namespace Catan.GUI
{
    public partial class HarborControl : Button, InputSource
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Index of Harbor in array"), Category("Data")]
        public int Index { set; get; } = -1;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("The resource traded by this harbor"), Category("Data")]
        public Item HarborResource { set; get; }

        public enum Facing
        {
            DownRight,
            Right,
            UpRight,
            DownLeft,
            Left,
            UpLeft
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Direction"), Category("Data")]
        public Facing Direction { set; get; } = Facing.DownLeft;

        
        private const float LegLength = 60f;
        private const float LegWidth = 6f;
        private const float Radius = 25f;
        private GraphicsPath harborPath;
        private GraphicsPath legPathA;
        private GraphicsPath legPathB;


        public HarborControl()
        {
            InitializeComponent();
            HandleSizeChange();
        }

        private void HandleSizeChange()
        {
            harborPath = new GraphicsPath();
            var centerX = Width / 2;
            var centerY = Height / 2;
            harborPath.AddEllipse( centerX-Radius, centerY-Radius, Radius*2, Radius * 2);


            var legXClose = centerX + Radius - 1;
            var legXFar = centerX + Radius + LegLength;
            var legPoints = new PointF[4];
            legPoints[0] = new PointF(legXClose, centerY-LegWidth);
            legPoints[1] = new PointF(legXFar, centerY-LegWidth);
            legPoints[2] = new PointF(legXFar, centerY+LegWidth);
            legPoints[3] = new PointF(legXClose, centerY+LegWidth);

            var centerPt = new PointF(centerX, centerY);
            var baseAngle = GetAngle();

            legPathA = new GraphicsPath();
            legPathA.AddPolygon(legPoints);
            var matrixA = new Matrix();
            matrixA.RotateAt(baseAngle + 30f,centerPt);
            legPathA.Transform(matrixA);

            legPathB = new GraphicsPath();
            legPathB.AddPolygon(legPoints);
            var matrixB = new Matrix();
            matrixB.RotateAt(GetAngle() - 30f,centerPt);
            legPathB.Transform(matrixB);


            Region = new Region(harborPath);
            Region.Union(legPathA);
            Region.Union(legPathB);
        }

        private float GetAngle()
        {
            switch (Direction)
            {
                case Facing.DownRight:
                    return 60.0f;
                case Facing.Right:
                    return 0.0f;
                case Facing.UpRight:
                    return 300.0f;
                case Facing.DownLeft:
                    return 120.0f;
                case Facing.Left:
                    return 180.0f;
                case Facing.UpLeft:
                    return 240.0f;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Direction), @"Direction should be set");
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            HandleSizeChange();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            var brush = new SolidBrush(Color.Black);
            pe.Graphics.FillPath(brush, legPathA);
            pe.Graphics.FillPath(brush, legPathB);
            brush.Dispose();
            
            var pen = new Pen(Color.Black, 10f);
            pe.Graphics.DrawPath(pen, harborPath);
            pen.Dispose();
        }
        
        public PlayerAction GetPlayerAction()
        {
            return new PlayerAction(ActionType.RequestTradeHarbor, Index, HarborResource);
        }
    }
}
