using log4net.Config;
using System;

namespace  ClsEvent
{
    public delegate string MyDel(string str);
    /// <summary>
    /// delegate type for the eventmust be declared
    /// </summary>

    class Event
    {
        event MyDel MyEvent;
        /// <summary>
        /// the event is itself declared, using the event keyword
        /// </summary>

        public Event()
        {
            this.MyEvent += new MyDel(this.Hi);
        }

        public string Hi(string username)
        {
            return "Welcome " + username;
        }

        static void Main(string[] args)
        {
            Event obj1 = new Event();
            string result = obj1.MyEvent("js");
            Console.WriteLine(result);
            Console.Read();
        }

    }
}