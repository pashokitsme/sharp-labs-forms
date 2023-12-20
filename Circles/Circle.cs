using System.Drawing;

namespace Circles;

public class Circle
{
    public Color Color;
    public Point Velocity;
    public Rectangle Bounds;

    public void Tick(Size bounds)
    {
        Bounds.Location = new Point(Bounds.Location.X + Velocity.X, Bounds.Location.Y + Velocity.Y);
        var pos = Bounds.Location;
        if (pos.X < 0 || pos.X + Bounds.Width > bounds.Width)
            Velocity.X *= -1;

        if (pos.Y < 0 || pos.Y + Bounds.Height > bounds.Height)
            Velocity.Y *= -1;
    }
}