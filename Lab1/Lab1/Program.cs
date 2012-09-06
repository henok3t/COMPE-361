using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab1
{
    /// <summary>
    /// This program converts from one unit to another.
    /// </summary>
    class Program
    {
        // the units envolved for conversion
        enum unit {FEET, METER, MILES, OUNCES, QUARTS, LITERS, SQFEET, SQMILES, ACRES};
              
        /// <summary>
        /// converts from string type to unit type
        /// </summary>
        /// <param name="input">
        /// string input to be converted
        /// </param>
        /// <param name="output">
        /// Unit output
        /// </param>
        /// <returns>
        /// Returns true if convert was successful, false otherwise
        /// </returns>
        static bool stringToUnit(string input, ref unit output)
        {
            // temporary string not to change the value of input
            string temp = input;

            // return value
            bool rv = true;

            // convert to lower case to ignore case
            temp = temp.ToLower();

            // if statement going through each possible case
            if (temp == "feet" || temp == "foot")
                output = unit.FEET;
            else if (temp == "meter" || temp == "meters")
                output = unit.METER;
            else if (temp == "miles" || temp == "mile")
                output = unit.MILES;
            else if (temp == "ounce" || temp == "ounces")
                output = unit.OUNCES;
            else if (temp == "quart" || temp == "quarts")
                output = unit.QUARTS;
            else if (temp == "liters" || temp == "liter")
                output = unit.LITERS;
            else if (temp == "square feet" || temp == "square foot")
                output = unit.SQFEET;
            else if (temp == "square miles" || temp == "square mile")
                output = unit.SQMILES;
            else if (temp == "acre" || temp == "acres")
                output = unit.ACRES;
            else
                rv = false;

            return rv;
        }

        /// <summary>
        /// prints appropriate messages and checks errors for conversion
        /// </summary>
        static void doConversion()
        {
            string from, to, input;
            unit ufrom = unit.FEET, uto = unit.FEET;
            double ov = 0, cv = 0; // ov: original value cv:converted value

            Console.Write("From: ");

            while(true)
            {
                from = Console.ReadLine();
                if (!stringToUnit(from, ref ufrom))
                {
                    Console.ForegroundColor = ConsoleColor.Red; // some color conversions for fun
                    Console.WriteLine("INVALID INPUT");
                    Console.Write("Please enter again: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                    break;
            }

            Console.Write("Value: ");
            input = Console.ReadLine();
            ov = double.Parse(input);
            Console.Write("To: ");
            
            while (true)
            {
                to = Console.ReadLine();
                if (!stringToUnit(to, ref uto))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID INPUT");
                    Console.Write("Please enter again: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                    break;
            }

            if (convert(ufrom, ov, uto, ref cv))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} {1} = {2} {3}\n", ov, from, cv, to);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Can Not Convert");
            }
        }

        /// <summary>
        /// main function prints menu's and calls doconversion to convert
        /// </summary>
        /// <param name="args">
        /// command line arguments not used
        /// </param>
        static void Main(string[] args)
        {
            Console.WriteLine("This program is a unit convertor");
            Console.WriteLine("Please choose which units you want to convert");            

            while (true)
            {
                Console.ResetColor();
                Console.Write("1. Length \n2. Volume \n3. Area \n4. quit\n");
                Console.Write("Please type what you want to convert and press enter: ");
                string input = Console.ReadLine();
                input = input.ToLower();
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (input == "length" || input == "1")
                {
                    Console.WriteLine("Units are feet, meter and miles");
                }
                else if (input == "volume" || input == "2")
                {
                    Console.WriteLine("Units are ounces, quarts and liters");
                }
                else if (input == "area" || input == "3")
                {
                    Console.WriteLine("Units are square feet, square miles and acres");
                }
                else if (input == "quit" || input == "4")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID INPUT, TRY AGAIN");
                    continue;
                }
                doConversion();
            }
        }

        /// <summary>
        /// converts value given from unit from to unit to. 
        /// </summary>
        /// <param name="value"></param>
        /// the value to be converted
        /// <param name="from"></param>
        /// the unit of the value provided the param value
        /// <param name="to"></param>
        /// the unit of the return value
        /// <returns>
        /// returns the converted value
        /// </returns>
        static bool convert(unit from, double input, unit to, ref double output)
        {
            // return value
            bool rv = true;

            // switch through all conversions
            switch (from)
            {
                case unit.FEET:
                    switch (to)
                    {
                        case unit.FEET:
                            output = input;
                            break;
                        case unit.METER:
                            output = input * 0.3048;
                            break;
                        case unit.MILES:
                            output = input / 5280;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
                case unit.METER:
                    switch (to)
                    {
                        case unit.FEET:
                            output = input * 3.28084;
                            break;
                        case unit.METER:
                            output = input;
                            break;
                        case unit.MILES:
                            output = input / 1609.34;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
                case unit.MILES:
                    switch (to)
                    {
                        case unit.FEET:
                            output = input * 5280;
                            break;
                        case unit.METER:
                            output = input * 1609.34;
                            break;
                        case unit.MILES:
                            output = input;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
                case unit.OUNCES:
                    switch (to)
                    {
                        case unit.OUNCES:
                            output = input;
                            break;
                        case unit.QUARTS:
                            output = input * 0.03125;
                            break;
                        case unit.LITERS:
                            output = input * 0.0295735;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
                case unit.QUARTS:
                    switch (to)
                    {
                        case unit.OUNCES:
                            output = input * 32;
                            break;
                        case unit.QUARTS:
                            output = input;
                            break;
                        case unit.LITERS:
                            output = input * 0.946353;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
                case unit.LITERS:
                    switch (to)
                    {
                        case unit.OUNCES:
                            output = input * 33.814;
                            break;
                        case unit.QUARTS:
                            output = input * 1.05669;
                            break;
                        case unit.LITERS:
                            output = input;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
                case unit.SQFEET:
                    switch (to)
                    {
                        case unit.SQFEET:
                            output = input;
                            break;
                        case unit.SQMILES:
                            output = input / 27878400;
                            break;
                        case unit.ACRES:
                            output = input / 43560;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
                case unit.SQMILES:
                    switch (to)
                    {
                        case unit.SQFEET:
                            output = input * 27878400;
                            break;
                        case unit.SQMILES:
                            output = input;
                            break;
                        case unit.ACRES:
                            output = input * 43560;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
                case unit.ACRES:
                    switch (to)
                    {
                        case unit.SQFEET:
                            output = input * 43560;
                            break;
                        case unit.SQMILES:
                            output = input / 640;
                            break;
                        case unit.ACRES:
                            output = input;
                            break;
                        default:
                            rv = false;
                            break;
                    }
                    break;
            }
            return rv;

        }
    }
}
