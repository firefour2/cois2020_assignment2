using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;





    
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
        public int CompareTo(Node n)
        //public int CompareTo(Object obj)
        {
            //Node other = (Node)obj;
            //return Frequency - other.Frequency;
            return Frequency.CompareTo(n.Frequency);
        }
    }
    class Huffman
    {
        private Node HT;   // Huffman tree to create codes and decode text 
        private Dictionary<char, string> D; // Dictionary to encode text



             public static void Main()
        {
            string test;

            Console.Write("Enter the last name of the employee => ");
            test = Console.ReadLine();

        }

        

        // Constructor 
        public Huffman(string S)
        {

            
        }

        // 15 marks // Return the frequency of each character in the given text (invoked by Huffman) 
        private int[] AnalyzeText(string S)
        {
            int[] alpha = new int[53];
            foreach (char c in S.ToLower())
            {

                if (((int)c <= 122) && ((int)c >= 97))

                    alpha[(int)c - 97]++;

                else if ((int)c == 32)
                    alpha[27]++;

            }
            return alpha;
        }

        // 20 marks  // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman) 
        private void Build(int[] F)
        {
               


            char[] a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();
           

            PriorityQueue<Node> PQ = new PriorityQueue<Node>(53);

            for (int i = 0; i < a.Length; i++)
            {
                PQ.Add(new Node(a[i], F[i], null, null));

            }

           


        }

        // 20 marks 
        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman) 
        private void CreateCodes()
        {

        }

        // 10 marks  // Encode the given text and return a string of 0s and 1s 
        public string Encode(string S)
        {
        }
        // 10 marks
        // Decode the given string of 0s and 1s and return the original text 
        public string Decode(string S)
        {
        }
    }

