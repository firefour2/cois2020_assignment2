using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class Node : IComparable
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        //

        public Node(char character, int frequency, Node left, Node right)
        {
            this.Character = character;
            this.Frequency = frequency;
            this.Left = left;
            this.Right = right;
        }
        // 5 marks 
        //public int CompareTo(Node n)
        public int CompareTo(Object obj)
        {
            Node other = (Node)obj;
            return Frequency - other.Frequency;
            //return Frequency.CompareTo(n.Frequency);
        }
    }
    class Huffman
    {
        private Node HT;   // Huffman tree to create codes and decode text 
        private Dictionary<char, string> D = new Dictionary<char, string>(); // Dictionary to encode text
        string c = "";

        public static void Main()
        {
            string test;

            Console.Write("Enter the last name of the employee => ");
            test = Console.ReadLine();

        }
        // Constructor 
        public Huffman(string S)
        {
            Build(AnalyzeText(S));
            CreateCodes(HT, c);
        }

        // 15 marks // Return the frequency of each character in the given text (invoked by Huffman) 
        private int[] AnalyzeText(string S)
        {
            int[] alpha = new int[53];
            foreach (char c in S.ToLower())
            {

                if (((int)c <= 122) && ((int)c >= 97))
                    alpha[(int)c - 97]++;

                else if (((int)c <= 90) && ((int)c >= 65))
                    alpha[(int)c - 65]++;

                else if ((int)c == 32)
                    alpha[27]++;

            }
            return alpha;
        }

        // 20 marks  // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman) 
        private void Build(int[] F)
        {
            Node left;
            Node right;


            char[] a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();


            PriorityQueue<Node> PQ = new PriorityQueue<Node>(53);

            for (int i = 0; i < a.Length; i++) //check for an issue
            {
                PQ.Add(new Node(a[i], F[i], null, null));
            }

            if (PQ.Size() == 1)

                HT = PQ.Front();

            else
            {
                while (PQ.Size() > 1)
                {
                    left = PQ.Front();
                    PQ.Remove();
                    right = PQ.Front();
                    PQ.Remove();
                    PQ.Add(new Node('2', left.Frequency + right.Frequency, left, right));
                    HT = PQ.Front();
                }
            }

        }

        // 20 marks 
        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman) 
        private void CreateCodes(Node HT, string code)
        {
            codes(HT, code);

        }
        private void codes(Node cN, string code)
        {
            while (cN.Left != null)
            {
                codes(cN.Left, code += "0");
                codes(cN.Right, code += "1");

            }
            if (cN.Left == null)
                D.Add(cN.Character, code);
        }
        //-------------------------------------------------------------------
        //while (HC1.Left != null && HC1.Right != null)
        //{
        //HC2 = HC1.Left;
        //codes += "0";

        //if (HC2.Character != '2')
        //{
        //    D.Add(HC2.Character, codes);
        //    HC2 = HC1.Right;


        //}
        //codes = "";
        //-------------------------------------------------------------------                

        // 10 marks  // Encode the given text and return a string of 0s and 1s 
        public string Encode(string S)
        {
            String encodedMessage = "";


            foreach (char c in S)
            {
                encodedMessage += D[c];
            }

            return encodedMessage;
        }
        // 10 marks
        // Decode the given string of 0s and 1s and return the original text 
        public string Decode(string S)
        {
            Node current = HT;
            string decodedMessage = "";

            foreach (char c in S)
            {
                while (current.Left != null)
                {
                    if ((int)c == 0)
                        current = current.Left;
                    else if ((int)c == 1)
                        current = current.Right;
                }
                if (current.Left == null)
                {
                    decodedMessage += current.Character;
                }
            }
            return decodedMessage;
        }

        public interface IContainer<T>
        {
            void MakeEmpty();  // Reset an instance to empty
            bool Empty();      // Test if an instance is empty
            int Size();        // Return the number of items in an instance
        }

        //-----------------------------------------------------------------------------

        public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
        {
            void Add(T item);  // Add an item to a priority queue
            void Remove();     // Remove the item with the highest priority
            T Front();         // Return the item with the highest priority
        }

        //-------------------------------------------------------------------------

        // Priority Queue
        // Implementation:  Binary heap

        public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
        {
            private int capacity;  // Maximum number of items in a priority queue
            private T[] A;         // Array of items
            private int count;     // Number of items in a priority queue

            public PriorityQueue(int size)
            {
                capacity = size;
                A = new T[size + 1];  // Indexing begins at 1
                count = 0;
            }

            // Percolate up from position i in a priority queue

            private void PercolateUp(int i)
            // (Worst case) time complexity: O(log n)
            {
                int child = i, parent;

                while (child > 1)
                {
                    parent = child / 2;
                    if (A[child].CompareTo(A[parent]) > 0)
                    // If child has a higher priority than parent
                    {
                        // Swap parent and child
                        T item = A[child];
                        A[child] = A[parent];
                        A[parent] = item;
                        child = parent;  // Move up child index to parent index
                    }
                    else
                        // Item is in its proper position
                        return;
                }
            }

            public void Add(T item)
            // Time complexity: O(log n)
            {
                if (count < capacity)
                {
                    A[++count] = item;  // Place item at the next available position
                    PercolateUp(count);
                }
            }

            // Percolate down from position i in a priority queue

            private void PercolateDown(int i)
            // Time complexity: O(log n)
            {
                int parent = i, child;

                while (2 * parent <= count)
                // while parent has at least one child
                {
                    // Select the child with the highest priority
                    child = 2 * parent;    // Left child index
                    if (child < count)  // Right child also exists
                        if (A[child + 1].CompareTo(A[child]) > 0)
                            // Right child has a higher priority than left child
                            child++;

                    if (A[child].CompareTo(A[parent]) > 0)
                    // If child has a higher priority than parent
                    {
                        // Swap parent and child
                        T item = A[child];
                        A[child] = A[parent];
                        A[parent] = item;
                        parent = child;  // Move down parent index to child index
                    }
                    else
                        // Item is in its proper place
                        return;
                }
            }

            public void Remove()
            // Time complexity: O(log n)
            {
                if (!Empty())
                {
                    // Remove item with highest priority (root) and
                    // replace it with the last item
                    A[1] = A[count--];

                    // Percolate down the new root item
                    PercolateDown(1);
                }
            }

            public T Front()
            // Time complexity: O(1)
            {
                if (!Empty())
                {
                    return A[1];  // Return the root item (highest priority)
                }
                else
                    return default(T);
            }

            // Create a binary heap
            // Percolate down from the last parent to the root (first parent)

            private void BuildHeap()
            // Time complexity: O(n)
            {
                int i;
                for (i = count / 2; i >= 1; i--)
                {
                    PercolateDown(i);
                }
            }

            // Sorts and returns the InputArray

            public void HeapSort(T[] inputArray)
            // Time complexity: O(n log n)
            {
                int i;

                capacity = count = inputArray.Length;

                // Copy input array to A (indexed from 1)
                for (i = capacity - 1; i >= 0; i--)
                {
                    A[i + 1] = inputArray[i];
                }

                // Create a binary heap
                BuildHeap();

                // Remove the next item and place it into the input (output) array
                for (i = 0; i < capacity; i++)
                {
                    inputArray[i] = Front();
                    Remove();
                }
            }

            public void MakeEmpty()
            // Time complexity: O(1)
            {
                count = 0;
            }

            public bool Empty()
            // Time complexity: O(1)
            {
                return count == 0;
            }

            public int Size()
            // Time complexity: O(1)
            {
                return count;
            }
        }

        //-------------------------------------------------------------------------

        // Used by class PriorityQueue<T>
        // Implements IComparable and overrides ToString (from Object)

        public class PriorityClass : IComparable
        {
            private int priorityValue;
            private String name;

            public PriorityClass(int priority, String name)
            {
                this.name = name;
                priorityValue = priority;
            }

            public int CompareTo(Object obj)
            {
                PriorityClass other = (PriorityClass)obj;   // Explicit cast
                return priorityValue - other.priorityValue;
            }

            public override string ToString()
            {
                return name + " with priority " + priorityValue;
            }
        }

        static void Main(string[] args)
        {
            // Information about our program
            Console.WriteLine("COIS 2020, Assignment 2: Huffman Trees");
            Console.WriteLine("By: Timothy Alban () & Harrison Leitch (0624686)");
            Console.WriteLine("");

            // Step #1: Prompt the user to input a word or text
            Console.Write("**This program supports all main ASCII characters (up to 122)**\nPlease enter a word or text: ");
            string userInput = Convert.ToString(Console.ReadLine()); // Convert user input to a string (userInput)

            // Step #2: Build the Huffman Tree
            Huffman constructTree = new Huffman(userInput);

            // Step #3: Encode the given text and return a string of 0s and 1s
            Console.Write("Encoded text: ");
            Console.WriteLine(constructTree.Encode(userInput));

            // Step #4: Decode the given string of 0s and 1s and return the original text by traversing the tree
            Console.Write("Decoded text: ");
            Console.WriteLine(constructTree.Decode(constructTree.Encode(userInput)));

            Console.ReadLine();
        }
    }
}
