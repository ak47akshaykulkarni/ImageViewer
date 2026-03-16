using FellowOakDicom.Imaging;
using FellowOakDicom;
using FellowOakDicom.Imaging;
using System.Reflection;
using Microsoft.Maui.Storage;

namespace ImageViewer.Views;

public partial class ViewDicomPage : ContentPage
{
	public ViewDicomPage()
	{
		InitializeComponent();
		// var image = new DicomImage(@"test.dcm");
		// var asdas = image.RenderImage().AsBytes();//().Save(@"test.jpg");

		LoadDicom();
	}

	private async void LoadDicom()
	{
		try
		{
			// using var fileStream = await FileSystem.OpenAppPackageFileAsync("Raw/imagedicom.dcm");
			
			// // DicomFile.Open requires a seekable stream, so copy to MemoryStream
			// var memoryStream = new MemoryStream();
			// await fileStream.CopyToAsync(memoryStream);
			// memoryStream.Seek(0, SeekOrigin.Begin);
			
			var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a DICOM file",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { "application/dicom", ".dcm" } },
                    { DevicePlatform.iOS, new[] { "public.data", ".dcm" } },
                    { DevicePlatform.WinUI, new[] { ".dcm" } }
                })
            });

			using var stream = await result.OpenReadAsync();


			var dicomFile = DicomFile.Open(stream);
	
	        // Render the image from pixel data
	        var dicomImage = new DicomImage(dicomFile.Dataset);
	
	        // Convert Bitmap to MAUI ImageSource
	       var bitmapBytes = dicomImage.RenderImage().AsBytes();
	
	        // Wrap bytes into a MemoryStream
	        var imageStream = new MemoryStream(bitmapBytes);
	
	        // Convert to ImageSource
	        var imageSource = ImageSource.FromStream(() => imageStream);
	
	        // Display in MAUI Image control
			dcmFileImage.Source = imageSource;
		}
		catch (System.Exception ex)
		{
			Console.WriteLine("Error loading DICOM file. Exception: " + ex.Message);
		}
	}
}