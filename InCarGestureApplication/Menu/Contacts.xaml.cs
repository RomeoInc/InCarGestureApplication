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

        public Contacts()
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
            throw new NotImplementedException();
        }

        private void PreviousPerson()
        {
            throw new NotImplementedException();
        }

        private void Call()
        {
            throw new NotImplementedException();
        }

        private void HangUp()
        {
            throw new NotImplementedException();
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }

    }
}
