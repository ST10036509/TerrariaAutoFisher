//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/* Autor:           Ethan Schoonbee
 * Date Created:    24/03/2024
 * Last Modified:   24/03/2024
*/
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
using System.Drawing;
using System.Drawing.Imaging;

namespace TerrairaAutoFisher
{
    public class ScreenMonitor
    {
        /// <summary>
        /// Monitors the screen area for the bobber to appear.
        /// </summary>
        public void MonitorScreenArea(Rectangle area)
        {
            //main loop to monitor the screen area
            while (true)
            {
                //capture the bytes in the screen area
                byte[] bytes = CaptureScreenArea(area);

                //convert the bytes to a string
                string byteString = ConvertByteArrayToString(bytes);

                string currentHash = GenerateHash(byteString);
            }
        }



        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public byte[] CaptureScreenArea(Rectangle area)
        {
            //create a new bitmap to store the screen area
            Bitmap bitmap = new Bitmap(area.Width, area.Height, PixelFormat.Format32bppArgb);

            //create a new graphics object to draw the screen area
            Graphics graphic = Graphics.FromImage(bitmap);

            //capture the screen area
            graphic.CopyFromScreen(area.Left, area.Top, 0, 0, bitmap.Size);

            //create a new image converter
            ImageConverter converter = new ImageConverter();

            //return the screen area as a byte array
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }
    }
}
//---------------....oooOO0_END_OF_FILE_0OOooo....---------------\\