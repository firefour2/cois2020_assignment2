using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

                else if (((int)c <= 90) && ((int)c >= 65))
                    alpha[(int)c - 65]++;

                else if ((int)c == 32)
                    alpha[27]++;

            }
            return alpha;
        }

        // 20 marks  // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman) 
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
                while(PQ.Size() > 1)
                {
                    left = PQ.Front();
                    PQ.Remove();
                    right = PQ.Front();
                    PQ.Remove();
                    PQ.Add(new Node('2',left.Frequency + right.Frequency, left, right));
                    HT = PQ.Front();
                }
            }

        }

        // 20 marks 
        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman) 
        private void CreateCodes()
        {
            String c = "";
            codes(HT,c);   
   
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
 
        // 10 marks  // Encode the given text and return a string of 0s and 1s 
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
                while(current.Left != null)
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
    }
}
