// NanoFramework sample app on STF32F4

#region Imports
using System;
using System.Threading;
using Windows.Devices.Gpio;
#endregion

namespace NfAppSample
{
    public class Program
    {
        static int pulseCount;
        static GpioPin ledGreen;
        public static void Main()
        {
            Console.WriteLine("Hello world!");
            ledGreen = GpioController.GetDefault().OpenPin(PinNumber('D', 12));
            //
            GpioPin ledOrange = GpioController.GetDefault().OpenPin(PinNumber('D', 13));
            GpioPin ledRed = GpioController.GetDefault().OpenPin(PinNumber('D', 14));
            GpioPin ledBlue = GpioController.GetDefault().OpenPin(PinNumber('D', 15));
            //
            ledGreen.SetDriveMode(GpioPinDriveMode.Output);
            ledOrange.SetDriveMode(GpioPinDriveMode.Output);
            ledRed.SetDriveMode(GpioPinDriveMode.Output);
            ledBlue.SetDriveMode(GpioPinDriveMode.Output);
            //
            Timer appTimer1 = new Timer(appTimer1_Callback, null, 8000, 1);
            Timer appTimer2 = new Timer(appTimer2_Callback, null, 1000, 1000);
            //
            while (true)
            {
                ledRed.Write(GpioPinValue.High);
                Thread.Sleep(125);
                ledRed.Toggle();
                Thread.Sleep(125);
                ledRed.Toggle();
                Thread.Sleep(125);
                ledRed.Toggle();
                Thread.Sleep(525);
                ledOrange.Write(ledOrange.Read());
                ledOrange.Toggle();
                ledBlue.Write(ledOrange.Read());
                ledBlue.Toggle();
            }
        }
        /// <summary>
        /// Timer 1
        /// </summary>
        /// <param name="state"></param>
        static void appTimer1_Callback(object state)
        {
            pulseCount += 1;
            ledGreen.Toggle();
        }
        /// <summary>
        /// Timer 2
        /// </summary>
        /// <param name="state"></param>
        static void appTimer2_Callback(object state)
        {
            Console.WriteLine(pulseCount.ToString());
            pulseCount = 0;
        }

        static int PinNumber(char port, byte pin)
        {
            if (port < 'A' || port > 'J')
                throw new ArgumentException();
            return ((port - 'A') * 16) + pin;

        }
    }

}
