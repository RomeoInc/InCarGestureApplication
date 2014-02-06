using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leap.Gestures.Count
{
    public interface IGestureObserver: IParentObserver
    {
        void GestureComplete(AcceptedGestures type, CountDetector cd, List<IParentObserver> observers);
    }
}
