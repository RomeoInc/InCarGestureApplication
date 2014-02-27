using Leap.Gestures.Count;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : UserControl, IGestureObserver
    {
        MainWindow mw;
        int selected;
        //Stopwatch stopWatch;

        public Contacts()
        {
            InitializeComponent();
            //Stopwatch stopWatch = new Stopwatch();
            selected = 3;
            Border defaultContact = (Border)ContactList.Children[selected];
            defaultContact.BorderBrush = new SolidColorBrush(Colors.Black);
            defaultContact.Opacity = 1;
        }

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers)
        {
            switch (type)
            {
               /* case AcceptedGestures.GoBack:
                    GoBack(cd, observers);
                    break;*/
                case AcceptedGestures.SwipeUp:
                    PreviousPerson();
                    break;
                case AcceptedGestures.SwipeDown:
                    NextPerson();
                    break;
                case AcceptedGestures.SwipeRight://SelectOption:
                    Call();
                    break;
                case AcceptedGestures.SwipeLeft:
                    HangUp();
                    break;
                default:
                    break;
            }
        }

        private void GoBack(CountDetector cd, List<IParentObserver> observers)
        {
            System.Media.SoundPlayer menuSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Menu.wav");
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

        private void NextPerson()
        {
            ContactList.Dispatcher.Invoke((Action)(() => {
                if (selected < ContactList.Children.Count -1)
                {
                    Border currentContact = (Border)ContactList.Children[selected];
                    currentContact.Opacity = 0.5;
                    currentContact.BorderBrush = new SolidColorBrush(Colors.Transparent);

                    selected++;

                    Border nextContact = (Border)ContactList.Children[selected];
                    nextContact.Opacity = 1;
                    nextContact.BorderBrush = new SolidColorBrush(Colors.Black);

                    System.Media.SoundPlayer nextSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Next.wav");
                    nextSound.Play();

                }
            }));
        }

        private void PreviousPerson()
        {
            ContactList.Dispatcher.Invoke((Action)(() => {
                if (selected > 0)
                {
                    Border currentContact = (Border)ContactList.Children[selected];
                    currentContact.Opacity = 0.5;
                    currentContact.BorderBrush = new SolidColorBrush(Colors.Transparent);
            
                    selected--;

                    Border nextContact = (Border)ContactList.Children[selected];
                    nextContact.Opacity = 1;
                    nextContact.BorderBrush = new SolidColorBrush(Colors.Black);

                    System.Media.SoundPlayer previousSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Previous.wav");
                    previousSound.Play();
                }
            }));
        }

        private void Call()
        {
            DisplayImageArea.Dispatcher.Invoke((Action)(() =>
            {
                Border currentContactBorder = (Border)ContactList.Children[selected];
                Grid currentContact = (Grid)currentContactBorder.Child;
                Image i = currentContact.Children.OfType<Image>().FirstOrDefault();
                String contactImage = Convert.ToString(i.Source);

                String contactName = currentContact.Children.OfType<TextBlock>().FirstOrDefault().Text;
                DisplayImageArea.Source = new BitmapImage(new Uri("" + contactImage + "", UriKind.RelativeOrAbsolute));
                DisplayNameArea.Text = "Calling " + contactName + "...";
                System.Media.SoundPlayer callingSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Calling.wav");
                callingSound.Play();
            }));
            System.Threading.Thread.Sleep(1500);
            System.Media.SoundPlayer ringingSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Ringing.wav");
            ringingSound.Play();
            System.Threading.Thread.Sleep(8000);
            /*stopWatch.Start();
            var timeSpan = TimeSpan.FromMilliseconds(5000);

            var seconds = timeSpan.TotalSeconds;
            var minutes = timeSpan.TotalMinutes;
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            DisplayImageArea.Dispatcher.Invoke((Action)(() =>
            {
                DisplayNameArea.Text = niceTime;
            }));*/
            DisplayNameArea.Dispatcher.Invoke((Action)(() =>
            {
                DisplayNameArea.Text = "Connected";
            }));
            System.Media.SoundPlayer answerSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\MoshiMoshi.wav");
            answerSound.Play();
                        
            //UIElementCollection ui = this.ContactList.Children.OfType<Grid>().All();
        }

        private void HangUp()
        {
            System.Media.SoundPlayer endSound = new System.Media.SoundPlayer(@"C:\Users\Gerard\Documents\Visual Studio 2013\Projects\InCarGestureApplication\InCarGestureApplication\Menu\Audio\Audio Feedback\Hanging Up.wav");
            endSound.Play();
            DisplayNameArea.Dispatcher.Invoke((Action)(() =>
            {
                DisplayNameArea.Text = "Ending Call";
            }));
            System.Threading.Thread.Sleep(1500);
            DisplayNameArea.Dispatcher.Invoke((Action)(() =>
                {
                DisplayImageArea.Source = null;
                DisplayNameArea.Text = "";
            }));
            
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }

    }
}
