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
        public Music()
        {
            InitializeComponent();
        }

        public void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers){
            switch(type){
                case AcceptedGestures.GoBack:
                    GoBack(cd, observers);
                    break;
                case AcceptedGestures.SwipeLeft:
                    NextSong();
                    break;
                case AcceptedGestures.SwipeRight:
                    PreviousSong();
                    break;
                case AcceptedGestures.RotateClockwise:
                    TurnUp();
                    break;
                case AcceptedGestures.RotateAntiCLockwise:
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
            throw new NotImplementedException();
        }

        private void PreviousSong()
        {
            throw new NotImplementedException();
        }

        private void TurnUp()
        {
            throw new NotImplementedException();
        }

        private void TurnDown()
        {
            throw new NotImplementedException();
        }

        private void Interact()
        {
            throw new NotImplementedException();
        }

        public void setWindow(MainWindow mw)
        {
            this.mw = mw;
        }
        
    }
    
}
