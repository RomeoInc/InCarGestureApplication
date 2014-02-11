using Leap.Gestures.Count;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InCarGestureApplication
{
    /// <summary>
    /// Interaction logic for Extras.xaml
    /// </summary>
    public partial class Extras : UserControl, IGestureObserver
    {
        MainWindow mw;
        int powerValue;
        int tempValue;
        int driverState;
        int passengerState;

        public Extras()
        {
            InitializeComponent();
            powerValue = 0;
            tempValue = 0;
            driverState = 0;
            passengerState = 0;
        }

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers)
        {
            switch (type)
            {
                case AcceptedGestures.GoBack:
                    GoBack(cd, observers);
                    break;
                case AcceptedGestures.SwipeLeft:
                    PowerUp();
                    break;
                case AcceptedGestures.SwipeRight:
                    PowerDown();
                    break;
                case AcceptedGestures.RotateAntiClockwise:
                    TemperatureDown();
                    break;
                case AcceptedGestures.RotateClockwise:
                    TemperatureUp();
                    break;
                case AcceptedGestures.DriverOpen:
                    DriverWindowDown();
                    break;
                case AcceptedGestures.DriverClosed:
                    DriverWindowUp();
                    break;
                case AcceptedGestures.PassengerOpen:
                    PassengerWindowOpen();
                    break;
                case AcceptedGestures.PassengerClosed:
                    PassengerWindowClosed();
                    break;
                case AcceptedGestures.BothOpen:
                    BothWindowsOpen();
                    break;
                case AcceptedGestures.BothClosed:
                    BothWindowsClosed();
                    break;
                default:
                    break;
            }
        }

        private void GoBack(CountDetector cd, List<IParentObserver> observers)
        {
            mw.window.Children.Remove(mw.window.Children[mw.window.Children.Count - 1]);
            foreach (IParentObserver observer in observers)
            {
                if (observer is IGestureObserver)
                {
                    IGestureObserver ig = (IGestureObserver)observer;
                    cd.UnregisterObserver(ig);
                }
            }
        }

        private void PowerUp()
        {
            if (powerValue < PowerSlider.Maximum)
            {
                powerValue++;
                PowerSlider.Value = powerValue;
            }
        }

        private void PowerDown()
        {
            if (powerValue > PowerSlider.Minimum)
            {
                powerValue--;
                PowerSlider.Value = powerValue;
            }
        }

        private void TemperatureUp()
        {
            if (tempValue < TemperatureSlider.Maximum)
            {
                tempValue++;
                TemperatureSlider.Value = tempValue;
            }
        }

        private void TemperatureDown()
        {
            if (powerValue > PowerSlider.Minimum)
            {
                powerValue--;
                PowerSlider.Value = powerValue;
            }
        }

        private void DriverWindowUp()
        {
            if (driverState < DriverSlider.Maximum)
            {
                driverState++;
                DriverSlider.Value = driverState;
            }
        }

        private void DriverWindowDown()
        {
            if (driverState > DriverSlider.Minimum)
            {
                driverState--;
                DriverSlider.Value = driverState;
            }
        }

        private void PassengerWindowOpen()
        {
            if (passengerState < PassengerSlider.Maximum)
            {
                passengerState++;
                PassengerSlider.Value = passengerState;
            }
        }

        private void PassengerWindowClosed()
        {
            if (passengerState > PassengerSlider.Minimum)
            {
                passengerState--;
                PassengerSlider.Value = passengerState;
            }
        }

        private void BothWindowsOpen()
        {
            if (driverState < DriverSlider.Maximum && passengerState < PassengerSlider.Maximum)
            {
                driverState++;
                passengerState++;
                DriverSlider.Value = driverState;
                PassengerSlider.Value = passengerState;

            }
            
            else if (driverState < DriverSlider.Maximum)
            {
                driverState++;
                DriverSlider.Value = driverState;
            }
            
            else if (passengerState < PassengerSlider.Maximum)
            {
                passengerState++;
                PassengerSlider.Value = passengerState;
            }

        }

        private void BothWindowsClosed()
        {
            if (driverState > DriverSlider.Minimum)
            {
                driverState--;
                DriverSlider.Value = driverState;
            }
            
            if (passengerState > PassengerSlider.Minimum)
            {
                passengerState--;
                PassengerSlider.Value = passengerState;
            }
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }
    }
}
