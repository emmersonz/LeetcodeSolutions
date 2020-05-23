using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeSolutions
{
    public static class Utils
    {
        public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            int currPosition = 0;
            for (SinglyLinkedListNode ll = head; ll != null; ll = ll.next)
            {
                if (currPosition == position && position == 0)
                {
                    return new SinglyLinkedListNode(data) { next = ll };
                }
                else if (position == currPosition + 1)
                {
                    ll.next = new SinglyLinkedListNode(data) { next = ll.next };
                    break;
                }

                currPosition++;
            }
            return head;
        }

        public static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
        {
            var ll = head;
            int currentPos = 0;
            while (ll != null)
            {
                if (currentPos == position && currentPos == 0)
                {
                    return head.next;
                }
                if (position == currentPos + 1)
                {
                    ll.next = ll.next.next;
                    break;
                }
                currentPos++;
                ll = ll.next;
            }
            return head;
        }

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            int pivot = arr[(left + right) / 2];
            int index = Partition(arr, left, right, pivot);
            QuickSort(arr, left, index - 1);
            QuickSort(arr, index, right);
        }

        public static int Partition(int[] array, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }
                while (array[right] > pivot)
                {
                    right--;
                }
                if (left <= right)
                {
                    Swap(array, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        public static void Swap(int[] arr, int left, int right)
        {
            var atLeft = arr[left];
            arr[left] = arr[right];
            arr[right] = atLeft;
        }

        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            if (s.Length == 1)
                return s;
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var len1 = expandFromCenter(s, i, i);
                var len2 = expandFromCenter(s, i, i + 1);
                var len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }

            }
            return s.Substring(start, end - start + 1);
        }

        public static int expandFromCenter(string s, int left, int right)
        {
            var L = left;
            var R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }
            return R - L - 1;
        }

        public static int MaxAncestorDiff(TreeNode root)
        {
            return FindMax(root, new List<int>());

        }

        public static int FindMax(TreeNode node, List<int> ancestors)
        {
            if (node == null)
                return ancestors.Max() - ancestors.Min();
            ancestors.Add(node.val);
            var leftList = ancestors.Select(item => item).ToList();
            var rightList = ancestors.Select(item => item).ToList();

            int leftMaxDiff = FindMax(node.left, leftList);
            int rightMaxDiff = FindMax(node.right, rightList);
            return Math.Max(leftMaxDiff, rightMaxDiff);
        }

        static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode prev = null;
            var current = head;
            SinglyLinkedListNode nextNode = null;
            while (current != null)
            {
                nextNode = current.next;
                current.next = prev;
                prev = current;
                current = nextNode;
            }
            return prev;
        }

        static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            while (head1 != null || head2 != null)
            {
                if (head1 == null && head2 != null)
                    return false;
                if (head1 != null && head2 == null)
                    return false;
                if (head1.data != head2.data)
                    return false;
                head1 = head1.next;
                head2 = head2.next;
            }
            return true;
        }

        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            if (head1 == null)
                return head2;
            if (head2 == null)
                return head1;
            SinglyLinkedListNode result = null;
            SinglyLinkedListNode mlt = null;
            SinglyLinkedListNode olt = null;
            if (head1.data <= head2.data)
            {
                result = head1;
                mlt = head1;
                olt = head2;
            }
            else
            {
                result = head2;
                mlt = head2;
                olt = head1;

            }

            while (olt != null)
            {
                if (mlt.next == null || mlt.next.data > olt.data)
                {
                    var temp1 = mlt.next;
                    var temp2 = olt.next;
                    mlt.next = olt;
                    olt.next = temp1;
                    olt = temp2;
                }
                else
                {
                    mlt = mlt.next;
                }
            }
            return result;


        }

        static bool hasCycle(SinglyLinkedListNode head)
        {
            if (head == null)
                return false;
            if (head.next == null)
                return false;
            List<SinglyLinkedListNode> lst = new List<SinglyLinkedListNode>();
            while (head != null)
            {
                if (lst.Contains(head))
                {
                    return true;
                }
                lst.Add(head);
                head = head.next;
            }
            return false;
        }

    }

    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int _data)
        {
            data = _data;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}   
