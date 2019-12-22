namespace ClientLib
{
    /// <summary>
    /// Client class to communicate with the server using the TCP/IP Protocol stack.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client's name.
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// Initializes a new instance of the Client class.
        /// </summary>
        /// <param name="name">Client's name.</param>
        public Client(string name)
        {
            Name = name;
        }
    }
}
