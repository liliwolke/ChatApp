namespace Chat.Models
{
    using System;

    public class ClientMessage
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public ClientMessage(string username, string message)
        {
            Username = username;
            Message = message;
            Timestamp = DateTime.Now;
        }
    }
}    