using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Circles;

public partial class CircleForm : Form
{
    private const int CIRCLE_DEFAULT_SIZE = 100;
    private static Color RandomColor => Color.FromArgb(Random.Shared.Next(256), Random.Shared.Next(256), Random.Shared.Next(256));
    private Circle RandomCircle
    {
        get {
            var point = new Point(Random.Shared.Next(0, ClientSize.Width - CIRCLE_DEFAULT_SIZE), Random.Shared.Next(0, ClientSize.Height - CIRCLE_DEFAULT_SIZE));
            var size = new Size(CIRCLE_DEFAULT_SIZE, CIRCLE_DEFAULT_SIZE);
            return new Circle
            {
                Color = RandomColor,
                Bounds = new Rectangle(point, size),
                Velocity = new Point(Random.Shared.Next(1, 5), Random.Shared.Next(1, 5))
            };
        }
    }

    private readonly List<Circle> _circles = [];

    public CircleForm()
    {
        InitializeComponent();

        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        UpdateStyles();

        _circles.AddRange(Enumerable.Range(0, 10).Select(_ => RandomCircle));
    }

    private void OnMouseClick(object sender, MouseEventArgs ev)
    {
        var count = _circles.RemoveAll(c => c.Bounds.Contains(ev.Location));
        _circles.AddRange(Enumerable.Range(0, count).Select(_ => RandomCircle));
    }

    private void OnPaint(object sender, PaintEventArgs ev)
    {
        ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        foreach (var ball in _circles)
        {
            ev.Graphics.FillEllipse(new SolidBrush(ball.Color), ball.Bounds);
            ev.Graphics.DrawEllipse(Pens.Black, ball.Bounds);
        }
    }

    private void OnTick(object sender, EventArgs ev)
    {
        foreach (var circle in _circles)
            circle.Tick(ClientSize);

        Refresh();
    }
}