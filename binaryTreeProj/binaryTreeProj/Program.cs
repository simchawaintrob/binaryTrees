using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaryTreeProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BTree();
            while (true)
            {

            var GlobalKey = Console.ReadLine();

                if (GlobalKey == "a")
                {
                    Console.WriteLine("pass a number to add in tree..");
                    var key = Console.ReadLine();

                    tree.fill(Convert.ToInt32(key));
                    tree.Root.Print();

                }
                if (GlobalKey == "d")
                {
                    Console.WriteLine("pass a number to delelte from tree..");

                    var key = Console.ReadLine();

                    tree.DeleteData(Convert.ToInt32(key));
                    tree.Root.Print();

                }
                if (GlobalKey == "p")
                {
                    tree.Root.Print();
                }



                }
            Console.WriteLine();
            Console.ReadKey();
        }

        
    }
}

