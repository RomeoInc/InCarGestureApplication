﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leap.Gestures.Count
{
    public interface ICountObserver: IParentObserver
    {
        // Count selection updates
        void CountStart(Vector pos, ROI.ROI roi, int count, CountDetector cd, List<IParentObserver> observers);
        void CountStop();
        void CountComplete(Vector pos, ROI.ROI roi, DateTime time, int count, CountDetector cd, List<IParentObserver> observers);
        void CountProgress(long dwellTime, ROI.ROI roi);

        // Cursor position update
        void CursorUpdate(Vector pos, int count, int edge);

        // Tile group updates
        void GroupEnter(String name);
        void GroupLeave(String name);

        // Go back to previous activity
        void Back();
    }
}
