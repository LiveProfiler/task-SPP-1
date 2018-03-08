using System;
using System.IO;

namespace Ford_Bellman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var lines = File.ReadAllLines("in.txt");
                File.WriteAllLines("out.txt", Solver.Solve(lines));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File in.txt is not found");
            }
            
        }
    }
}
