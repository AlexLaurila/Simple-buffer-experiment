using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ÖvningsTenta_Uppgift_2
{
    class ShapeBuffer2
    {
        private int queue = 0;
        private int maxQueueSize = 2;
        private List<SimpleShape> waitingList = new List<SimpleShape>(2);

        public void Write(SimpleShape shape)
        {

            lock (this)
            {
                if (queue >= maxQueueSize)
                    Monitor.Wait(this);

                waitingList.Add(shape);
                Monitor.Pulse(this);
                queue++;
            }
        }

        public SimpleShape Read()
        {
            lock (this)
            {
                if (queue == 0)
                    Monitor.Wait(this);

                SimpleShape shape = waitingList.First();
                waitingList.Remove(shape);

                Monitor.Pulse(this);
                queue--;
                return shape;
            }
        }
    }
}
