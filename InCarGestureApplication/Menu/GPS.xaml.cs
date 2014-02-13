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
            System.Media.SoundPlayer menuSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Menu.wav");
            menuSound.Play();
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
            System.Media.SoundPlayer scrollLeftSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Left.wav");
            scrollLeftSound.Play();
        }

        private void ScrollRight()
        {
            System.Media.SoundPlayer scrollRightSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Right.wav");
            scrollRightSound.Play();
        }

        private void ScrollUp()
        {
            System.Media.SoundPlayer scrollUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Up.wav");
            scrollUpSound.Play();
        }

        private void ScrollDown()
        {
            System.Media.SoundPlayer scrollDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Down.wav");
            scrollDownSound.Play();
        }

        private void ZoomIn()
        {
            System.Media.SoundPlayer zoomInSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom In.wav");
            zoomInSound.Play();
        }

        private void ZoomOut()
        {
            System.Media.SoundPlayer zoomOutSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Volume Down.wav");
            zoomOutSound.Play();
        }

        private void PlaceMarker()
        {
            System.Media.SoundPlayer placeMarkerSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Place Marker.wav");
            placeMarkerSound.Play();
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }
    }
}
