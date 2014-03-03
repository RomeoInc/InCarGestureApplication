using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leap.Gestures.Count
{
    public interface IParentObserver
    {
        // Workspace updates
        void EnterWorkspace(int hands, int fingers);
        void LeaveWorkspace(int dummyToAllowOverriding);
    }
}
