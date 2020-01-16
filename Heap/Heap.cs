 using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Data structure
/// Binary heap
/// </summary>
namespace Heap
{
    /// <summary>
    /// Binary heap
    /// The sorted queue with priority
    /// It's maybe sorted by ascending with max item on the top of the heap or by descending with min item on the top of the heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Heap<T> : IEnumerable
        where T : IComparable<T>
    {
        private List<T> items = new List<T>();

        private int maxHeap;

        /// <summary>
        /// Property IsMax
        /// True  - Max type of heap sorted by ascending with max item on the top of the heap
        /// False - Min type of heap sorted by descending with min item on the top of the heap
        /// </summary>
        public bool IsMax => maxHeap > 0 ? true : false;

        /// <summary>
        /// Property Count
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        /// Property Top
        /// Get the data on the top of the heap without removing it
        /// </summary>
        public T Top => Count > 0 ? items[0] : default(T);

        /// <summary>
        /// Constructor 1
        /// </summary>
        /// <param name="isMaxHeap"></param>
        public Heap(bool isMaxHeap = true)
        {
            maxHeap = isMaxHeap ? 1 : -1;
        }

        /// <summary>
        /// Constructor 2
        /// </summary>
        /// <param name="unsortedItems"></param>
        /// <param name="isMaxHeap"></param>
        public Heap(List<T> unsortedItems, bool isMaxHeap = true) : this(isMaxHeap)
        {
            items.AddRange(unsortedItems);
            for (int i = Count - 1; i >= 0; i--)
            {
                Reorder(i);
                //RecursiveReorder(i);
            }
        }

        /// <summary>
        /// Method Add
        /// Add new data to the back of the heap and resort the heap
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (!(data is T))
                throw new Exception("Неверный параметр!");
            items.Add(data);
            Reorder(Count - 1, false);
            //RecursiveReorder(Count - 1, false);
        }

        /// <summary>
        /// Method GetTop
        /// Get the top of the heap with removing it and resorting
        /// </summary>
        /// <returns></returns>
        public T GetTop()
        {
            if (Count == 0)
                throw new Exception("Куча пустая!");
            T item = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);
            Reorder(0);
            //RecursiveReorder(0);
            return item;
        }

        /// <summary>
        /// Private method Reorder
        /// Sort the private List items
        /// </summary>
        /// <param name="currentIndex"></param>
        private void Reorder(int currentIndex, bool isDown = true)
        {
            T aux;
            int nextIndex, parentIndex, childIndex1, childIndex2;
            while (currentIndex < Count)
            {
                nextIndex = currentIndex;
                if (isDown)
                {
                    childIndex1 = 2 * currentIndex + 1;
                    childIndex2 = 2 * currentIndex + 2;
                    foreach (int i in new int[2] { childIndex1, childIndex2 })
                    {
                        if (i < Count && items[i].CompareTo(items[nextIndex]) == maxHeap)
                        {
                            nextIndex = i;
                        }
                    }
                }
                else
                {
                    parentIndex = (int)(currentIndex - 1) / 2;
                    if (items[nextIndex].CompareTo(items[parentIndex]) == maxHeap)
                    {
                        nextIndex = parentIndex;
                    }
                }
                if (nextIndex != currentIndex)
                {
                    aux = items[nextIndex];
                    items[nextIndex] = items[currentIndex];
                    items[currentIndex] = aux;
                    currentIndex = nextIndex;
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Private method RecursiveReorder
        /// Recursivly sort the private List items
        /// </summary>
        /// <param name="currentIndex"></param>
        private void RecursiveReorder(int currentIndex, bool isDown = true)
        {
            T aux;
            int nextIndex, parentIndex, childIndex1, childIndex2;
            if (currentIndex < Count)
            {
                nextIndex = currentIndex;
                if (isDown)
                {
                    childIndex1 = 2 * currentIndex + 1;
                    childIndex2 = 2 * currentIndex + 2;
                    foreach (int i in new int[2] { childIndex1, childIndex2 })
                    {
                        if (i < Count && items[i].CompareTo(items[nextIndex]) == maxHeap)
                        {
                            nextIndex = i;
                        }
                    }
                }
                else
                {
                    parentIndex = (int)(currentIndex - 1) / 2;
                    if (items[nextIndex].CompareTo(items[parentIndex]) == maxHeap)
                    {
                        nextIndex = parentIndex;
                    }
                }
                if (nextIndex != currentIndex)
                {
                    aux = items[nextIndex];
                    items[nextIndex] = items[currentIndex];
                    items[currentIndex] = aux;
                    RecursiveReorder(nextIndex, isDown);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
                yield return GetTop();
        }
    }
}
