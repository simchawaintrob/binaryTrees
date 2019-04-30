using System;



namespace binaryTreeProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BTree();
            tree.FillDemo();
            tree.Root.Print();
            Console.WriteLine();
            bool flag = true;
            while (flag)
            {


                Console.WriteLine();
                Console.WriteLine("a - add a node to tree (int number)");
                Console.WriteLine("d - delelte node from tree  (int number)");
                Console.WriteLine("p - prtin the tree");
                Console.WriteLine("e - to exit");
                Console.WriteLine();

                int input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (input)
                {
                    case 'a':
                        Console.WriteLine("pass a number to add in tree..");
                        var key = Console.ReadLine();
                        tree.Fill(Convert.ToInt32(key));

                        tree.Root.Print();
                        break;
                    case 'd':
                        Console.WriteLine("pass a number to delelte from tree..");
                        var key1 = Console.ReadLine();
                        tree.DeleteData(Convert.ToInt32(key1));

                        tree.Root.Print();
                        break;
                    case 'p':
                        tree.Root.Print();
                        break;
                    case 'e':
                        flag = false;
                        break;
                    default:
                        break;
                }

            }
        }

        
    }
}

