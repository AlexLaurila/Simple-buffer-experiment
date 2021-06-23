using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ÖvningsTenta_Uppgift_2
{
    class ShapeGeneratorTask
    {
        public void Run(ShapeBuffer2 buffer)
        {
            int number;

            while (true)
            {
                Random numberGenerator = new Random();
                number = numberGenerator.Next(1, 3);

                if (number == 1)
                {
                    CircleShape circle = new CircleShape();
                    buffer.Write(circle);
                }
                else
                {
                    SquareShape square = new SquareShape();
                    buffer.Write(square);
                }

                number = numberGenerator.Next(1000, 5000);
                Thread.Sleep(number);
            }
        }
    }
}
