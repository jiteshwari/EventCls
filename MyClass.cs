using log4net.Config;
using System;

namespace ClsEvent
{
    /// <summary>
    /// Myclass is a public
    /// </summary>
    /// "T:ClsEvent.MyClass"
    public class MyClass
    {
        public delegate void MyDelegate(string message);
        public event MyDelegate MyEvent;
        /// <summary>
        ///  string type field message
        /// </summary>


        public void RaiseEvent(string message)
        {
            if (MyEvent != null)
                MyEvent(message);
        }
    }
    class ClsProerty
    {
        static void Main(string[] args)
        {

            MyClass obj1 = new MyClass();
            obj1.MyEvent += new MyClass.MyDelegate(obj1_MyEvent);
            Console.WriteLine("enter message");
            string msg = Console.ReadLine();
            obj1.RaiseEvent(msg); //here is we raise the event.
            Console.Read();
        }
        //this method will be executed when the event raised.

        static void obj1_MyEvent(string message)
        { 
            Console.WriteLine("Your Message is: {0}", message);
             
        }
    }
}
 
 

