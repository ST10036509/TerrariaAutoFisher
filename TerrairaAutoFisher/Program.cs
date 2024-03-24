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
        //create a new screen monitor
        private static ScreenMonitor screenMonitor = new ScreenMonitor();



        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            run();
        }



        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// Method to run the program.
        /// </summary>
        private static void run()
        {
            //select the screen to monitor
            int screenIndex = 0;

            //get all screens avaliable
            Screen[] screens = Screen.AllScreens;

            //get the selected screen
            Screen selectedScreen = screens[screenIndex];

            //create a new rectangle to represent the screen area
            Rectangle screenArea = new Rectangle(0, 0, selectedScreen.Bounds.Width, selectedScreen.Bounds.Height);

            //monitor the screen area selected
            screenMonitor.MonitorScreenArea(screenArea);
        }
    }
}
//---------------....oooOO0_END_OF_FILE_0OOooo....---------------\\