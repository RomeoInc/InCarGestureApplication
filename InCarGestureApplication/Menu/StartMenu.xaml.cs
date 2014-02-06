using Leap.Gestures.Count;
using Leap.ROI;
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
using InCarGestureApplication;

namespace InCarGestureApplication
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : UserControl, ICountObserver
    {
        MainWindow mw;
        Music musicScreen;
        GPS gpsScreen;
<<<<<<< HEAD
        Contacts contactScreen;
=======
>>>>>>> 6270c0e373b1529d10bb2519c13fa33455aad1e4

        public StartMenu()
        {
            InitializeComponent();
            musicScreen = new Music();
            gpsScreen = new GPS();
<<<<<<< HEAD
            contactScreen = new Contacts();
=======
>>>>>>> 6270c0e373b1529d10bb2519c13fa33455aad1e4
        }

        public void EnterWorkspace(int hands, int fingers) { }
        public void LeaveWorkspace(int dummyToAllowOverriding) { }

        // Count selection updates
        public void CountStart(Leap.Vector pos, ROI roi,  int count, CountDetector cd) 
        {
            switch (count)
            {
                case 1:
                    cd.RegisterObserver(musicScreen);
<<<<<<< HEAD
                    mw.Dispatcher.Invoke((Action)(() => {
                        mw.window.Children.Add(musicScreen);
                    }));
                    break;
                case 2:
                    cd.RegisterObserver(gpsScreen);
                    mw.Dispatcher.Invoke((Action)(() => {
                        mw.window.Children.Add(gpsScreen);
                    }));
                    break;
                case 3:
                    cd.RegisterObserver(contactScreen);
                    mw.Dispatcher.Invoke((Action)(() => {
                        mw.window.Children.Add(contactScreen);
                    }));
                    break;
                default:
=======

                    mw.Dispatcher.Invoke((Action)(() => {
                        mw.window.Children.Add(musicScreen);

                    }));
                    break;
                case 2:
                    mw.Dispatcher.Invoke((Action)(() => {
                        mw.window.Children.Add(gpsScreen);
                    }));
                case 3:
>>>>>>> 6270c0e373b1529d10bb2519c13fa33455aad1e4
                    break;
            }
        }
        public void CountStop() { }
        public void CountComplete(Leap.Vector pos, ROI roi, DateTime time, int count) { }
        public void CountProgress(long dwellTime, ROI roi) { }

        // Cursor position update
        public void CursorUpdate(Leap.Vector pos, int count, int edge) { }

        // Tile group updates
        public void GroupEnter(String name) { }
        public void GroupLeave(String name) { }

        public void Back() { }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }

    }
}
