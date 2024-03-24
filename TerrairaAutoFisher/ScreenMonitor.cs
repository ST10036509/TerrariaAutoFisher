//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/* Autor:           Ethan Schoonbee
 * Date Created:    24/03/2024
 * Last Modified:   24/03/2024
*/
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace TerrairaAutoFisher
{
    /// <summary>
    /// Class to monitor the screen area for the bobber to appear.
    /// </summary>
    public class ScreenMonitor
    {
        //create a new string to store the previous hash
        private static string previousHash = string.Empty;

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

                //generate a hash from the byte string
                string currentHash = GenerateHash(byteString);

                //compare the current hash to the previous hash
                CompareHashes(currentHash);
            }
        }



        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private byte[] CaptureScreenArea(Rectangle area)
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




        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// Method to convert a byte array to a string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private string ConvertByteArrayToString(byte[] bytes)
        {
            //create a new string builder to store the byte string
            StringBuilder byteString = new StringBuilder();

            //convert the byte array to a string
            foreach (byte b in bytes)
            {
                byteString.Append(b.ToString());
            }
            
            //return the byte string
            return byteString.ToString();
        }



        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// Method to generate a hash from a byte string
        /// </summary>
        /// <param name="byteString"></param>
        /// <returns></returns>
        private string GenerateHash(string byteString)
        {
            //create a new SHA256 hash
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //compute the hash of the byte string
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(byteString));

                //create a new string builder to store the hash string
                StringBuilder hashString = new StringBuilder();

                //convert the hash to a string
                foreach (byte b in data)
                {
                    //format the hash string
                    hashString.Append(b.ToString("X2"));
                }

                //return the hash string
                return hashString.ToString();
            }
        }



        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// Method to compare the current hash to the previous hash
        /// </summary>
        private void CompareHashes(string currentHash)
        {
            //check if the previous hash is not empty and the current hash is not equal to the previous hash
            if (previousHash != null && currentHash != previousHash)
            {
                //perform the actions
                PerformActions();

                //set the previous hash to the current hash
                previousHash = currentHash;
            }

            //wait for a short period of time before checking again
            Thread.Sleep(200);
        }



        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// Method to perform the actions
        /// </summary>
        private void PerformActions()
        {
            //create a new action factory
            ActionFactory actionFactory = new ActionFactory();

            //display a message to the console
            actionFactory.DislayConsoleMessage();
        }
    }
}
//---------------....oooOO0_END_OF_FILE_0OOooo....---------------\\