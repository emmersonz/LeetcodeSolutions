using System;
using System.Collections.Generic;

namespace LeetcodeSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "absddlghfefd";
            Console.WriteLine($"Length of longest substring: {LengthOfLongestSubstring(a)}");
            var ll = new SinglyLinkedListNode(1) { next = new SinglyLinkedListNode(2) { next = new SinglyLinkedListNode(7) } };
            //var res = deleteNode(ll, 2);
            //SinglyLinkedListNode linkedList = ll;
            //while (res != null)
            //{
            //    Console.WriteLine(linkedList.data);
            //    linkedList = linkedList.next;
            //}
            var A = new int[][] { new int[] { 0, 2 }};
            var B = new int[][] { new int[] { 1, 5 }, new int[] { 8, 12 }, new int[] { 15, 24 }, new int[] { 25, 26 } };
            var result = Solution.IntervalIntersection(A, B);
            foreach (var arr in result)
            {
                Console.WriteLine($"[{arr[0]}, {arr[1]}]");
            }

            Console.ReadKey();
        }
        public static int LengthOfLongestSubstring(string s)
        {
            var seen = new List<char>();
            int longestSoFar = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int subStringLength = 0;
                for (int j = i; j < s.Length; j++)
                {
                    if (!seen.Contains(s[j]))
                    {
                        subStringLength++;
                        seen.Add(s[j]);
                        if (longestSoFar < subStringLength)
                        {
                            longestSoFar = subStringLength;
                        }
                    }
                    else
                    {
                        if (longestSoFar < subStringLength)
                        {
                            longestSoFar = subStringLength;
                        }
                        seen = new List<char>();
                        break;
                    }
                }
            }
            return longestSoFar;
        }
    }
}
