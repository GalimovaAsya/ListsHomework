using System;
using NUnit.Framework;
using Lists;

namespace ListsTests
{
    public class DoublyLinkedListTest
    {
        //1 ok
        #region AddTest
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(1, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 1 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 0 })]
        [TestCase(-5, new int[] { -1, -2, -3, -4 }, new int[] { -1, -2, -3, -4, -5 })]
        [TestCase(2, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 6, 7, 2 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            DoublyLinkedList actual = new DoublyLinkedList(array);
            DoublyLinkedList expected = new DoublyLinkedList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //2 ok
        #region AddFirstTest
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(1, new int[] { 0, 0, 0, 0 }, new int[] { 1, 0, 0, 0, 0 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5, 6 })]
        [TestCase(-5, new int[] { -1, -2, -3, -4 }, new int[] { -5, -1, -2, -3, -4 })]
        [TestCase(2, new int[] { 9, 5, 3, 6, 7 }, new int[] { 2, 9, 5, 3, 6, 7 })]
        public void AddFirstTest(int value, int[] array, int[] expectedArray)
        {
            DoublyLinkedList actual = new DoublyLinkedList(array);
            DoublyLinkedList expected = new DoublyLinkedList(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //4 ok
        #region RemoveLastTest
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 0, 0, 0, 0, 1 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -1, -2 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 6 })]
        public void RemoveLastTest(int[] array, int[] expectedArray)
        {
            DoublyLinkedList actual = new DoublyLinkedList(array);
            DoublyLinkedList expected = new DoublyLinkedList(expectedArray);

            actual.RemoveLast();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void RemoveLastTest_WhenListIsEmpty_ShouldArgumentException(int[] array)
        {
            LinkedList actual = new LinkedList();
            Assert.Throws<NullReferenceException>(() => actual.RemoveLast());

        }
        #endregion

        //5 ok
        #region RemoveFirstTest
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { -1, -2, -3, -4 }, new int[] { -2, -3, -4 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 5, 3, 6, 7 })]
        public void RemoveFirstTest(int[] array, int[] expectedArray)
        {
            DoublyLinkedList actual = new DoublyLinkedList(array);
            DoublyLinkedList expected = new DoublyLinkedList(expectedArray);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void RemoveFirstTest_WhenListIsEmpty_ShouldNullReferenceException(int[] array)
        {
            DoublyLinkedList actual = new DoublyLinkedList();
            Assert.Throws<NullReferenceException>(() => actual.RemoveFirst());

        }
        #endregion

        //6
        #region RemoveByIndexTest
        [TestCase(0, new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 6 })]
        [TestCase(2, new int[] { -1, -2, -3, -4 }, new int[] { -1, -2, -4 })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 7 })]
        public static void RemoveByIndexTest(int index, int[] array, int[] expectedArray)
        {
            DoublyLinkedList actual = new DoublyLinkedList(array);
            DoublyLinkedList expected = new DoublyLinkedList(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);

        }

        //[TestCase(12, new int[] { -1, -2, -3, -4, -5 })]
        [TestCase(-1, new int[] { 0, 0 })]
        public void RemoveByIndexTest_WhenIndexIsOutOfRange_ShouldIndexOutOfRange(int index, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));

        }

        [TestCase(new int[] { })]
        public void RemoveByIndexTest_WhenListIsEmpty_ShouldNullReferenceException(int[] array)
        {
            LinkedList actual = new LinkedList();
            Assert.Throws<NullReferenceException>(() => actual.RemoveFirst());

        }
        #endregion

        //7 ok
        #region RemoveLastNTimesTest
        [TestCase(2, new int[] { 550, -54 }, new int[] { })]
        [TestCase(3, new int[] { 0, 0, 0, 0 }, new int[] { 0 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2 })]
        [TestCase(2, new int[] { -1, -2, -3 }, new int[] { -1 })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5 })]
        public static void RemoveLastNTimesTest(int n, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveLastNTimes(n);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(6, new int[] { })]
        public void RemoveLastNTimesTest_WhenListIsEmpty_ShouldNullReferenceException(int n, int[] array)
        {
            LinkedList actual = new LinkedList();
            Assert.Throws<NullReferenceException>(() => actual.RemoveLastNTimes(n));

        }
        #endregion

        //8 ok
        #region RemoveFirstNTimesTest
        [TestCase(2, new int[] { 550, -54 }, new int[] { })]
        [TestCase(3, new int[] { 0, 0, 0, 0 }, new int[] { 0 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(2, new int[] { -1, -2, -3 }, new int[] { -3 })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 6, 7 })]
        public static void RemoveFirstNTimesTest(int n, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveFirstNTimes(n);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(2, new int[] { })]
        public void RemoveFirstNTimesTest_WhenListIsEmpty_ShouldNullReferenceException(int n, int[] array)
        {
            LinkedList actual = new LinkedList();
            Assert.Throws<NullReferenceException>(() => actual.RemoveFirstNTimes(n));

        }
        #endregion
    }
}
