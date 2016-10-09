// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            if (p == false)
            {
                Console.Write("(");
                p = true;
            }

            t.getCar().print(n, p);
            Console.WriteLine();
            t.getCdr().print(4*(n+1), p);

        }
    }
}

