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
        bool songState;

        public Music()
        {
            InitializeComponent();
            songState = true;
            songNumber = 1;
            volume = 50;
            volumeScale = 5;
            currentSong.Dispatcher.Invoke((Action)(() =>
            {
                currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\Allegro.mp3", UriKind.RelativeOrAbsolute);
            }));
        }

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers){
            switch(type){
                case AcceptedGestures.GoBack:
                    GoBack(cd, observers);
                    break;
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
                case AcceptedGestures.SelectOption:
                    Interact();
                    break;
                default:
                    break;
                }
        }

        private void GoBack(CountDetector cd, List<IParentObserver> observers)
        {
            System.Media.SoundPlayer menuSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Driver Window Down.wav");
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
            System.Media.SoundPlayer nextSongSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Next Song.wav");
            nextSongSound.Play();
        }

        private void PreviousSong()
        {
            System.Media.SoundPlayer previousSongSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Previous Song.wav");
            previousSongSound.Play();
        }

        private void TurnUp()
        {
            currentSong.Dispatcher.Invoke((Action)(() =>
            {
                if (!songState)
                {
                    System.Media.SoundPlayer pauseSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Pause.wav");
                    pauseSound.Play();
                    currentSong.Pause();
                    Play.Visibility = Visibility.Visible;
                    Pause.Visibility = Visibility.Hidden;
                    songState = true;
                }
                else
                {
                    System.Media.SoundPlayer playSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Play.wav");
                    playSound.Play();
                    currentSong.Play();
                    Pause.Visibility = Visibility.Visible;
                    Play.Visibility = Visibility.Hidden;
                    songState = false;
                }
            }));
            /*currentSong.Dispatcher.Invoke((Action)(() => {
                if (volumeScale > VolumeSlider.Minimum && volumeScale < VolumeSlider.Maximum)
                {
                    System.Media.SoundPlayer volumeUpSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Volume Up.wav");
                    volumeUpSound.Play();
                    volume = volume + 10;
                    volumeScale++;
                    currentSong.Volume = volume;
                    VolumeSlider.Value = volumeScale;
                }                
            }));*/
        }

        private void TurnDown()
        {
            currentSong.Dispatcher.Invoke((Action)(() => {
                if (volumeScale > VolumeSlider.Minimum && volumeScale <= VolumeSlider.Maximum)
                {
                    System.Media.SoundPlayer volumeDownSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Volume Down.wav");
                    volumeDownSound.Play();
                    volume = volume - 10;
                    volumeScale--;
                    currentSong.Volume = volume;
                    VolumeSlider.Value = volumeScale;
                }
            }));
        }

        private void Interact()
        {
            currentSong.Dispatcher.Invoke((Action)(() => {
                currentSong.Source = new Uri(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Music\Allegro.mp3", UriKind.RelativeOrAbsolute);

                if (currentSong.CanPause)
                {
                    currentSong.Pause();
                    Play.Visibility = Visibility.Visible;
                    Pause.Visibility = Visibility.Hidden;
                    System.Media.SoundPlayer pauseSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Pause.wav");
                    pauseSound.Play();
                }
                else
                {
                    currentSong.Play();
                    Pause.Visibility = Visibility.Visible;
                    Play.Visibility = Visibility.Hidden;
                    System.Media.SoundPlayer playSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Play.wav");
                    playSound.Play();
                }
            }));
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }
        
    }
    
}
