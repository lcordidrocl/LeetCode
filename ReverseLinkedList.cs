namespace LeetCode.ReverseLinkedList
{
    public class ListNode
    {
        public int value;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.value = val;
            this.next = next;
        }
    }
    public static class ReverseLinkedListLogic
    {
        public static ListNode Reverse(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode prev = null;
            ListNode next = null;

            while (head != null)
            {
                next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }

            return prev;
        }
    }
}
