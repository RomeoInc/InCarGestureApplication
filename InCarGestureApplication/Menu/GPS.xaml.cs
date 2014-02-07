using Leap.Gestures.Count;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for GPS.xaml
    /// </summary>
    public partial class GPS : UserControl, IGestureObserver 
    {
        MainWindow mw;

        public GPS()
        {
            InitializeComponent();
        }

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers)
        {
            switch (type)
            {
                case AcceptedGestures.GoBack:
                    Back(cd, observers);
                    break;
                case AcceptedGestures.SwipeLeft:
                    ScrollLeft();
                    break;
                case AcceptedGestures.SwipeRight:
                    ScrollRight();
                    break;
                case AcceptedGestures.SwipeUp:
                    ScrollUp();
                    break;
                case AcceptedGestures.SwipeDown:
                    ScrollDown();
                    break;
                case AcceptedGestures.SwipeIn:
                    ZoomIn();
                    break;
                case AcceptedGestures.SwipeOut:
                    ZoomOut();
                    break;
                case AcceptedGestures.SelectOption:
                    PlaceMarker();
                    break;
                default:
                    break;
            }
        }

        private void Back(CountDetector cd, List<IParentObserver> observers)
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

        private void ScrollLeft()
        {
            throw new NotImplementedException();
        }

        private void ScrollRight()
        {
            throw new NotImplementedException();
        }

        private void ScrollUp()
        {
            throw new NotImplementedException();
        }

        private void ScrollDown()
        {
            throw new NotImplementedException();
        }

        private void ZoomIn()
        {
            throw new NotImplementedException();
        }

        private void ZoomOut()
        {
            return;
        }

        private void PlaceMarker()
        {
            throw new NotImplementedException();
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }
    }
}
