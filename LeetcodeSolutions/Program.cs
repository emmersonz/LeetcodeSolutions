﻿using System;
using System.Collections.Generic;

namespace LeetcodeSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "absddlghfefd";
            Console.WriteLine($"Length of longest substring: {LengthOfLongestSubstring(a)}");
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