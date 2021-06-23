using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ÖvningsTenta_Uppgift_2
{
    class Program
    {
        private static ShapeBuffer2 buffer;

        static void Main(string[] args)
        {
            buffer = new ShapeBuffer2();

            new Thread(() =>
            {
                ShapeGeneratorTask generator = new ShapeGeneratorTask();
                generator.Run(buffer);
            }).Start();

            new Thread(() =>
            {
                ShapeRendererTask renderer = new ShapeRendererTask();
                renderer.Run(buffer);
            }).Start();
        }
    }
}
