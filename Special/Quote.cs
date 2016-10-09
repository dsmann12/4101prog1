// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
  
        // TODO: Add an appropriate constructor.
	public Quote() { }

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
                    Console.Write("'(");
                    p = true;
                    n = n - 1;
                }
                else
                {
                    Console.Write("'(");
                    p = true;
                }
            }
            t.getCdr().print(n, p);
        }
    }
}

