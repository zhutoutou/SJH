using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.XJHServer.bsController
{
    /// <summary>
    /// Stores message to be used by an event.
    /// </summary>
    public class DisplayMessageEventArgs : EventArgs
    {
        /// <summary>
        /// NetStatus object that is associated with this event.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Creates a new StatusEventArgs object.
        /// </summary>
        /// <param name="status">NetStatus object that is associated with this event</param>
        public DisplayMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
