// TinyClr Sample

#region Imports
using GHIElectronics.TinyCLR.Devices.Gpio;
using System;
using System.Diagnostics;
using System.Threading;
#endregion

namespace TinyClrSample
{
    class Program
    {
        static Enum pinValue;
        static GpioPin led;
        /// <summary>
        /// Entry point
        /// </summary>
        static void Main()
        {
            led = GpioController.GetDefault().OpenPin(18);
            led.SetDriveMode(GpioPinDriveMode.Output);
            while (true)
            {
                led.Write(GpioPinValue.High);
                Thread.Sleep(10);
                PrintLedStatus();
                led.Write(GpioPinValue.Low);
                Thread.Sleep(980);
                PrintLedStatus();
            }
        }
        /// <summary>
        /// Print out
        /// </summary>
        static void PrintLedStatus()
        {
            pinValue = led.Read(); 
            Debug.WriteLine(pinValue.ToString());
        }
    }
}
