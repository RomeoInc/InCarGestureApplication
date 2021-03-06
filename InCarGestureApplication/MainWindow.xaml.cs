﻿using Leap;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public StartMenu startScreen;
        /*private Music musicScreen;
        private GPS gpsScreen;
        private Contacts contactScreen;
        private Extras extrasScreen;*/
        
        public MainWindow()
        {
            startScreen = new StartMenu();
            startScreen.setWindow(this);
            /*musicScreen = new Music();
            gpsScreen = new GPS();
            contactScreen = new Contacts();
            extrasScreen = new Extras();*/

            InitializeComponent();
            this.window.Children.Add(startScreen);
            System.Media.SoundPlayer welcomeSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Hello.wav");
            welcomeSound.Play();
            //System.Threading.Thread.Sleep(1500);
        }

        public void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ActiveControl = startScreen;
            LeapInterface leap = new LeapInterface();
            GestureSpace space = new GestureSpace();
         
            Program.InitialiseCount(leap, space, startScreen);
            //System.Threading.Thread.Sleep(1000);

            Console.ReadLine();

            //leap.Stop();
            //leap.Destroy();
        }

    }
}
