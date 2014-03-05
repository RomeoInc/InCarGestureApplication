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

namespace InCarGestureApplication
{
    /// <summary>
    /// Interaction logic for Music.xaml
    /// </summary>
    public partial class Music : UserControl, IGestureObserver
    {
        MainWindow mw;
        int songNumber;
        int volume;
        int volumeScale;
        bool paused;

        public Music()
        {
            InitializeComponent();
            paused = true;
            songNumber = 1;
            volume = 50;
            volumeScale = 6;
            currentSong.Dispatcher.Invoke((Action)(() =>
            {
                currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\Allegro.mp3", UriKind.RelativeOrAbsolute);
                DisplayArtworkArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Mozart.jpg", UriKind.RelativeOrAbsolute));
                DisplaySongArea.Text = "Mozart - Allegro";
            }));
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

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers){
            switch(type){
               /* case AcceptedGestures.GoBack:
                    GoBack(cd, observers);
                    break;*/
                case AcceptedGestures.SwipeLeft:
                    PreviousSong();
                    break;
                case AcceptedGestures.SwipeRight:
                    NextSong();
                    break;
                case AcceptedGestures.RotateClockwise:
                    TurnUp();
                    break;
                case AcceptedGestures.RotateAntiClockwise:
                    TurnDown();
                    break;
                case AcceptedGestures.SwipeDown:
                    Interact();
                    break;
                default:
                    break;
                }
        }

        private void GoBack(CountDetector cd, List<IParentObserver> observers)
        {
            System.Media.SoundPlayer menuSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Home.wav");
            menuSound.Play();
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
                
        private void NextSong()
        {
            if (songNumber == 1)
            {
                currentSong.Dispatcher.Invoke((Action)(() =>
                {
                    currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\Rondo.mp3", UriKind.RelativeOrAbsolute);
                    currentSong.Play();
                    DisplayArtworkArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Mozart.jpg", UriKind.RelativeOrAbsolute));
                    DisplaySongArea.Text = "Mozart - Rondo";
                    Play.Visibility = Visibility.Hidden;
                    Pause.Visibility = Visibility.Visible;
                    paused = false;
                }));
                songNumber = 2;
            }
            else if (songNumber == 2)
            {
                currentSong.Dispatcher.Invoke((Action)(() =>
                {
                    currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\The Entertainer.mp3", UriKind.RelativeOrAbsolute);
                    currentSong.Play();
                    DisplayArtworkArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\ScottJoplin.jpg", UriKind.RelativeOrAbsolute));
                    DisplaySongArea.Text = "Scott Joplin - The Entertainer";
                    Play.Visibility = Visibility.Hidden;
                    Pause.Visibility = Visibility.Visible;
                    paused = false;
                }));
                songNumber = 3;
            }
            else if (songNumber == 3)
            {
                currentSong.Dispatcher.Invoke((Action)(() =>
                {
                    currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\Allegro.mp3", UriKind.RelativeOrAbsolute);
                    currentSong.Play();
                    DisplayArtworkArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Mozart.jpg", UriKind.RelativeOrAbsolute));
                    DisplaySongArea.Text = "Mozart - Allegro";
                    Play.Visibility = Visibility.Hidden;
                    Pause.Visibility = Visibility.Visible;
                    paused = false;
                }));
                songNumber = 1;
            }
            System.Media.SoundPlayer nextSongSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Next Song.wav");
            nextSongSound.Play();
        }

        private void PreviousSong()
        {
            if (songNumber == 1)
            {
                currentSong.Dispatcher.Invoke((Action)(() =>
                {
                    currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\The Entertainer.mp3", UriKind.RelativeOrAbsolute);
                    currentSong.Play();
                    DisplayArtworkArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\ScottJoplin.jpg", UriKind.RelativeOrAbsolute));
                    DisplaySongArea.Text = "Scott Joplin - The Entertainer";
                    Play.Visibility = Visibility.Hidden;
                    Pause.Visibility = Visibility.Visible;
                    paused = false;
                }));
                songNumber = 3;
            }
            else if (songNumber == 2)
            {
                currentSong.Dispatcher.Invoke((Action)(() =>
                {
                    currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\Allegro.mp3", UriKind.RelativeOrAbsolute);
                    currentSong.Play();
                    DisplayArtworkArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Mozart.jpg", UriKind.RelativeOrAbsolute));
                    DisplaySongArea.Text = "Mozart - Allegro";
                    Play.Visibility = Visibility.Hidden;
                    Pause.Visibility = Visibility.Visible;
                    paused = false;
                }));
                songNumber = 1;
            }
            else if (songNumber == 3)
            {
                currentSong.Dispatcher.Invoke((Action)(() =>
                {
                    currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\Rondo.mp3", UriKind.RelativeOrAbsolute);
                    currentSong.Play();
                    DisplayArtworkArea.Source = new BitmapImage(new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Images\Mozart.jpg", UriKind.RelativeOrAbsolute));
                    DisplaySongArea.Text = "Mozart - Rondo";
                    Play.Visibility = Visibility.Hidden;
                    Pause.Visibility = Visibility.Visible;
                    paused = false;
                }));
                songNumber = 2;
            }
            System.Media.SoundPlayer previousSongSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Previous Song.wav");
            previousSongSound.Play();
        }

        private void TurnUp()
        {
           currentSong.Dispatcher.Invoke((Action)(() => {
               rotateAC.Opacity = 1;
                if (volumeScale < VolumeSlider.Maximum)
                {
                    System.Media.SoundPlayer volumeUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Volume Up.wav");
                    volumeUpSound.Play();
                    volume = volume + 10;
                    volumeScale++;
                    currentSong.Volume = volume;
                    VolumeSlider.Value = volumeScale;
                }
                if (volumeScale == VolumeSlider.Maximum)
                {
                    rotateC.Opacity = 0.2;
                }
            }));
        }

        private void TurnDown()
        {
            currentSong.Dispatcher.Invoke((Action)(() => {
                rotateC.Opacity = 1;
                if (volumeScale > VolumeSlider.Minimum)
                {
                    System.Media.SoundPlayer volumeDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Volume Down.wav");
                    volumeDownSound.Play();
                    volume = volume - 10;
                    volumeScale--;
                    currentSong.Volume = volume;
                    VolumeSlider.Value = volumeScale;
                }
                if (volumeScale == VolumeSlider.Minimum)
                {
                    rotateAC.Opacity = 0.2;
                }
            }));
        }

        private void Interact()
        {
            currentSong.Dispatcher.Invoke((Action)(() =>
            {
                if (!paused)
                {
                    System.Media.SoundPlayer pauseSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Pause.wav");
                    pauseSound.Play();
                    currentSong.Pause();
                    Play.Visibility = Visibility.Visible;
                    Pause.Visibility = Visibility.Hidden;
                    paused = true;
                }
                else
                {
                    System.Media.SoundPlayer playSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Play.wav");
                    playSound.Play();
                    currentSong.Play();
                    Pause.Visibility = Visibility.Visible;
                    Play.Visibility = Visibility.Hidden;
                    paused = false;
                }
            }));
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }
        
    }
    
}
