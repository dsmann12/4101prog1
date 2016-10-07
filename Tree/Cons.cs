// Cons -- Parse tree node class for representing a Cons node

using System;

namespace Tree
{
    public class Cons : Node
    {
        private Node car;
        private Node cdr;
        private Special form;
    
        public Cons(Node a, Node d)
        {
            car = a;
            cdr = d;
            parseList();
        }
    
        // parseList() `parses' special forms, constructs an appropriate
        // object of a subclass of Special, and stores a pointer to that
        // object in variable form.  It would be possible to fully parse
        // special forms at this point.  Since this causes complications
        // when using (incorrect) programs as data, it is easiest to let
        // parseList only look at the car for selecting the appropriate
        // object from the Special hierarchy and to leave the rest of
        // parsing up to the interpreter.
        void parseList()
        {
            // TODO: implement this function and any helper functions
            // you might need.

            if (!car.isSymbol())
            {
                form = new Regular();
            }
            else
            {
                Ident idCar = (Ident) car;
                if(idCar.getName() == "begin")
                {
                    form = new Begin();
                }
                else if(idCar.getName() == "define")
                {
                    form = new Define();
                }
                else if(idCar.getName() == "quote")
                {
                    form = new Quote();
                }
                else if(idCar.getName() == "if")
                {
                    form = new If();
                }
                else if(idCar.getName() == "lambda")
                {
                    form = new Lambda();
                }
                else if(idCar.getName() == "let")
                {
                    form = new Let();
                }
                else if(idCar.getName() == "set!")
                {
                    form = new Set();
                }
                else if(idCar.getName() == "cond")
                {
                    form = new Cond();
                }
                else
                {
                    form = new Regular();
                }
            } 
        }

        public override bool isPair()
        {
            return true;
        }

        public override void print(int n)
        {
            form.print(this, n, false);
        }

        public override void print(int n, bool p)
        {
            form.print(this, n, p);
        }
    }
}

