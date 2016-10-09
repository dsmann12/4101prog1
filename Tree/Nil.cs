// Nil -- Parse tree node class for representing the empty list

using System;

namespace Tree
{
    public class Nil : Node
    {
        public Nil() { }
  
        public override void print(int n)
        {
            print(n, false);
        }

        public override void print(int n, bool p) {
            // There got to be a more efficient way to print n spaces.
            // for (int i = 0; i < n; i++)
            //       Console.Write(" ");

            if (p)
                if (n > 0)
                {
                    Console.WriteLine();
                    for(int i = 0; i < (4 *(n-1)); i++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(")");
                }
                else
                    Console.Write(")");
            else
            {
                if (n > 0)
                {
                    Console.WriteLine();
                    for(int i = 0; i < (4 * (n-1)); i++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("()");
                }
                else
                {
                    Console.Write("()");
                }
            }
        }

        public override bool isNull()
        {
            return true;
        }
    }
}
