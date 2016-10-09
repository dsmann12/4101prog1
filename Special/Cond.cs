// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Cond() { }

        public override void print(Node t, int n, bool p)
        {
            if (p == false)
            {
                if (n > 0)
                {
                    Console.WriteLine();
                    for (int i = 0; i < (4 * n); i++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("(");
                    p = true;
                }
                else
                {
                    Console.Write("(");
                    p = true;
                }
            }

            t.getCar().print(n, p);
            //Console.WriteLine();
            t.getCdr().print(n + 1, p);
        }
    }
}


