using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEvent
{
    class Event_Interface
    {
        public interface IDrawingObject
        { 
            /// <summary>
            /// <!-- Raise this event before drawing
            /// the object. >
            /// </summary>
            event EventHandler OnDraw;
        }
        public interface IShape
        {
            // Raise this event after drawing
            // the shape.
            event EventHandler OnDraw;
        }
        /// <summary>
        /// <!-- Base class event publisher inherits two
        /// < interfaces  each with an OnDraw event>
        /// </summary>


        public class Shape : IDrawingObject ,IShape
        {
            /// <summary>
            /// <!--Create an event for each interface event >
            /// </summary>
            event EventHandler PreDrawEvent;
            event EventHandler PostDrawEvent;

            object objectLock = new Object();

            // Explicit interface implementation required.
            // Associate IDrawingObject's event with
            // PreDrawEvent
            event EventHandler IDrawingObject.OnDraw
            {
                add
                {
                    lock (objectLock)
                    {
                        PreDrawEvent += value;
                    }
                }
                remove
                {
                    lock (objectLock)
                    {
                        PreDrawEvent -= value;
                    }
                }
            }
            // Explicit interface implementation required.
            // Associate IShape's event with
            // PostDrawEvent
           event EventHandler IShape.OnDraw
            {
                add
                {
                    lock (objectLock)
                    {
                        PostDrawEvent += value;
                    }
                }
                remove
                {
                    lock (objectLock)
                    {
                        PostDrawEvent -= value;
                    }
                }


            } 

            // For the sake of simplicity this one method
            // implements both interfaces. 
            public void Draw()
            {
                // Raise IDrawingObject's event before the object is drawn.
                EventHandler handler = PreDrawEvent;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
                Console.WriteLine("Drawing a shape.");

                // RaiseIShape's event after the object is drawn.
                handler = PostDrawEvent;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
        }
        public class Subscriber1
        {
            // References the shape object as an IDrawingObject
            public Subscriber1(Shape shape)
            {
                IDrawingObject d = (IDrawingObject)shape;
                d.OnDraw += new EventHandler(d_OnDraw);
            }

            void d_OnDraw(object sender, EventArgs e)
            {
                Console.WriteLine("Sub1 receives the IDrawingObject event.");
            }
        } 
        public class Program
        {
            static void Main(string[] args)
            {
                Shape shape = new Shape();
                Subscriber1 sub = new Subscriber1(shape);       

                shape.Draw();
              
                // Keep the console window open in debug mode.
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }

    }
}
