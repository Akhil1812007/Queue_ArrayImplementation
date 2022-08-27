using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_ArrayImplementation
{
    public  class QueueUsingArray
    {
        private int[] data;
        private int  front;
        private int rear;
        private int size;

        public QueueUsingArray()
        {
            data = new int[5];
            front = -1;
            rear = -1;
            size = 0;
        }
        public QueueUsingArray(int capacity)//     USER CAN FIX THE SIZE OF THE QUEUE 
        {
            data = new int[capacity];
        }
        public int Size()// FOR FINDING THE SIZE OF THE QUEUE
        {
            return size;
        }
        public bool IsEmpty()// FOR FINDING WHETHER THE QUEUE IS EMPTY OR NOT  
        {
            return size == 0;
        }
        public void Enqueue( int elem)// FOR ADDING ELEMENT INTO THE QUEUE
        {
            if(size == data.Length)
            {
                DoubleCapacity();
            }
            if(size == 0)
            {
                front = 0;
                
            }
            rear++;
            if (rear == data.Length)
            {
                rear = 0;    //  WE HAVE SPACE IN  ARRAY IN THE BEGINING  BUT THE REAR  END IS EQUAL TO THE ARRAY LENGTH
                             // SO INSERT IT INTO THE BEGINING OF THE ARRAY 
            }
            // FINE WAY OF WRITING LINE (45 TO 50)
            // rear=(rear+1)%data.Length
            data[rear] = elem;
            size++;


        }

        private void DoubleCapacity()
        {
            int[] temp = data;
            data = new int[2 * temp.Length];
            int index = 0;
            for (int i = front; i < temp.Length; i++) //        COPYING ALL ELEMENTS BASED ON THE FIFO MANNER
            {
                data[index++] = temp[i];
            }
            for (int i = 0; i < front; i++)
            {
                data[index++] = temp[i];
            }
            front = 0;
            rear=temp.Length-1;
        }

        public int Front()// FOR GETTING THE FIRST ELEMENT IN THE QUEUE
        {
            if(front == -1)
            {
                throw new QueueEmptyException();
            }
            return data[front];
        }
        public int Dequeue()
        {
            if (front == -1)
            {
                throw new QueueEmptyException();
            }
            int temp=data[front];
            front++;
            // REMOVED EVEN THE LAST ELEMENT OF THE ARRAY AFTER THIS REMOVAL COULD CAUSE ARRAY OUT OF BOUND EXCEPTION SO BRING THE FRONT BACK TO ZERO;
            if (front == data.Length)
            {
                front = 0;
            }
            // FINE WAY OF WRITING LINE (84 TO 89)

            // rear=(rear+1)%data.Length


            size--;
            if(size == 0)//WHEN THE FRONT  VALUE CROSSES THE REAR  VALUE SET FRONT AND REAR AS -1 OR SIZE==0
            {
                front = -1;
                rear = -1;
            }
            return temp;

        }
    }
}
