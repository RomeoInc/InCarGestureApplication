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
            powerValue = 1;
            tempValue = 1;
            driverState = 1;
            passengerState = 1;
        }

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers)
        {
            switch (type)
            {
                case AcceptedGestures.GoBack:
                    GoBack(cd, observers);
                    break;
                case AcceptedGestures.SwipeRight:
                    PowerUp();
                    break;
                case AcceptedGestures.SwipeLeft:
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
                    PassengerWindowDown();
                    break;
                case AcceptedGestures.PassengerClosed:
                    PassengerWindowUp();
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
            System.Media.SoundPlayer mainSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Menu.wav");
            mainSound.Play();
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
            PowerSlider.Dispatcher.Invoke((Action)(() => {
                if (powerValue < PowerSlider.Maximum)
                {
                    powerValue++;
                    PowerSlider.Value = powerValue;
                    if (PowerSlider.Value == PowerSlider.Minimum + 1)
                    {
                        System.Media.SoundPlayer powerOnSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Air Conditioning On.wav");
                        powerOnSound.Play();
                    }
                    else
                    {
                        System.Media.SoundPlayer powerUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Power Up.wav");
                        powerUpSound.Play();
                    }
                }
            }));
        }

        private void PowerDown()
        {
            PowerSlider.Dispatcher.Invoke((Action)(() => {
                if (powerValue > PowerSlider.Minimum)
                {
                    powerValue--;
                    PowerSlider.Value = powerValue;
                    if (PowerSlider.Value == PowerSlider.Minimum)
                    {
                        System.Media.SoundPlayer powerOffSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Air Conditioning Off.wav");
                        powerOffSound.Play();
                    }
                    else
                    {
                        System.Media.SoundPlayer powerDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Power Down.wav");
                        powerDownSound.Play();
                    }
                }
            }));
        }

        private void TemperatureUp()
        {
            TemperatureSlider.Dispatcher.Invoke((Action)(() => {
                if (tempValue < TemperatureSlider.Maximum)
                {
                    tempValue++;
                    TemperatureSlider.Value = tempValue;
                    System.Media.SoundPlayer tempUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Temperature Up.wav");
                    tempUpSound.Play();
                }
            }));
        }

        private void TemperatureDown()
        {
            TemperatureSlider.Dispatcher.Invoke((Action)(() => {
                if (tempValue > TemperatureSlider.Minimum)
                {
                    tempValue--;
                    TemperatureSlider.Value = tempValue;
                    System.Media.SoundPlayer tempDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Temperature Down.wav");
                    tempDownSound.Play();
                }
            }));
        }

        private void DriverWindowUp()
        {
            DriverSlider.Dispatcher.Invoke((Action)(() => {
                if (driverState < DriverSlider.Maximum)
                {
                    driverState++;
                    DriverSlider.Value = driverState;
                    System.Media.SoundPlayer driverWindowUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Driver Window Up.wav");
                    driverWindowUpSound.Play();
                }
            }));
        }

        private void DriverWindowDown()
        {
            DriverSlider.Dispatcher.Invoke((Action)(() => {
                if (driverState > DriverSlider.Minimum)
                {
                    driverState--;
                    DriverSlider.Value = driverState;
                    System.Media.SoundPlayer driverWindowDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Driver Window Down.wav");
                    driverWindowDownSound.Play();
                }
            }));
        }

        private void PassengerWindowUp()
        {
            PassengerSlider.Dispatcher.Invoke((Action)(() => {
                if (passengerState < PassengerSlider.Maximum)
                {
                    passengerState++;
                    PassengerSlider.Value = passengerState;
                    System.Media.SoundPlayer PassengerWindowUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Passenger Window Up.wav");
                    PassengerWindowUpSound.Play();
                }
            }));
        }

        private void PassengerWindowDown()
        {
            PassengerSlider.Dispatcher.Invoke((Action)(() => {
                if (passengerState > PassengerSlider.Minimum)
                {
                    passengerState--;
                    PassengerSlider.Value = passengerState;
                    System.Media.SoundPlayer PassengerWindowDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Passenger Window Down.wav");
                    PassengerWindowDownSound.Play();
                }
            }));
        }

        private void BothWindowsOpen()
        {
            DriverSlider.Dispatcher.Invoke((Action)(() => {
                PassengerSlider.Dispatcher.Invoke((Action)(() => {
                    if (driverState < DriverSlider.Maximum && passengerState < PassengerSlider.Maximum)
                    {
                        driverState++;
                        passengerState++;
                        DriverSlider.Value = driverState;
                        PassengerSlider.Value = passengerState;
                        System.Media.SoundPlayer BothWindowsUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Both Windows Up.wav");
                        BothWindowsUpSound.Play();
                    }
                }));
            }));
            
            DriverSlider.Dispatcher.Invoke((Action)(() => {
                if (driverState < DriverSlider.Maximum)
                {
                    driverState++;
                    DriverSlider.Value = driverState;
                    System.Media.SoundPlayer driverWindowUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Driver Window Up.wav");
                    driverWindowUpSound.Play();
                }
            }));
            
            PassengerSlider.Dispatcher.Invoke((Action)(() => {
                if (passengerState < PassengerSlider.Maximum)
                {
                    passengerState++;
                    PassengerSlider.Value = passengerState;
                    System.Media.SoundPlayer PassengerWindowUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Passenger Window Up.wav");
                    PassengerWindowUpSound.Play();
                }
            }));
        }

        private void BothWindowsClosed()
        {
            DriverSlider.Dispatcher.Invoke((Action)(() => {
                PassengerSlider.Dispatcher.Invoke((Action)(() => {
                    if (driverState > DriverSlider.Minimum && passengerState > PassengerSlider.Minimum)
                    {
                        driverState--;
                        passengerState--;
                        DriverSlider.Value = driverState;
                        PassengerSlider.Value = passengerState;
                        System.Media.SoundPlayer BothWindowsDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Both Windows Down.wav");
                        BothWindowsDownSound.Play();
                    }
                }));
            }));

            DriverSlider.Dispatcher.Invoke((Action)(() => {          
                if (driverState > DriverSlider.Minimum)
                {
                    driverState--;
                    DriverSlider.Value = driverState;
                    System.Media.SoundPlayer driverWindowDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Driver Window Down.wav");
                    driverWindowDownSound.Play();
                }
            }));
            
            PassengerSlider.Dispatcher.Invoke((Action)(() => {
                if (passengerState > PassengerSlider.Minimum)
                {
                    passengerState--;
                    PassengerSlider.Value = passengerState;
                    System.Media.SoundPlayer PassengerWindowDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Passenger Window Down.wav");
                    PassengerWindowDownSound.Play();
                }
            }));
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }
    }
}
