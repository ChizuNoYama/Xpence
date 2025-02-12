using System.Windows.Input;
using Xpence.Drawables;

namespace Xpence.Components;

public class IconButton : GraphicsView
{
    private AddIconButtonDrawable _buttonDrawable = new();
    
    public static BindableProperty OnTapCommandProperty = BindableProperty.Create(nameof(OnTapCommand), typeof(ICommand), typeof(IconButton));
    public ICommand OnTapCommand
    {
        get => (ICommand) GetValue(OnTapCommandProperty);
        set => SetValue(OnTapCommandProperty, value);
    }

    public static BindableProperty CanvasForegroundColorProperty = BindableProperty.Create(nameof(CanvasForegroundColor), typeof(Color), typeof(IconButton));

    public Color CanvasForegroundColor
    {
        get => (Color)GetValue(CanvasForegroundColorProperty);
        set => SetValue(CanvasForegroundColorProperty, value);
    }
    
    public static BindableProperty CanvasBackgroundColorProperty = BindableProperty.Create(nameof(CanvasBackgroundColor), typeof(Color), typeof(IconButton));
    public Color CanvasBackgroundColor
    {
        get => (Color)GetValue(CanvasBackgroundColorProperty);
        set => SetValue(CanvasBackgroundColorProperty, value);
    }
    
    public static BindableProperty CanvasPaddingProperty = BindableProperty.Create(nameof(CanvasPadding), typeof(float), typeof(IconButton));
    public float CanvasPadding
    {
        get => (float)GetValue(CanvasPaddingProperty);
        set => SetValue(CanvasPaddingProperty, value);
    }
    
    public static BindableProperty CanvasIconThicknessProperty = BindableProperty.Create(nameof(CanvasIconThickness), typeof(float), typeof(IconButton));
    public float CanvasIconThickness
    {
        get => (float) GetValue(CanvasIconThicknessProperty);
        set => SetValue(CanvasIconThicknessProperty, value);
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        switch (propertyName)
        {
            case nameof(CanvasForegroundColor):
                _buttonDrawable.ForegroundFillColor = this.CanvasForegroundColor;
                this.Drawable = _buttonDrawable;
                this.Invalidate();
                break;
            case nameof(CanvasBackgroundColor):
                _buttonDrawable.BackgroundFillColor = this.CanvasBackgroundColor;
                this.Drawable = _buttonDrawable;
                this.Invalidate();
                break;
            case nameof(CanvasPadding):
                _buttonDrawable.Padding = this.CanvasPadding;
                this.Drawable = _buttonDrawable;
                this.Invalidate();
                break;
            case nameof(CanvasIconThickness):
                _buttonDrawable.IconThickness = this.CanvasIconThickness;
                this.Drawable = _buttonDrawable;
                this.Invalidate();
                break;
            case nameof(OnTapCommand):
                this.GestureRecognizers.Clear();
                this.GestureRecognizers.Add(new TapGestureRecognizer{ Command = OnTapCommand });
                break;
        }
    }
}