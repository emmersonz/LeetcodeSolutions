using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions
{
    public class Solution {
        public static int[][] IntervalIntersection(int[][] A, int[][] B)
        {
         var result = new List<int[]>();
        if(A.Length < 1 || B.Length < 1 || A[0].Length < 1 || B[0].Length < 1)
            return result.ToArray();
         
        int aIndexer = 1;
        int bIndexer = 1;
        int[] currAInt = A[0];
        int[] currBInt = B[0];
         
        do{
            int[] remainder = IntersectionRemainder(result, currAInt, currBInt);
            // a interval bigger
            if(remainder[0] == 0){
               currBInt= B[bIndexer++];    
            }
            // b interval bigger
            else if(remainder[0] == 1){
               currAInt = A[aIndexer++];    
            }
            else if(remainder[0] == 2){
                currAInt = new int[]{remainder[1], remainder[2]};
                if(bIndexer < B.Length)
                    currBInt = B[bIndexer];
                bIndexer++;
            }
            else if(remainder[0] == 3){
                currBInt = new int[]{remainder[1], remainder[2]};
                if(aIndexer < A.Length)
                    currAInt = A[aIndexer];
                aIndexer++;
            }
            
        }while(aIndexer < A.Length || bIndexer < B.Length);
        return result.ToArray();
                    
     }
    
    public static int[] IntersectionRemainder(List<int[]> lst, int[] A, int[] B){
        // A interval bigger
        if(A[0] > B[1])
            return new int[]{0};
        // B interval bigger
        else if(B[0] > A[1])
            return new int[]{1};   
        // intersection but A has remainder
        else if(A[1] > B[1]){
            lst.Add(new int [] {Math.Max(A[0], B[0]), Math.Min(A[1], B[1])});
            return new int[]{ 2, B[1], A[1]};
        }
        // intersection but B has remainder
        else{
            lst.Add(new int [] {Math.Max(A[0], B[0]), Math.Min(A[1], B[1])});
            return new int[]{ 3, A[1], B[1]};
        }

    }
       
}
}
