using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Universal_Bitmap {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void DrawPixel( object sender, RoutedEventArgs e ) {

            PixelFormat myPixelFormat = PixelFormats.Bgr32; // Microsoft recommends Pbgra32 or Bgr32 for best performance.
            BitmapPalette myPalette   = BitmapPalettes.WebPalette; // Use predefined palette.

            int bitmapWidth  = 300; // Number of pixels.
            int bitmapHeight = 300; // Number of pixels.
            int dpiX = 96;
            int dpiY = 96;

            WriteableBitmap bitmap = new WriteableBitmap( bitmapWidth, bitmapHeight, dpiX, dpiY, myPixelFormat, myPalette );

            // Define the area that will be updated.
            Int32Rect sourceRect = new Int32Rect(
                0, // X starting position
                0, // Y starting position
                bitmap.PixelWidth, // Width
                bitmap.PixelHeight // Height
                );

            // Set pixels using single pixel rect.
            int bytesPerPixel = ( bitmap.Format.BitsPerPixel + 7 ) / 8; // Formula provided by Microsoft.
            int stride = bitmap.PixelWidth * bytesPerPixel; // Formula provided by Microsoft. Stride is the byte width of a single rectangle row.
            int offset = 0;
            int bufferSize = stride * bitmap.PixelHeight;  // Formula provided by Microsoft.
            byte[] pixels  = new byte[bufferSize]; // Each index is the BGR value of a single pixel.

            //MessageBox.Show( "Bytes Per Pixel: " + bytesPerPixel ); // Debug
            //MessageBox.Show( "Buffer Size: " + bufferSize ); // Debug

            for( int i = 0; i < bufferSize; i += bytesPerPixel ) {

                pixels[i]     = 0x00;
                pixels[i + 1] = 0xFF;
                pixels[i + 2] = 0x00;
                pixels[i + 3] = 0xFF;

            }

            pixels[0] = 0x00; // Blue
            pixels[1] = 0x00; // Green
            pixels[2] = 0x00; // Red
            pixels[3] = 0x00; // Alpha?

            bitmap.WritePixels( sourceRect, pixels, stride, offset );

            BitmapImage.Source = bitmap;
        }

        private void ScaleBitmap( object sender, RoutedEventArgs e ) {

            BitmapImage.Width  += 500;
            BitmapImage.Height += 500;
            //BitmapImage.RenderTransform.Value.Transform.Width = 2;

            //RenderOptions.SetEdgeMode( BitmapImage, EdgeMode.Unspecified );

        }
    }
}
