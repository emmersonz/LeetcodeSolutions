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

        public string LongestPalindrome(string s)
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
}   
