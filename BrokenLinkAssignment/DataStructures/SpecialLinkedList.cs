using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    // Implement linked list datastructure and all missing members for it
    public class SpecialLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private int count;
        private Node<T> tempNode;
        private Node<T> lastNode;
        
        public T Head    
        {
            get
            {
                return _head.Value;              
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(_head, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            count++;           
            var node = new Node<T>() {Value = item};
            if(_head == null)
            {
                _head = node;              
            }
            else
            {
                tempNode.Next = node;
            }
            tempNode = node;
            
        }

        public void Remove(T item)
        {
            tempNode = _head;
            lastNode = null;
            int size = 0;

            while (tempNode != null)
            {
                if (Equals(item, tempNode.Value) && size == 0)
                {
                    _head = tempNode.Next;
                    count--;
                    return;
                }

                if (Equals(item, tempNode.Value) && size > 0)
                {
                    lastNode.Next = tempNode.Next;
                    count--;
                    return;                    
                }

                size++;
                lastNode = tempNode;
                tempNode = tempNode.Next;               
            }
            throw new ElementNotFoundException(string.Format("The following item was not found in the list: {0}", item));         
        }

        public void RemoveAt(int index)
        {
            tempNode = _head;
            lastNode = null;
            int size = 1;

            if (index == 0)
            {
                _head = tempNode.Next;
                count--;
                return;
            }

            if (index >= 1 && index <= count)
            {
                while (tempNode != null)
                {
                    
                    if (index == size)
                    {
                        lastNode.Next = tempNode.Next;
                        count--;
                        return;
                    }
                    size++;
                    lastNode = tempNode;
                    tempNode = tempNode.Next;
                }
            }
            throw new IndexOutOfRangeException();           
        }

        public override string ToString()
        {
            Node<T> tempNode = _head;
            string temp = "";
            char[] MyChar = { ',' };

            while (tempNode != null)
            {
                temp = temp + tempNode.Value + ",";               
                tempNode = tempNode.Next;
            }                                                   // should print all members separated by comma (CSV format)          
            temp = temp.TrimEnd(MyChar);
            return temp;
        }

        public string ToStringReverse()
        {
            Node<T> tempNode = _head;
            string temp = "";
            char[] MyChar = { ',' };

            while (tempNode != null)
            {
                temp = tempNode.Value + "," + temp;   // should print all members separated by comma in reverse order (figure the best and most performant way)
                tempNode = tempNode.Next;
            }         
            temp = temp.TrimEnd(MyChar);
            return temp;
        }

        public T this[int index]
        {
            get
            {                
                tempNode = _head;
                lastNode = null;
                int size = 0;

                if (index >= 0 && index <= count)
                {
                    while (tempNode != null)
                    {
                        if (index == size)
                        {
                            return tempNode.Value;
                        }
                        size++;
                        lastNode = tempNode;
                        tempNode = tempNode.Next;
                    }
                }     
                throw new IndexOutOfRangeException();                                                                          
            }
            set
            {
                tempNode = _head;
                lastNode = null;
                int size = 1;

                if (index >= 0 && index <= count)
                {
                    while (tempNode != null)
                    {

                        if (index == size)
                        {
                            Console.WriteLine("Success");
                            tempNode.Value = value;
                        }
                        size++;
                        lastNode = tempNode;
                        tempNode = tempNode.Next;
                    }
                }
                throw new IndexOutOfRangeException();
            }
        }
    }
    public class Enumerator<T> : IEnumerator<T>
    {
        private Node<T> tempNode;
        private int x = 0;
        private int count;

        public Enumerator(Node<T> head, int count)
        {
            tempNode = head;
            this.count = count;
        }

        public T Current
        {
            get
            {
                if (tempNode == null)
                {
                    return default(T);
                }
                return tempNode.Value;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            tempNode = null;
        }

        public bool MoveNext()
        {
            if (x != 0)
            {
                if (count == x)
                    return false;
                tempNode = tempNode.Next;                
            }
            x++;

            return true;
        }

        public void Reset()
        {
            tempNode = null;
        }
    }
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message)
           : base(message)
        {
        }
    }
}
