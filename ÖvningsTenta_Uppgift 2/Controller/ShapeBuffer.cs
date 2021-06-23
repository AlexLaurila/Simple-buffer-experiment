using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ÖvningsTenta_Uppgift_2
{
    class ShapeBuffer
    {
        private int queue = 0;
        private int maxQueueSize = 2;
        ManualResetEvent queueFullEvent = new ManualResetEvent(false);
        ManualResetEvent queueEmptyEvent = new ManualResetEvent(false);
        private List<SimpleShape> waitingList = new List<SimpleShape>();

        public void Write(SimpleShape shape)
        {
            if (queue >= maxQueueSize)
            {
                queueFullEvent.Reset();
                queueFullEvent.WaitOne();
            }

            waitingList.Add(shape);
            queueEmptyEvent.Set();
            queue++;
        }

        public SimpleShape Read()
        {
            if (queue == 0)
            {
                queueEmptyEvent.Reset();
                queueEmptyEvent.WaitOne();
            }
                
            SimpleShape shape = waitingList.First();
            waitingList.Remove(shape);

            queueFullEvent.Set();
            queue--;
            return shape;
        }
    }
}
