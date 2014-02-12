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
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : UserControl, IGestureObserver
    {
        MainWindow mw;
        int selected;

        public Contacts()
        {
            selected = 3;
            InitializeComponent();

            Border defaultContact = (Border)ContactList.Children[selected];
            defaultContact.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers)
        {
            switch (type)
            {
                case AcceptedGestures.GoBack:
                    GoBack(cd, observers);
                    break;
                case AcceptedGestures.SwipeUp:
                    NextPerson();
                    break;
                case AcceptedGestures.SwipeDown:
                    PreviousPerson();
                    break;
                case AcceptedGestures.SelectOption:
                    Call();
                    break;
                case AcceptedGestures.AnswerCall:
                    HangUp();
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

        private void NextPerson()
        {
            if (selected < ContactList.Children.Count -1)
            {
                Border currentContact = (Border)ContactList.Children[selected];
                currentContact.BorderBrush = new SolidColorBrush(Colors.Transparent);


                selected++;

                Border nextContact = (Border)ContactList.Children[selected];
                nextContact.BorderBrush = new SolidColorBrush(Colors.Black);
            }
        }

        private void PreviousPerson()
        {
            if (selected > 0)
            {
                Border currentContact = (Border)ContactList.Children[selected];
                currentContact.BorderBrush = new SolidColorBrush(Colors.Transparent);
            
                selected--;

                Border nextContact = (Border)ContactList.Children[selected];
                nextContact.BorderBrush = new SolidColorBrush(Colors.Black);
            }
        }

        private void Call()
        {
            Border currentContactBorder = (Border)ContactList.Children[selected];
            Grid currentContact = (Grid) currentContactBorder.Child;
            Image i = currentContact.Children.OfType<Image>().FirstOrDefault();
            String contactImage = Convert.ToString(i.Source);

            String contactName = currentContact.Children.OfType<TextBlock>().FirstOrDefault().Text;
            DisplayImageArea.Source = new BitmapImage(new Uri(""+contactImage+"", UriKind.Relative)); 
            DisplayNameArea.Text = "Calling" + contactName;
            //UIElementCollection ui = this.ContactList.Children.OfType<Grid>().All();
        }

        private void HangUp()
        {
            DisplayImageArea.Source = null;
            DisplayNameArea.Text = "";
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }

    }
}
