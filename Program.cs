using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Drawing.Imaging;
using System.IO;


namespace Aont
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            int Row = int.Parse(args[0]);
            int Column;
            if (args.Length == 1)
            { Column = Row; }
            else
            { Column = int.Parse(args[1]); }

            Table[] Solutions = Solver.Solve(Row, Column);
            DateTime end = DateTime.Now;
            {
                int i = 0;
                string FolderName = string.Format("{0}x{1}", Row, Column);
                Directory.CreateDirectory(FolderName);
                Directory.SetCurrentDirectory(FolderName);

                foreach (Table Solution in Solutions)
                {
                   // Console.WriteLine(Solution.Show());
                    Solution.Save().Save(string.Format("{0}.png", i), ImageFormat.Png);
                    i++;
                }
            }
            Console.WriteLine("Finished!");
            Console.WriteLine("Required Time (sec) : {0}", (end - start).TotalSeconds);
            //Console.ReadKey(true);

        }
    }
}
