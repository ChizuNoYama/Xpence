namespace Xpence.Drawables;

public class AddIconButtonDrawable : IDrawable
{
    public Color BackgroundFillColor { get; set; } = Colors.Black;
    public Color ForegroundFillColor { get; set; } = Colors.White;
    public float Padding { get; set; }
    public float IconThickness { get; set; }
    
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeSize = 0f;
        
        // Background
        canvas.FillColor = this.BackgroundFillColor;
        canvas.FillEllipse(0, 0, dirtyRect.Width, dirtyRect.Height);
        
        // Foreground
        canvas.FillColor = this.ForegroundFillColor;
        canvas.FillRectangle((dirtyRect.Width/2) - (this.IconThickness/2), this.Padding, this.IconThickness, dirtyRect.Height - (this.Padding * 2));
        canvas.FillRectangle(this.Padding, (dirtyRect.Height/2) - (this.IconThickness/2), dirtyRect.Width  - (this.Padding * 2), this.IconThickness);
    }
}