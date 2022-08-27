using System;

namespace Queue_ArrayImplementation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            QueueUsingArray q = new QueueUsingArray();
            int[] arr = { 1,2,3,4,5,6,7,8,9,10};
            foreach (int i in arr)
            {
                q.Enqueue(i);
            }
            while(!q.IsEmpty())
            {
                Console.WriteLine(q.Dequeue());
            }
        }
    }
}
