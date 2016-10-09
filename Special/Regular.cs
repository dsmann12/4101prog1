
// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        // TODO: Add any fields needed.
    
        // TODO: Add an appropriate constructor.
        public Regular() { }


        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.''
            if (p == false)
            {
                if (n > 0)
                {
                    Console.WriteLine();
                    for (int i = 0; i < (4*n); i++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("(");
                    p = true;
                    n = n - 1;
                }
                else
                {
                    Console.Write('(');
                    p = true;
                }
            }
            if (t.getCar().isPair())
            {
                t.getCar().print(n, false);
            }
            else
            {
                t.getCar().print(n, p);
            }

            if (!t.getCdr().isNull())
                Console.Write(" ");

            t.getCdr().print(n, p);

        }
    }
}


