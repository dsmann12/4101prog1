// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.

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

            t.getCdr().print(n + 1, p);
            //t.getCdr().getCar().print(n, p);
            //t.getCdr().getCdr().print(n+1, p);
        }
    }
}

