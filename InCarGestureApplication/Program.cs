using System;
using System.Collections.Generic;
using System.Threading;
using Leap;
using Leap.ROI;
using Leap.Gestures.Count;
<<<<<<< HEAD
=======
using LeapPointer_PC.Menu;
>>>>>>> 6270c0e373b1529d10bb2519c13fa33455aad1e4
using InCarGestureApplication;


class Program
{
  
    #region Gesture detectors
    public static void InitialiseCount(LeapInterface leap, GestureSpace space, StartMenu menu)
    {
        // Create gesture detector
        CountDetector count = new CountDetector(leap, space);

        // Register regions of interest
        ActivityROIs.ConnectROIs(count);
        count.RegisterObserver(menu);
    }
    #endregion

        #region Utility
    private static void Print(String message)
    {
        Console.WriteLine("{0}", message);
    }
    #endregion
}