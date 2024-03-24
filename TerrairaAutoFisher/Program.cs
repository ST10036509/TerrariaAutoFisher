//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/* Autor:           Ethan Schoonbee
 * Date Created:    24/03/2024
 * Last Modified:   24/03/2024
*/
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
using System.Drawing;
using System;
using System.Windows.Forms;

namespace TerrairaAutoFisher
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //create a new screen monitor
            ScreenMonitor screenMonitor = new ScreenMonitor();

            //create a new rectangle to represent the screen area
            Rectangle screenArea = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //monitor the screen area selected
            screenMonitor.MonitorScreenArea(screenArea);
        }
    }
}
//---------------....oooOO0_END_OF_FILE_0OOooo....---------------\\