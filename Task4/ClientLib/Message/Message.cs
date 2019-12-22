using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    /// <summary>
    /// Class Message to send it from Client to Server.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Message text.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Client who send this Message.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the Message class.
        /// </summary>
        /// <param name="text">Message text.</param>
        /// <param name="client">Client who send this Message.</param>
        public Message(string text, Client client)
        {
            Text = text;
            Client = client;
        }
        
        /// <summary>
        /// Returns a string representing the current message.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Text: " + Text + "; Client: " + Client.Name;
        }
    }
}
