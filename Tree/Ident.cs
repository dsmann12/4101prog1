// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public string getName()
        {
            return name;
        }

        public override void print(int n)
        {
            // There got to be a more efficient way to print n spaces.
            //for (int i = 0; i < n; i++)
            //      Console.Write(" ");

            if (n > 0)
            {
                Console.WriteLine();
                for (int i = 0; i < (4 * n); i++)
                {
                    Console.Write(" ");
                }
                Console.Write(name);
            }
            else
            {
                Console.Write(name);
            }
        }

        public override bool isSymbol()
        {
            return true;
        }
    }
}

