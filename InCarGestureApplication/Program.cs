using System;
using System.Collections.Generic;
using System.Threading;
using Leap;
using Leap.ROI;
using Leap.Gestures.Count;
using LeapPointer_PC.Menu;


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