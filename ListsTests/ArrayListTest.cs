﻿using System;
using NUnit.Framework;
using Lists;

namespace ListsTests
{
    public class ArrayListTests
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
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

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
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //3 ok
        #region AddByIndexTest
        [TestCase(0, 1, new int[] { 1, 1, 1 }, new int[] { 1, 0, 1, 1 })]
        [TestCase(1, 3, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 1, 0 })]
        [TestCase(0, 0, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5, 6 })]
        [TestCase(-3, 2, new int[] { -1, -2, -4 }, new int[] { -1, -2, -3, -4 })]
        [TestCase(-5, 2, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, -5, 3, 6, 7 })]
        public void AddByIndexTest(int value, int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(5, -1, new int[] { 0, 0 })]
        [TestCase(5, 12, new int[] { -1, -2, -3, -4, -5 })]
        [TestCase(-5, 4, new int[] { -1, -2, -3, -4 })]
        public static void AddByIndexTest_WhenIndexIsOutOfRange_ShouldIndexOutOfRange(int value, int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));

        }
        #endregion

        //4 ok
        #region RemoveLastTest
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 0, 0, 0, 0, 1 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -1, -2 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 6 })]
        public void RemoveLastTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveLast();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //5 ok
        #region RemoveFirstTest
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { -1, -2, -3, -4 }, new int[] { -2, -3, -4 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 5, 3, 6, 7 })]
        public void RemoveFirstTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveFirst();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //6 ok
        #region RemoveByIndexTest
        [TestCase(0, new int[] { 5 }, new int[] { })]
        [TestCase(0, new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 6 })]
        [TestCase(2, new int[] { -1, -2, -3, -4 }, new int[] { -1, -2, -4 })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 7 })]
        public static void RemoveByIndexTest(int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(-1, new int[] { 0, 0 })]
        [TestCase(12, new int[] { -1, -2, -3, -4, -5 })]
        public static void RemoveByIndexTest_WhenIndexIsOutOfRange_ShouldIndexOutOfRange(int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndex(index));

        }
        #endregion

        //7 ok
        #region RemoveLastNTimesTest
        [TestCase(5, new int[] { }, new int[] { })]
        [TestCase(2, new int[] { 550, -54 }, new int[] { })]
        [TestCase(3, new int[] { 0, 0, 0, 0 }, new int[] { 0 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2 })]
        [TestCase(2, new int[] { -1, -2, -3 }, new int[] { -1 })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5 })]
        public static void RemoveLastNTimesTest(int n, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveLastNTimes(n);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //8 ok
        #region RemoveFirstNTimesTest
        [TestCase(5, new int[] { }, new int[] { })]
        [TestCase(2, new int[] { 550, -54 }, new int[] { })]
        [TestCase(3, new int[] { 0, 0, 0, 0 }, new int[] { 0 })]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6 })]
        [TestCase(2, new int[] { -1, -2, -3 }, new int[] { -3 })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 6, 7 })]
        public static void RemoveFirstNTimesTest(int n, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveFirstNTimes(n);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //9 ok
        #region RemoveByIndexNTimesTest
        [TestCase(2, 3, new int[] { 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0 })]
        [TestCase(1, 2, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 5, 6 })]
        [TestCase(0, 3, new int[] { -1, -2, -3, -4 }, new int[] { -1 })]
        [TestCase(1, 2, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 7 })]
        public static void RemoveByIndexNTimesTest(int index, int n, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveByIndexNTimes(index, n);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(0, 2, new int[] { 5 })]
        [TestCase(-1, 5, new int[] { 0, 0 })]
        [TestCase(12, 5, new int[] { -1, -2, -3, -4, -5 })]
        public void RemoveByIndexNTimesTest_WhenIndexIsOutOfRange_ShouldIndexOutOfRange(int index, int n, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndexNTimes(index, n));//конкретный кот при каких аргументах должен сломаться

        }
        #endregion

        //10 ok
        #region GetLengthTest
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 550, -54 }, 2)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 4)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 7)]
        [TestCase(new int[] { -1, -2, -3 }, 3)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 5)]
        public static void GetLengthTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetLength();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //11 ok
        #region GetValueByIndexTest
        [TestCase(0, new int[] { 5 }, 5)]
        [TestCase(1, new int[] { 550, -54 }, -54)]
        [TestCase(0, new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(6, new int[] { 0, 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(1, new int[] { -1, -2, -3 }, -2)]
        [TestCase(2, new int[] { 9, 5, 3, 6, 7 }, 3)]
        public static void GetValueByIndexTest(int index, int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetValueByIndex(index);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(-1, new int[] { 0, 0 })]
        public void GetValueByIndexTest_WhenIndexIsOutOfRange_ShouldIndexOutOfRange(int index, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.GetValueByIndex(index));//конкретный кот при каких аргументах должен сломаться
        }
        #endregion

        //12 ok
        #region GetIndexByValueTest
        [TestCase(-54, new int[] { 550, -54 }, 1)]
        [TestCase(0, new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(6, new int[] { 0, 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(-3, new int[] { -1, -2, -3 }, 2)]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, 2)]
        public static void GetIndexByValueTest(int value, int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetIndexByValue(value);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(1, new int[] { })]
        public void GetIndexByValueTest_WhenArrayIsEmpty_ShouldNullReferenceException(int index, int[] array)
        {
            ArrayList actual = new ArrayList();
            Assert.Throws<NullReferenceException>(() => actual.GetIndexByValue(index));

        }
        #endregion

        //13 ok
        #region ChangeValueByIndexTest
        [TestCase(0, 5, new int[] { 550, -54 }, new int[] { 5, -54 })]
        [TestCase(1, -5, new int[] { 0, 0, 0, 0 }, new int[] { 0, -5, 0, 0 })]
        [TestCase(6, 15, new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5, 15 })]
        [TestCase(1, 8, new int[] { -1, -2, -3 }, new int[] { -1, 8, -3 })]
        [TestCase(2, 0, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 0, 6, 7 })]
        public static void ChangeValueByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.ChangeValueByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(1, 8, new int[] { })]
        public void ChangeValueByIndexTest_WhenArrayIsEmpty_ShouldNullReferenceException(int index, int value, int[] array)
        {
            ArrayList actual = new ArrayList();
            Assert.Throws<NullReferenceException>(() => actual.ChangeValueByIndex(index, value));

        }
        #endregion

        //14 ok
        #region ReverseTest
        [TestCase(new int[] { 550, -54 }, new int[] { -54, 550 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -3, -2, -1 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 7, 6, 3, 5, 9 })]
        public static void ReverseTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Reverse();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //15 ok
        #region GetMaximumElementTest
        [TestCase(new int[] { 550, -54 }, 550)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new int[] { -1, -2, -3 }, -1)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 9)]
        public static void GetMaximumElementTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetMaximumElement();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void GetMaximumElementTest_WhenListIsEmpty_ShouldNullReferenceException(int[] array)
        {
            ArrayList actual = new ArrayList();
            Assert.Throws<NullReferenceException>(() => actual.GetMaximumElement());

        }
        #endregion

        //16 ok
        #region GetMinimumElementTest
        [TestCase(new int[] { 550, -54 }, -54)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 0)]
        [TestCase(new int[] { -1, -2, -3 }, -3)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 3)]
        public static void GetMinimumElementTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetMinimumElement();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void GetMinimumElementTest_WhenListIsEmpty_ShouldNullReferenceException(int[] array)
        {
            ArrayList actual = new ArrayList();
            Assert.Throws<NullReferenceException>(() => actual.GetMinimumElement());

        }
        #endregion

        //17 ok
        #region GetIndexOfMaxTest
        [TestCase(new int[] { 550, -54 }, 0)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new int[] { -1, -2, -3 }, 0)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 0)]
        public static void GetIndexOfMaxTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetIndexOfMax();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void GetIndexOfMaxTest_WhenListIsEmpty_ShouldNullReferenceException(int[] array)
        {
            ArrayList actual = new ArrayList();
            Assert.Throws<NullReferenceException>(() => actual.GetIndexOfMax());

        }
        #endregion

        //18 ok
        #region GetIndexOfMinTest
        [TestCase(new int[] { 550, -54 }, 1)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 0)]
        [TestCase(new int[] { -1, -2, -3 }, 2)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 2)]
        public static void GetIndexOfMinTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetIndexOfMin();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void GetIndexOfMinTest_WhenListIsEmpty_ShouldNullReferenceException(int[] array)
        {
            ArrayList actual = new ArrayList();
            Assert.Throws<NullReferenceException>(() => actual.GetIndexOfMin());

        }
        #endregion

        //19 ok
        #region GetSortAscerdingTest
        [TestCase(new int[] { 550, -54 }, new int[] { -54, 550 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 0, 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -3, -2, -1 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 3, 5, 6, 7, 9 })]
        public static void GetSortAscerdingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetSortAscerding();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void GetSortAscerdingTest_WhenListIsEmpty_ShouldNullReferenceException(int[] array)
        {
            ArrayList actual = new ArrayList();
            Assert.Throws<NullReferenceException>(() => actual.GetSortAscerding());

        }
        #endregion

        //20 ok
        #region GetSortDescendingTest
        [TestCase(new int[] { 550, -54 }, new int[] { 550, -54 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -1, -2, -3 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 7, 6, 5, 3 })]
        public static void GetSortDescendingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetSortDescending();

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { })]
        public void GetSortDescendingTest_WhenListIsEmpty_ShouldNullReferenceException(int[] array)
        {
            ArrayList actual = new ArrayList();
            Assert.Throws<NullReferenceException>(() => actual.GetSortDescending());

        }
        #endregion

        //21 ok
        #region RemoveFirstByValueTest
        [TestCase(550, new int[] { 550, -54 }, 0)]
        [TestCase(0, new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5, 6 }, 4)]
        [TestCase(0, new int[] { -1, -2, -3 }, -1)]
        [TestCase(6, new int[] { 9, 5, 3, 6, 7 }, 3)]
        public static void RemoveFirstByValueTest(int value, int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(8, new int[] { })]
        public void RemoveFirstByValueTest_WhenListIsEmpty_ShouldNullReferenceException(int value, int[] array)
        {
            LinkedList actual = new LinkedList();
            Assert.Throws<NullReferenceException>(() => actual.RemoveFirstByValue(value));

        }
        #endregion

        //22 ok
        #region RemoveAllValueTest
        [TestCase(550, new int[] { 550, -54 }, 1)]
        [TestCase(4, new int[] { 0, 1, 2, 3, 4, 5, 6 }, 1)]
        [TestCase(-1, new int[] { -1, -2, -3, -1, -1 }, 3)]
        [TestCase(6, new int[] { 9, 6, 5, 3, 6, 7 }, 2)]
        [TestCase(6, new int[] { 9, 5, 3, 7 }, -1)]
        public static void RemoveAllValueTest(int value, int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.RemoveAllValue(value);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(8, new int[] { })]
        public void RemoveAllValueTest_WhenListIsEmpty_ShouldNullReferenceException(int value, int[] array)
        {
            LinkedList actual = new LinkedList();
            Assert.Throws<NullReferenceException>(() => actual.RemoveAllValue(value));

        }
        #endregion

        //#region AddTest
        //[TestCase(new int[] { }, new int[] { }, new int[] { })]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 1, 2, 3, 4, 5, 6 })]
        //[TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 0, 0, 0, 0 })]
        //[TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { -1, -2, -3, -4 }, new int[] { -1, -2, -3, -4, 9, 5, 3, 6, 7 })]
        //[TestCase(new int[] { -1, -2, -3, -4 }, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 6, 7, -1, -2, -3, -4 })]
        //public void AddTest(int[] array, int[]actualArray, int[] expectedArray)
        //{
        //    ArrayList actual = new ArrayList(actualArray);
        //    ArrayList expected = new ArrayList(expectedArray);

        //    actual.Add(array);

        //    Assert.AreEqual(expected, actual);

        //}
        //#endregion

    }
}
