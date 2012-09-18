using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Complex_Calculator
{
    /// -------------------------------------------------------------------------------------
    /// This class is a complex calculator that interacts with the user in command line.
    /// -------------------------------------------------------------------------------------
    class ComplexCalculator
    {
        /// <summary>
        /// runs calculator. Asks for operands and operation input and displays output
        /// </summary>
        public void RunCalculator()
        {
            // displays menu
            displayMenu(); 

            // Enter loop unless user quits
            bool quit = false;
            while (!quit)
            {
                char oper; // operator               
                Complex op1, op2; // operands

                // read the first operand
                op1 = readOperand(1);

                // Read op1 again only if user clears
                bool clear = false;
                while (!clear && !quit)
                {
                    //read operation, op1 passed just to be displayed
                    oper = readOperation(op1);

                    // do appropiate task depending on operation
                    switch (oper)
                    {
                        case 'c':
                            clear = true;
                            break;
                        case 'm':
                            displayMenu();
                            break;
                        case 'q':
                            quit = true;
                            break;
                        default: // it must be an operator (+|-|*|/)
                            // get operand2 
                            op2 = readOperand(2);

                            // calculate and display results
                            Complex result = calculate(op1, op2, oper);
                            Console.WriteLine("{0} {1} {2} = {3}", op1, oper, op2, result);

                            // copy result to op1 for next operation
                            op1 = result;
                            break;
                    }
                }
            }
            Console.WriteLine("Exit Complex Calculator");
        }

        /// <summary>
        /// reads an operand from standard IO
        /// </summary>
        /// <param name="num">
        /// The number of the operand, operand1 or operand2
        /// </param>
        /// <returns>
        /// operand returned as complex number
        /// </returns>
        private Complex readOperand(int num)
        {
            double real, imag;

            // declaring regular expression patterns
            string pattern = @"^\d+\.?\d*\s+\d+\.?\d*$"; // starts with a number followed by space followed by number
            Match match; // for regex use
            string input;

            while (true)
            {
                // get operand1
                Console.Write("Enter operand{0}: ", num);
                input = Console.ReadLine();

                // using regex to match patterns
                match = Regex.Match(input, pattern);
                if (match.Success)
                    break;
                Console.WriteLine("INVALID OPERAND INPUT");
                Console.WriteLine("ENTER AS FOLLOWS: REAL IMAGINARY");
            }

            // parse input
            string[] values = input.Split(' ');
            real = double.Parse(values[0]);
            imag = double.Parse(values[1]);

            return new Complex(real, imag);
        }

        /// <summary>
        /// reads an operation from standard IO
        /// </summary>
        /// <param name="op1">
        /// Operand one is displayed to remind user what it was
        /// </param>
        /// <returns>
        /// returns operation as a character value
        /// </returns>
        private char readOperation(Complex op1)
        {
            string input;
            string pattern = @"^(\+|-|\*|/|m|c|q)$"; // a single specific character regular expression

            while (true)
            {
                // display operand1
                Console.WriteLine("operand1: " + op1);

                // get and parse operator
                Console.Write("Enter Operation: ");
                input = Console.ReadLine();

                // check that a correct single character has been inputed using regular expressions
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                    break;
                Console.WriteLine("INVALID OPERATION ENTRY");
                Console.WriteLine("ENTER +, -, *, /, m or q");
            }

            //return character operator
            return char.Parse(input);
        }

        /// <summary>
        /// performs complex calculation
        /// </summary>
        /// <param name="op1">
        /// first complex operand
        /// </param>
        /// <param name="op2">
        /// second complex operand
        /// </param>
        /// <param name="oper">
        /// third complex operand
        /// </param>
        /// <returns>
        /// returns the result as a complex number
        /// </returns>
        private Complex calculate(Complex op1, Complex op2, char oper)
        {
            Complex result = new Complex();
            switch (oper)
            {
                case '+':
                    result = op1 + op2;
                    break;
                case '-':
                    result = op1 - op2;
                    break;
                case '*':
                    result = op1 * op2;
                    break;
                case '/':
                    result = op1 / op2;
                    break;
            }

            return result;
        }

        /// <summary>
        /// displays menu for program
        /// </summary>
        private void displayMenu()
        {
            Console.WriteLine("Complex Number Calculator");
            Console.WriteLine("     (c)     Clear ");
            Console.WriteLine("     (+)     Add ");
            Console.WriteLine("     (-)     Subtract ");
            Console.WriteLine("     (*)     Multiply ");
            Console.WriteLine("     (/)     Divide ");
            Console.WriteLine("     (m)     Menu ");
            Console.WriteLine("     (q)     Quit ");
            Console.WriteLine("Operation entry: c, +, -, *, /, m or q");
            Console.WriteLine("Operand entry: REAL IMAGINARY");
            Console.WriteLine();
        }
    }
}
