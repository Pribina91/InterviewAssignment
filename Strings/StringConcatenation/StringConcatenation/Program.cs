using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringConcatenation
{
    class Program
    {
        private const string INPUT =
            "al, albums, aver, bar, barely, be, befoul, bums, by, cat, con, convex, ely, foul, here, hereby, jig, jigsaw, or, saw, tail, tailor, vex, we, weaver";

        static void Main(string[] args)
        {
            var p = new WordProcessor(INPUT, 2, 6);

            foreach (var str in p.GetFilteredWords())
            {
                Console.WriteLine(str);
            }
        }
    }
}