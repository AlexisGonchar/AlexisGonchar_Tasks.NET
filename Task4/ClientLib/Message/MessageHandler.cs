using System.Collections.Generic;

namespace ClientLib
{
    /// <summary>
    /// Delegate describing the method of processing the text of the message.
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public delegate string ReceiveClientMsg(string msg);

    /// <summary>
    /// Delegate describing the method of added the message in list.
    /// </summary>
    /// <param name="msg"></param>
    public delegate void ReceiveServerMsg(Message msg);

    /// <summary>
    /// Class for processing messages.
    /// </summary>
    public class ClientMessageHandler
    {
        /// <summary>
        /// Message Receive Event.
        /// </summary>
        public event ReceiveClientMsg MsgEvent;

        /// <summary>
        /// Method for call event.
        /// </summary>
        /// <param name="msg"></param>
        public string OnLoadMessage(string msg)
        {
            return MsgEvent(msg);
        }

    }

    /// <summary>
    /// Class for added messages.
    /// </summary>
    public class ServerMessageHandler
    {
        /// <summary>
        /// Message Receive Event.
        /// </summary>
        public event ReceiveServerMsg MsgEvent;

        /// <summary>
        /// List of received messages.
        /// </summary>
        public List<Message> messages = new List<Message>();

        /// <summary>
        /// Method for call event.
        /// </summary>
        /// <param name="msg"></param>
        public void OnLoadMessage(Message msg)
        {
            MsgEvent(msg);
        }
    }
}
