// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            if (p == false)
            {
                Console.Write('(');
                p = true;
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


