using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Reverse Text"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '5':
                        ReverseText();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             * 
             * Frågor:
             * 2 - När öokar listans kapacitet? => När Count == Capacity och vi lägger till ett nytt element.
             * 3 - Med hur mycket ökar listans kapacitet? => Den dubblas.
             * 4 - Varför ökar inte listans kapacitet på samma takt som element läggs till? => Jag tror listan tar en fixat antal på minnet och ställar en ny fixat antal när Capacity måste ökar.
             * 5 - Minskar kapacitet när vi elementen tas bort från listan? => Nej. Kapacitet minska inte även om vi tomtar listan.
             * 6 - När är det då fördelaktigt att använda en egendefinierad array istället för en lista? => 
             *   När vi vill kontrollera när Capacity ska öka eller minska, eller vi vet att listan kommer ändras i stolek på en stor sätt dynamiskt.
            */

            Console.WriteLine("Examining a list.\nThe list starts empty.\nType 'quit' to go back to the manu.\nYou can add or remove values to the list: '+Name' or '-Name'");
            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("\nPlease provide an input:");
                string? input = Console.ReadLine() ?? null;
                while (input == null || input.Length < 2)
                {
                    Console.WriteLine("Please provide an input that fulfills the form: '+Name' or '-Name'");
                    input = Console.ReadLine() ?? null;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"\nAdded {value} to the list.");
                        Console.WriteLine($"List count: {theList.Count}, List capacity: {theList.Capacity}");
                        break;
                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.WriteLine($"\nRemoved {value} from the list.");
                        }
                        else
                        {
                            Console.WriteLine($"\n{value} not found in the list.");
                        }
                        Console.WriteLine($"List count: {theList.Count}, List capacity: {theList.Capacity}");
                        break;
                    case 'q' or 'Q':
                        if (input.ToLower() == "quit")
                        {
                            Console.WriteLine("Exiting to main menu.");
                            return;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please provide an input that fulfills the form: '+Name' or '-Name'");
                            input = Console.ReadLine() ?? null;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Console.WriteLine("Examining a queue.\nThe queue starts empty.\nType 'quit' to go back to the manu.\nWe always revome  the first element.\nYou can add or remove people to the queue: '+Name' or '-'");
            Queue<string> theQueue = new();

            while (true)
            {
                Console.WriteLine("\nPlease provide an input:");
                string? input = Console.ReadLine() ?? null;
                while (input == null || input.Length < 1)
                {
                    Console.WriteLine("Please provide an input that fulfills the form: '+Name' or '-'");
                    input = Console.ReadLine() ?? null;
                }

                char nav = input[0];
                string value = input.Substring(1) ?? "";

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value); // adds to the end
                        Console.WriteLine($"\nAdded {value} to the list.");
                        Console.WriteLine($"Queue count: {theQueue.ToList().Count}");
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                        {
                            value = theQueue.Dequeue(); // removes from the top
                            Console.WriteLine($"\nRemoved {value} from the list.");
                        }
                        else
                        {
                            Console.WriteLine($"\nThe queue is empty.");
                        }
                        Console.WriteLine($"Queue count: {theQueue.Count}.");
                        break;
                    case 'q' or 'Q':
                        if (input.ToLower() == "quit")
                        {
                            Console.WriteLine("Exiting to main menu.");
                            return;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please provide an input that fulfills the form: '+Name' or '-'");
                            input = Console.ReadLine() ?? null;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
             * 
             * Frågor:
             * 1 - Vaför är det inte smart att använda en stack i det här fallet? => första kund som stör i köan skulle bli arg, och kanske kommer aldrig blir expedierad.
            */

            Console.WriteLine("Examining a queue.\nThe queue starts empty.\nType 'quit' to go back to the manu.\nWe always revome  the first element.\nYou can add or remove people to the queue: '+Name' or '-'");
            Stack<string> theStack = new();

            while (true)
            {
                Console.WriteLine("\nPlease provide an input:");
                string? input = Console.ReadLine() ?? null;
                while (input == null || input.Length < 1)
                {
                    Console.WriteLine("Please provide an input that fulfills the form: '+Name' or '-'");
                    input = Console.ReadLine() ?? null;
                }

                char nav = input[0];
                string value = input.Substring(1) ?? "";

                switch (nav)
                {
                    case '+':
                        theStack.Push(value); // adds to the top
                        Console.WriteLine($"\nAdded {value} to the list.");
                        Console.WriteLine($"Queue count: {theStack.ToList().Count}");
                        break;
                    case '-':
                        if (theStack.Count > 0)
                        {
                            value = theStack.Pop(); // removes from the top
                            Console.WriteLine($"\nRemoved {value} from the list.");
                        }
                        else
                        {
                            Console.WriteLine($"\nThe queue is empty.");
                        }
                        Console.WriteLine($"Queue count: {theStack.Count}.");
                        break;
                    case 'q' or 'Q':
                        if (input.Equals("quit")) // case insensitive check
                        {
                            Console.WriteLine("Exiting to main menu.");
                            return;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please provide an input that fulfills the form: '+Name' or '-'");
                            input = Console.ReadLine() ?? null;
                            break;
                        }
                }
            }
        }

        static void ReverseText()
        {
            /*
             * Use this method to reverse a string using a stack.
             * Example: "Hello World" => "dlroW olleH"
             */
            Console.WriteLine("Reverse a text.\nType 'quit' to go back to the manu.");

            while (true)
            {
                Console.WriteLine("\nPlease provide the text:");
                string input = Console.ReadLine() ?? "";
                while (input.Length < 1)
                {
                    Console.WriteLine("Please provide text with more than 1 character");
                    input = Console.ReadLine() ?? "";
                }

                if (input.Equals("quit"))
                {
                    Console.WriteLine("Exiting to main menu.");
                    return;
                }

                string result = "";
                Stack<char> charStack = new Stack<char>();
                foreach (char c in input)
                {
                    charStack.Push(c);
                }
                while (charStack.Count > 0)
                {
                    result += charStack.Pop();
                }
                Console.WriteLine($"Result: {result}");
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             * 
             * Frågor:
             * Vilken datastruktur användar du?
             * Svar: Stack - FILO lista :) för att det är perfekt för att hantera ordret av symboler.
             */

            Console.WriteLine("Check if a string is Well formed.\nType 'quit' to go back to the manu.");

            while (true)
            {
                Console.WriteLine("\nPlease provide the string:");
                string input = Console.ReadLine() ?? "";
                while (input.Length < 1)
                {
                    Console.WriteLine("Please provide a string with more than 1 character");
                    input = Console.ReadLine() ?? "";
                }

                if (input.Equals("quit"))
                {
                    Console.WriteLine("Exiting to main menu.");
                    return;
                }

               Stack<char> charStack = new Stack<char>();
                foreach (char c in input)
                {
                    if (c == '(' || c == '{' || c == '[' || c == '<')
                    {
                        charStack.Push(c);
                    }
                    else if (c == ')' || c == '}' || c == ']' || c == '>')
                    {
                        char popped = charStack.Pop();
                        if ((c == ')' && popped != '(') ||
                            (c == '}' && popped != '{') ||
                            (c == ']' && popped != '[') ||
                            (c == '>' && popped != '<'))
                        {
                            Console.WriteLine($"The string is NOT Well formed.");
                            charStack.Push(popped); // Push it back to avoid empty stack on malformed
                            break;
                        }
                    }
                }

                if (charStack.Count == 0)
                {
                    Console.WriteLine($"The string IS Well formed.");
                }
            }
        }

    }
}

