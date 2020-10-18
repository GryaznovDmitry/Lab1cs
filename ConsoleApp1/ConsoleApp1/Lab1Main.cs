using System;
using System.Numerics;

namespace GryaznovLab1
{
    public class Lab1Main
    {
        static void Main()
        {
            Grid2D item = new Grid2D(10, 10, 3, 3);
            
            Console.WriteLine("\n\nPoint 1\n\n");

            V5DataOnGrid DoG = new V5DataOnGrid("Directed by Gryaznov D.", DateTime.Now, item);
            DoG.InitRandom(0, 10);
            Console.WriteLine(DoG.ToLongString());
            V5DataCollection DC = (V5DataCollection)DoG;
            Console.WriteLine(DC.ToLongString());

            Console.WriteLine("\n\nPoint 2\n\n");

            V5MainCollection MC = new V5MainCollection();
            MC.AddDefaults();
            Console.WriteLine(MC.ToString());

            Console.WriteLine("\n\nPoint 3\n\n");

            Vector2[] array;
            foreach (V5Data obj in MC)
            {
                array = obj.NearEqual(2);
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine("[" + array[i].X + ", " + 
                                            array[i].Y + "]");
                }
            }
        }
    }
}
