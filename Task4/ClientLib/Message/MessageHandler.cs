using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    /// <summary>
    /// Delegate describing the method of processing the text of the message.
    /// </summary>
    /// <returns></returns>
    public delegate string ReceiveMsg();

    /// <summary>
    /// Class for processing messages.
    /// </summary>
    public class ClientMessageHandler
    {
        /// <summary>
        /// Message Receive Event.
        /// </summary>
        public event ReceiveMsg OnLoadMsg;
    }
}
