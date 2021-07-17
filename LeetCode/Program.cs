using LeetCode.ReverseLinkedList;

namespace LeetCode
{
    class Program
    {        
        static void Main(string[] args)
        {
            var head = new ListNode(1, null);
            var next = new ListNode(2, null);
            var last = new ListNode(3, null);

            head.next = next;
            next.next = last;

            var result = ReverseLinkedListLogic.Reverse(head);
            var a = result.next;
        }
    }
}
