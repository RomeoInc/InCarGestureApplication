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

        public Extras()
        {
            InitializeComponent();
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
            throw new NotImplementedException();
        }

        private void PowerDown()
        {
            throw new NotImplementedException();
        }

        private void TemperatureDown()
        {
            throw new NotImplementedException();
        }

        private void TemperatureUp()
        {
            throw new NotImplementedException();
        }

        private void DriverWindowDown()
        {
            throw new NotImplementedException();
        }

        private void DriverWindowUp()
        {
            throw new NotImplementedException();
        }

        private void PassengerWindowOpen()
        {
            throw new NotImplementedException();
        }

        private void PassengerWindowClosed()
        {
            throw new NotImplementedException();
        }

        private void BothWindowsOpen()
        {
            throw new NotImplementedException();
        }

        private void BothWindowsClosed()
        {
            throw new NotImplementedException();
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }
    }
}
