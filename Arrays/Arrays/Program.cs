using System;
using System.Collections.Generic;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            #region linkedlist
            //LinkedList ls = new LinkedList();
            //ls.AddLast(7);
            //ls.AddLast(9);
            //ls.AddLast(8);
            //ls.AddLast(11);
            //ls.AddLast(13);
            //ls.Reverse();
            //Console.WriteLine(ls.Size());
            #endregion linkedlist

            #region stack

            //string inputString = "[[78j+98+)" ;
            //string inputString = "[[78j+98+]]";
            //string inputString = "(1+2]";

            //Console.WriteLine(CheckIfStringIsInFormat(inputString));

            #endregion stack

            #region Queue Using an array
            //ArrayQueue arr = new ArrayQueue(5);
            //arr.Enqueue(20);
            //arr.Enqueue(21);
            //arr.Enqueue(22);
            //arr.Enqueue(23);
            //arr.Enqueue(24);

            //int val1 = arr.Dequeue();
            ////int val2 = arr.Dequeue();
            //arr.Enqueue(20);
            //arr.Enqueue(20);
            //arr.Enqueue(20);
            //arr.Enqueue(90);
            //arr.Dequeue();

            //var trfl = arr.isEmpty();
            //var frtl = arr.isFull();

            #endregion Queue Using an array

            #region Building queue using two stacks

            //StackQueue stackQueue = new StackQueue();

            //stackQueue.Enqueue(20);
            //stackQueue.Enqueue(21);
            //stackQueue.Enqueue(22);
            //stackQueue.Enqueue(23);
            //stackQueue.Enqueue(24);

            //stackQueue.Dequeue();
            //stackQueue.Dequeue();
            //stackQueue.Enqueue(26);
            #endregion Building queue using two stacks
            CustomeHashTable tbl = new CustomeHashTable(5);
            tbl.Put(6, "A");
            tbl.Put(8, "B");
            tbl.Put(11, "C");
            tbl.Put(6, "A+");
            tbl.Remove(6);
            Console.WriteLine(tbl.Get(10));
            Console.ReadLine();


        }

         
    }


    #region linedlist
    public class LinkedList
    {
        private Node first;
        private Node last;

        private class Node
        {

            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public void AddLast(int value) {

            var newNode = new Node(value);

            if (IsEmpty())
                first = last = newNode;

            else {

                last.next = newNode;
                last = newNode;
            }

        }

        public void AddFirst(int value) {
            Node newNode = new Node(value);
            if (IsEmpty())
                first = last = newNode;

            else {
                newNode.next = first;
                first = newNode;

            }


        }

        public bool Contains(int value)
        {
            if (IsEmpty())
                return false;
            else
            {
                Node current = first;
                while (current != null)
                {
                    if (current.value == value)
                        return true;
                    current = current.next;

                }

                return false;


            }

        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                return;
            else
            {
                if (first == last)
                {
                    first = last = null;
                    return;
                }
                var secondNode = first.next;
                first.next = null;
                first = secondNode;

            }
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                return;
            else
            {
                if (first == last)
                {
                    first = last = null;
                    return;
                }
                Node currentNode = first;
                while (currentNode != null)
                {
                    if (currentNode.next.next == null)
                    {
                        last = currentNode;
                        currentNode.next = null;
                        return;
                    }
                    currentNode = currentNode.next;
                }

            }
        }

        public int Size()
        {
            if (IsEmpty()) return 0;

            else {
                int count = 1;
                Node currentNode = first;
                while (currentNode != last) {
                    currentNode = currentNode.next;
                    count++;
                }
                return count;
            }

        }

        public int IndexOf(int value)
        {
            if (IsEmpty())
                return -1;
            else
            {
                int index = 0;
                Node current = first;

                while (current != null)
                {
                    if (current.value == value)
                        return index;
                    current = current.next;
                    index++;
                }

                return -1;


            }

        }

        public Array ToArray()
        {
            int size = this.Size();

            int[] returnArray = new int[size];

            Node currentNode = first;

            for (int i = 0; i < size; i++)
            {
                if (currentNode != null)
                {
                    returnArray[i] = currentNode.value;
                    currentNode = currentNode.next;
                }
            }

            return returnArray;


        }

        public void Reverse()
        {
            if (IsEmpty())
                return;
            else
            {
                if (this.first == this.last)
                    return;
                Node previous;
                Node current = first;
                this.last = first;
                Node next = first.next;

                while (next != null)
                {
                    previous = current;
                    current = next;
                    next = current.next;
                    current.next = previous;
                }

                first = current;
                last.next = null;
            }

        }

        public int NodeFromLast(int nodeNumber)
        {
            return 0;

        }


        private bool IsEmpty()
        {
            return first == null;
        }



    }
    #endregion linkedlist

    #region stack
    public class Stack
    {
        private int[] intArray = new int[100];
        private int count = 0;

        public void Push(int value)
        {
            intArray[count] = value;
            count++;

        }

        public int Pop()
        {

            if (IsEmpty())
                throw new Exception("Stack is empty");

            int returnValue = intArray[count];
            count--;
            return returnValue;

        }

        public int Peek()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty");

            int returnValue = intArray[count];
            return returnValue;


        }

        public bool IsEmpty()
        {
            return count == 0;
        }



        public bool CheckIfStringIsInFormat(string inputStr)
        {
            Stack<char> charStack = new Stack<char>();
            Dictionary<char, char> bracesDict = new Dictionary<char, char>();
            bracesDict.Add('}', '{');
            bracesDict.Add(']', '[');
            bracesDict.Add(')', '(');
            bracesDict.Add('>', '<');

            string closingBraces = ">)}]";

            string openBraces = "<{[(";

            foreach (char c in inputStr)
            {
                if (openBraces.Contains(c))

                    charStack.Push(c);

                else if (closingBraces.Contains(c))
                {
                    if (charStack.Count > 0)
                    {
                        char value = charStack.Pop();
                        if (value != bracesDict.GetValueOrDefault(c))
                            return false;
                    }

                    else return false;
                }

            }

            return charStack.Count == 0;

        }

    }
    #endregion stack

    #region ArrayQueue
    //Attribute queue class that internally uses and array
    
    public class ArrayQueue {

        private int[] queueArray;
        private int sizeOfArray;
        private int frontIndex = 0;
        private int lastIndex = 0;
        int count = 0;

        public ArrayQueue(int size)
        {
            queueArray = new int[size];
            sizeOfArray = size;
        }


        public void Enqueue(int value)
        {
            if (count == sizeOfArray)
                throw new Exception("Illegal Argument");
            queueArray[lastIndex] = value;
            lastIndex = (lastIndex + 1) % sizeOfArray;
            count++;

        }

        public int Dequeue()
        {
            int dequeueItem = queueArray[frontIndex];
            queueArray[frontIndex] = 0;
            frontIndex = (frontIndex + 1) % sizeOfArray;
            count--;
            return dequeueItem;


        }

        public int Peek()
        {

            return queueArray[frontIndex];

        }

        public bool isEmpty()
        {
            return frontIndex == lastIndex;
        }

        public bool isFull()
        {
            return count == sizeOfArray;
        }


    }

    #endregion ArrayQueue

    #region StackQueue
    public class StackQueue
    {
        private Stack<int> pushStack;
        private Stack<int> popStack;

        public StackQueue()
        {
            pushStack = new Stack<int>();
            popStack = new Stack<int>();
        }

        public void Enqueue(int value)
        {
            pushStack.Push(value);
        }

        public int Dequeue()
        {
            if (isQueueEmpty())
                throw new Exception("The queue is empty");

            if (popStack.Count != 0)
                return popStack.Pop();


            while (pushStack.Count != 0)
                popStack.Push(pushStack.Pop());

            return popStack.Pop();

        }

        public bool isQueueEmpty()
        {
            return pushStack.Count == 0 && popStack.Count == 0;
        }

        public int Peek()
        {
            if (isQueueEmpty())
                throw new Exception("The queue is empty");

            if (popStack.Count != 0)
                return popStack.Pop();


            while (pushStack.Count != 0)
                popStack.Push(pushStack.Pop());

            return popStack.Peek();
        }




    }
    #endregion ArrayQueue

    #region ArrayQueue
    public class PriorityQueue {

        private int[] items;

        private int count = 0;

        private int lastIndex = 0;


        public PriorityQueue(int size)
        {
            items = new int[size];
        }

        public void Enqueue(int item)
        { 
            if (count == 0)
                items[count] = item;

            for (int i = count - 1; i >= 0; i--)
                if (items[i] > item)
                {
                    items[i + 1] = items[i];
                    items[i] = item;
                }
                else
                    break;
                }




        public int Dequeue()
        {
            int item = items[count];
            count--;
            return item;

        }

       

        public bool IsEmpty()
        {
            return count == 0;
        }

    }
    #endregion ArrayQueue


    #region HashTable

    public class CustomeHashTable       
    {
        private LinkedList<Entry>[] ls;

        public CustomeHashTable(int sizeOfArray)
        {
            ls = new LinkedList<Entry>[sizeOfArray];

        }
      
        private class Entry{

            public int key;
            public string value;

            public Entry(int key, string value)
            {
                this.key = key;
                this.value = value;
            }

        }

        public void Put(int key, string value)
        {
            var item = new Entry(key, value);

            int index = GetHashValue(key);

            if (ls[index] == null)
                ls[index] = new LinkedList<Entry>();

            foreach (var entry in ls[index])
            {
                if (entry.key == key)
                {
                    entry.value = value;
                    return;
                }
            }

            ls[index].AddLast(item);
            return;

        }

        public string Get(int key)
        {

            int index = GetHashValue(key);
            foreach (var entry in ls[index])
            {
                if (entry.key == key)
                    return entry.value;

            }

            return null;

        }

        public void Remove(int key)
        {
            int index = GetHashValue(key);

            if (ls[index].Count > 0)
                foreach (Entry entry in ls[index])
                {
                    if (entry.key == key)
                    {
                        ls[index].Remove(entry);
                        return;
                    }
                }

            throw new Exception("Illegal item. Item not present in the hashtable");
        }

        private int GetHashValue(int key)
        {
            return key % ls.Length;

        }

    }

    #endregion HashTable






}
