using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, will handle the menus for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 7, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Reverse Text"
                    + "\n6. Recursive Even"
                    + "\n7. Recursive Fibonnacci sequence"
                    + "\n8. Iterative Even"
                    + "\n9. Iterative Fibonnacci sequence"
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
                    case '6':
                        UseRecursiveEven();
                        break;
                    case '7':
                        FibonacciSequence();
                        break;
                    case '8':
                        IterativeEven();
                        break;
                    case '9':
                        IterativeFibonacci();
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
                            Console.WriteLine($"\nRemoved {value} from the list.\n");
                        }
                        else
                        {
                            Console.WriteLine($"\n{value} not found in the list.\n");
                        }
                        Console.WriteLine($"List count: {theList.Count}, List capacity: {theList.Capacity}\n");
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
                            Console.WriteLine($"\nRemoved {value} from the list.\n");
                        }
                        else
                        {
                            Console.WriteLine($"\nThe queue is empty.\n");
                        }
                        Console.WriteLine($"Queue count: {theQueue.Count}.\n");
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
                        Console.WriteLine($"Stack count: {theStack.ToList().Count}");
                        break;
                    case '-':
                        if (theStack.Count > 0)
                        {
                            value = theStack.Pop(); // removes from the top
                            Console.WriteLine($"\nRemoved {value} from the list.\n");
                        }
                        else
                        {
                            Console.WriteLine($"\nThe stack is empty.\n");
                        }
                        Console.WriteLine($"Stack count: {theStack.Count}.\n");
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
                Console.WriteLine($"Result: {result}\n");
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             * 
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
                            charStack.Push(popped); // Push it back to avoid empty stack
                        }
                    }
                }

                if (charStack.Count == 0)
                {
                    Console.WriteLine($"The string IS Well formed.\n");
                } else
                {
                    Console.WriteLine($"The string is NOT Well formed.\n");
                }
            }
        }

        static void UseRecursiveEven()
        {
            /*
             * Use this method to find the nth even number, using recursion.
             * Example: 4 => true, 7 => false
             */

            Console.WriteLine("Check if a number is even, recursively.\nType 'quit' to go back to the manu.");

            while (true)
            {
                Console.WriteLine("\nPlease provide the number:");
                string input = Console.ReadLine() ?? "";

                if (input.Equals("quit"))
                {
                    Console.WriteLine("Exiting to main menu.");
                    return;
                }

                int number;
                while (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Please provide a valid integer number:");
                }

                Console.WriteLine($"The {input}th even number: {RecursiveEven(number)}\n");
            }
        }

        private static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 2;
            }
            return RecursiveEven(n - 1) + 2;

        }

        static void FibonacciSequence()
        {
            /*
             * Use this method to print the Fibonacci sequence up to the nth number, using recursion.
             * Example: 5 => 0, 1, 1, 2, 3
             */
            Console.WriteLine("Print the Fibonacci sequence up to the nth number, recursively.\nType 'quit' to go back to the manu.");
            while (true)
            {
                Console.WriteLine("\nPlease provide the number:");
                string input = Console.ReadLine() ?? "";

                if (input.Equals("quit"))
                {
                    Console.WriteLine("Exiting to main menu.");
                    return;
                }

                int n;
                while (!int.TryParse(input, out n))
                {
                    Console.WriteLine("Please provide a valid integer number:");
                }


                Console.WriteLine($"Fibonacci sequence up to {n}th number: ");

                for (int i = 1; i <= n; i++)
                {
                    Console.Write(Finbonnacci(i) + (i < n ? ", " : "\n\n"));
                }
            }
        }

        private static int Finbonnacci(int n)
        {

            if (n <= 1) return n;

            return Finbonnacci(n - 1) + Finbonnacci(n - 2);
        }

        private static void IterativeEven()
        {
            /*
             * Use this method to find the nth even number, using iteration.
             * Example: 4 => true, 7 => false
             */
            Console.WriteLine("Check if a number is even, iteratively.\nType 'quit' to go back to the manu.");
            while (true)
            {
                Console.WriteLine("\nPlease provide the number:");
                string input = Console.ReadLine() ?? "";

                if (input.Equals("quit"))
                {
                    Console.WriteLine("Exiting to main menu.");
                    return;
                }

                int number;
                while (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Please provide a valid number:");
                }

                int result = 2;
                for (int i = 1; i < number; i++)
                {
                    result += 2;
                }

                Console.WriteLine($"The {input}th even number: {result}\n");
            }
        }

        private static void IterativeFibonacci()
        {
            /*
             * Use this method to print the Fibonacci sequence up to the nth number, using iteration.
             * Example: 5 => 0, 1, 1, 2, 3
             */
            Console.WriteLine("Print the Fibonacci sequence up to the nth number, iteratively.\nType 'quit' to go back to the manu.");
            while (true)
            {
                Console.WriteLine("\nPlease provide the number:");
                string input = Console.ReadLine() ?? "";
               
                if (input.Equals("quit"))
                {
                    Console.WriteLine("Exiting to main menu.");
                    return;
                }
                
                int number;
                while (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Please provide a valid integer number:");
                }
                
                Console.Write($"Fibonacci sequence up to {number}th number: ");
                //int[] resultList = [0, 1];
                int a = 0;
                int b = 1;
                int c = 0;
                for (int i = 1; i <= number; i++)
                {
                    int result = 0;
                    //if (i <= 1)
                    //{
                    //    result = i;
                    //    Console.Write(result + (i < number ? ", " : " "));
                    //}
                    //else
                    //{
                    //    result = (resultList[i - 1]) + (resultList[i - 2]);
                    //    resultList = resultList.Append(result).ToArray();
                    //    Console.Write(result + (i < number ? ", " : " "));
                    //}
                    if (number <= 1) result = number;

                    c = a + b;
                    a = b;
                    b = c;

                    result = c;
                    Console.Write(result + (i < number ? ", " : " "));
                }
            }
        }
    }
}

