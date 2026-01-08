namespace ImageViewer.Views;

public partial class BlankPage : ContentPage
{
    private double currentScale = 1;
    private double startScale = 1;
    private double xOffset = 0;
    private double yOffset = 0;
    public BlankPage(BlankViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateBacklight(e.NewValue);
    }

    private void UpdateBacklight(double value)
    {
        // Warm: RGB(255, 200, 150) -> Cool: RGB(150, 200, 255)
        double t = value / 100;
        byte r = (byte)(255 * (1 - t) + 150 * t);
        byte g = (byte)(200); // constant mid-point green
        byte b = (byte)(150 * (1 - t) + 255 * t);

        BacklightBox.Color = Color.FromRgb(r, g, b);
    }

    void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (e.Status == GestureStatus.Started)
        {
            startScale = currentScale;
        }
        else if (e.Status == GestureStatus.Running)
        {
            currentScale = Math.Max(1, startScale * e.Scale); // Minimum zoom = 1x
            XrayImage.Scale = currentScale;
        }
    }

    void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Started:
                xOffset += e.TotalX;
                yOffset += e.TotalY;
                break;
            case GestureStatus.Running:
                xOffset = e.TotalX;
                yOffset = e.TotalY;
                XrayImage.TranslationX += xOffset;
                XrayImage.TranslationY += yOffset;
                break;

            case GestureStatus.Completed:
                var asdas = e.TotalX;
                var asdasd = e.TotalY;
                xOffset = XrayImage.TranslationX;
                yOffset = XrayImage.TranslationY;
                // Optionally snap back or clamp bounds
                break;
        }
    }


}
