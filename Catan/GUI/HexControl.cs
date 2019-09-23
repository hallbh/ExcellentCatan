using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Catan.Model;

namespace Catan.GUI
{
    public partial class HexControl : Button, InputSource
    {
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Index of intersection in array"), Category("Data")]
        public int Index { set; get; } = -1;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Robber state of the tile"), Category("Data")]
        public bool HasRobber { set; get; }


        private GraphicsPath hexPath;
        private GraphicsPath robberPath;

        public HexControl()
        {
            InitializeComponent();
            HandleSizeChanged();
        }

        private const int HexagonSideCount = 6;
        private const double AngleBetweenVertices = Math.PI / 3.0; 
        
        private const int RobberTopWidth = 30;
        private const int RobberBottomWidth = 40;
        private const int RobberHeight = 80;
        private void HandleSizeChanged()
        {
            var centerX = Width / 2;
            var centerY = Height / 2;
            var points = new PointF[HexagonSideCount];
            var radius = Height / 2.0f;
            for (var i = 0; i < HexagonSideCount; i++)
            {
                var pX = Convert.ToSingle(centerX + radius * Math.Sin(i * AngleBetweenVertices));
                var pY = Convert.ToSingle(centerY + radius * Math.Cos(i * AngleBetweenVertices));
                points[i] = new PointF(pX, pY);
            }

            hexPath = new GraphicsPath();
            hexPath.AddPolygon(points);
            Region = new Region(hexPath);


            var robberPoints = new PointF[4];
            robberPoints[0] = new PointF(centerX - RobberTopWidth, Height / 2 - RobberHeight / 2);
            robberPoints[1] = new PointF(centerX + RobberTopWidth, Height / 2 - RobberHeight / 2);
            robberPoints[2] = new PointF(centerX + RobberBottomWidth, Height / 2 + RobberHeight / 2);
            robberPoints[3] = new PointF(centerX - RobberBottomWidth, Height / 2 + RobberHeight / 2);
            robberPath = new GraphicsPath();
            robberPath.AddPolygon(robberPoints);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            HandleSizeChanged();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var pen = new Pen(Color.Black, 10f);

            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.DrawPath(pen, hexPath);

            if (HasRobber)
            {
                pe.Graphics.DrawPath(pen, robberPath);
            }

            pen.Dispose();
        }

        public PlayerAction GetPlayerAction()
        {
            return new PlayerAction(ActionType.Hex, Index);
        }
    }
}