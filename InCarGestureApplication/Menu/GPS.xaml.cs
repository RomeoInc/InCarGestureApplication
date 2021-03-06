﻿using Leap.Gestures.Count;
using InCarGestureApplication;
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
        int horizontal;
        int vertical;
        bool zoom;

        public GPS()
        {
            InitializeComponent();
            horizontal = 0;
            vertical = 0;
            zoom = false;
        }

        public void EnterWorkspace(int hands, int fingers)
        {
            Detector.Dispatcher.Invoke((Action)(() =>
            {
                Detector.Fill = new SolidColorBrush(Colors.Green);
            }));
        }

        public void LeaveWorkspace(int dummyToAllowOverriding)
        {
            Detector.Dispatcher.Invoke((Action)(() =>
            {
                Detector.Fill = new SolidColorBrush(Colors.Red);
            }));
        }

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers)
        {
            switch (type)
            {
               /* case AcceptedGestures.GoBack:
                    Back(cd, observers);
                    break;*/
                case AcceptedGestures.SwipeRight:
                    ScrollLeft();
                    break;
                case AcceptedGestures.SwipeLeft:
                    ScrollRight();
                    break;
                case AcceptedGestures.SwipeDown:
                    ScrollUp();
                    break;
                case AcceptedGestures.SwipeUp:
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
            mw.Dispatcher.Invoke((Action)(() =>
            {
                mw.window.Children.Remove(mw.window.Children[mw.window.Children.Count - 1]);
            }));
            System.Media.SoundPlayer menuSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Home.wav");
            menuSound.Play();
            //startScreen 
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
            swipeRight.Dispatcher.Invoke((Action)(() =>
            {
                swipeRight.Opacity = 1;
            }));
            if (horizontal >= 0 && vertical == 0 && !zoom)
            {
                if (horizontal == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Left.png", UriKind.RelativeOrAbsolute));
                        horizontal--;
                        System.Media.SoundPlayer scrollLeftSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Left.wav");
                        scrollLeftSound.Play();
                        swipeUp.Opacity = 0.2;
                        swipeDown.Opacity = 0.2;
                    }));
                }

                else if (horizontal == 1)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Default.png", UriKind.RelativeOrAbsolute));
                        horizontal--;
                        System.Media.SoundPlayer scrollLeftSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Left.wav");
                        scrollLeftSound.Play();
                        swipeUp.Opacity = 1;
                        swipeDown.Opacity = 1;
                    }));
                }
                if (horizontal == -1)
                {
                    swipeLeft.Dispatcher.Invoke((Action)(() =>
                    {
                        swipeLeft.Opacity = 0.2;
                    }));
                }
            }
        }

        private void ScrollRight()
        {
            swipeLeft.Dispatcher.Invoke((Action)(() =>
            {
                swipeLeft.Opacity = 1;
            }));


            if (horizontal <= 0 && vertical == 0 && !zoom)
            {
                if (horizontal == -1)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Default.png", UriKind.RelativeOrAbsolute));
                        horizontal++;
                        System.Media.SoundPlayer scrollRightSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Right.wav");
                        scrollRightSound.Play();
                        swipeUp.Opacity = 1;
                        swipeDown.Opacity = 1;
                    }));
                }

                else if (horizontal == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Right.png", UriKind.RelativeOrAbsolute));
                        horizontal++;
                        System.Media.SoundPlayer scrollRightSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Right.wav");
                        scrollRightSound.Play();
                        swipeUp.Opacity = 0.2;
                        swipeDown.Opacity = 0.2;
                    }));
                }
                if (horizontal == 1)
                {
                    swipeRight.Dispatcher.Invoke((Action)(() =>
                    {
                        swipeRight.Opacity = 0.2;
                    }));
                }
            }
        }

        private void ScrollUp()
        {
            swipeDown.Dispatcher.Invoke((Action)(() =>
            {
                swipeDown.Opacity = 1;
            }));
            if (vertical <= 0 && horizontal == 0 && !zoom)
            {
                if (vertical == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Up.png", UriKind.RelativeOrAbsolute));
                        vertical++;
                        System.Media.SoundPlayer scrollUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Up.wav");
                        scrollUpSound.Play();
                        swipeLeft.Opacity = 0.2;
                        swipeRight.Opacity = 0.2;
                    }));
                }

                else if (vertical == -1)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Default.png", UriKind.RelativeOrAbsolute));
                        vertical++;
                        System.Media.SoundPlayer scrollUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Up.wav");
                        scrollUpSound.Play();
                        swipeLeft.Opacity = 1;
                        swipeRight.Opacity = 1;
                    }));
                }
                if (vertical == 1)
                {
                    swipeUp.Dispatcher.Invoke((Action)(() =>
                    {
                        swipeUp.Opacity = 0.2;
                    }));
                }
            }
        }

        private void ScrollDown()
        {
            swipeUp.Dispatcher.Invoke((Action)(() =>
            {
                swipeUp.Opacity = 1;
            }));
            if (vertical >= 0 && horizontal == 0 && !zoom)
            {
                if (vertical == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Down.png", UriKind.RelativeOrAbsolute));
                        vertical--;
                        System.Media.SoundPlayer scrollDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Down.wav");
                        scrollDownSound.Play();
                        swipeLeft.Opacity = 0.2;
                        swipeRight.Opacity = 0.2;
                    }));
                }

                else if (vertical == 1)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Default.png", UriKind.RelativeOrAbsolute));
                        vertical--;
                        System.Media.SoundPlayer scrollDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Scroll Down.wav");
                        scrollDownSound.Play();
                        swipeLeft.Opacity = 1;
                        swipeRight.Opacity = 1;
                    }));
                }
                if (vertical == -1)
                {
                    swipeDown.Dispatcher.Invoke((Action)(() =>
                    {
                        swipeDown.Opacity = 0.2;
                    }));
                }
            }
        }

        private void ZoomIn()
        {
            if (!zoom)
            {
                zoomIn.Dispatcher.Invoke((Action)(() =>
                {
                    zoomIn.Visibility = Visibility.Hidden;
                    zoomOut.Visibility = Visibility.Visible;
                }));
                if (horizontal == 0 && vertical == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Default Zoom.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomInSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom In.wav");
                    zoomInSound.Play();
                    zoom = true;
                }
                else if (horizontal == 0 && vertical == 1)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Up Zoom.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomInSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom In.wav");
                    zoomInSound.Play();
                    zoom = true;
                }
                else if (horizontal == 0 && vertical == -1)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Down Zoom.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomInSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom In.wav");
                    zoomInSound.Play();
                    zoom = true;
                }
                else if (horizontal == 1 && vertical == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Right Zoom.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomInSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom In.wav");
                    zoomInSound.Play();
                    zoom = true;
                }
                else if (horizontal == -1 && vertical == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Left Zoom.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomInSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom In.wav");
                    zoomInSound.Play();
                    zoom = true;
                }
            }
        }

        private void ZoomOut()
        {
            if (zoom)
            {
                zoomIn.Dispatcher.Invoke((Action)(() => {
                    zoomIn.Visibility = Visibility.Visible;
                    zoomOut.Visibility = Visibility.Hidden;
                }));

                if (horizontal == 0 && vertical == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Default.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomOutSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom Out.wav");
                    zoomOutSound.Play();
                    zoom = false;
                }
                else if (horizontal == 0 && vertical == 1)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Up.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomOutSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom Out.wav");
                    zoomOutSound.Play();
                    zoom = false; 
                }
                else if (horizontal == 0 && vertical == -1)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Down.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomOutSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom Out.wav");
                    zoomOutSound.Play();
                    zoom = false;
                }
                else if (horizontal == 1 && vertical == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Right.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomOutSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom Out.wav");
                    zoomOutSound.Play();
                    zoom = false;
                }
                else if (horizontal == -1 && vertical == 0)
                {
                    MapArea.Dispatcher.Invoke((Action)(() =>
                    {
                        MapArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Map\Left.png", UriKind.RelativeOrAbsolute));
                    }));
                    System.Media.SoundPlayer zoomOutSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Zoom Out.wav");
                    zoomOutSound.Play();
                    zoom = false;
                }
            }
            
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
