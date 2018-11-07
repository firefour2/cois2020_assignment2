using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace timalban_harrisonleitch_2020F18_A2
{
    class Program HuffmanCode
    {
      public static void Main()
      {
        int count =0;
        int[] freq = new int[27];
        string shirt = "aboot"; // Example string, eventually we need to allow the user to input Text

        charCount(freq, shirt);

        // Max array size we need is 53, 26 lower, 26 upper, 1 space.
        // Read in user input, call AnalyzeText

        for (int i = 0; i < 27; i++)
        {
            if (i >= 26)
                Console.WriteLine("Space has a frequency of {0}", freq[i]);
            else
                Console.WriteLine("{1} has a frequency of {0}", freq[i], (char)(i + 97)); //
        }
        Console.ReadLine();
      }

      class Node : IComparable
      {
        public char Character {get; set;}
        public int Frequency {get; set;}
        public Node Left {get; set;}
        public Node Right {get; set;}

        public Node (char character, int frequency, Node left, Node right)
        {
          //...
        }

        public int CompareTo (Object obj)
        {
          //...
        }
      }

      class Huffman
      {
        private Node HT; // Huffman tree to create codes and decode Text
        private Dictionary <char,string> D; // Dictionary to encode Text
        // From notes: Dictionary <T key, T value>, rememember that the C# dictionary is a hash table

        // Constructor
        public Huffman (string S)
        {
          // ...
          // NEEDS TO CALL: AnalyzeText, Build, and CreateCodes
        }

        // Return the frequency of each character in the given text (invoked by Huffman)
        private int[] AnalyzeText (string S)
        {
          //...
        }

        // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman)
        private void Build (int[] F)
        {
          PriorityQueue<Node> PQ;
          //...
        }

        //Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman)
        private void CreateCodes()
        {
          //...
        }

        //Encode the given text and return a string of 0s and 1s
        public string Encode (string S)
        {
          //...
        }

        // Decode the given string of 0s and 1s and return the original Text
        public string Decode (string S)
        {
          //...
        }

      }
}
