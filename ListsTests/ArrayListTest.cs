using NUnit.Framework;
using Lists;
namespace ListsTests
{
    public class ArrayTests
    {
        //1
        #region AddElementToEndTest
        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        [TestCase(-1, new int[] { 1, 1 }, new int[] { 1, 1, -1 })]
        public void AddElementToEndTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddElementToEnd(value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //2
        #region AddToBeginningTest
        [TestCase(1, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        //[TestCase(1, new int[] { }, new int[] { 1 })]
        [TestCase(-1, new int[] { 1, 1 }, new int[] { -1, 1, 1 })]
        [TestCase(-1, new int[] { 9, 5, 3, 6, 7 }, new int[] { -1, 9, 5, 3, 6, 7 })]
        public void AddToBeginningTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddToBeginning(value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //3
        #region AddElementByIndexTest
        [TestCase(5, 1, new int[] { 1, 1, 1 }, new int[] { 1, 5, 1, 1 })]
        //[TestCase(5, 1, new int[] { }, new int[] { 0, 5 })]
        [TestCase(5, 1, new int[] { 1, 1 }, new int[] { 1, 5, 1 })]
        [TestCase(5, 4, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 6, 5, 7 })]
        public void AddElementByIndexTest(int value, int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddElementByIndex(value, index);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //4
        #region RemoveLastElementTest
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1 })]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 1 }, new int[] { 1 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 6 })]
        public void RemoveLastElementTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveLastElement();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //5
        #region RemoveFirstElementTest
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1 })]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 1 }, new int[] { 1 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 5, 3, 6, 7 })]
        public void RemoveFirstElementTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveFirstElement();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //6
        #region RemoveAtIndexTest
        [TestCase(0, new int[] { 1, 1, 1 }, new int[] { 1, 1 })]
        //[TestCase(0, new int[] { }, new int[] { })]
        [TestCase(0, new int[] { 1, 1 }, new int[] { 1 })]
        [TestCase(2, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 6, 7 })]
        public void RemoveAtIndexTest(int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveAtIndex(index);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //7
        #region RemoveLastNTimesTest
        [TestCase(4, new int[] { 1, 1, 1, 1, 1, }, new int[] { 1 })]
        //[TestCase(0, new int[] { }, new int[] { })]
        [TestCase(2, new int[] { 1, 1 }, new int[] {  })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5 })]
        public void RemoveLastNTimesTest(int n, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveLastNTimes(n);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //8
        #region RemoveFirstNTimesTest
        [TestCase(4, new int[] { 1, 1, 1, 1, 1, }, new int[] { 1 })]
        //[TestCase(0, new int[] { }, new int[] { })]
        [TestCase(2, new int[] { 1, 1 }, new int[] { })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 6, 7 })]
        public void RemoveFirstNTimesTest(int n, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveFirstNTimes(n);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //9
        #region RemoveAtIndexNTimesTest
        [TestCase(2, 0, new int[] { 1, 1, 1, 1, 1, }, new int[] { 1, 1, 1, })]
        //[TestCase(0, new int[] { }, new int[] { })]
        [TestCase(2, 1, new int[] { 1, 1 }, new int[] { })]
        [TestCase(3, 2, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5 })]
        public void RemoveAtIndexNTimesTest(int n, int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveAtIndexNTimes(n, index);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //10
        #region GetLengthTest
        [TestCase(new int[] { 1, 1, 1 }, 3)]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, 1 }, 2)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 5)]
        public void GetLengthTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetLength();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //11
        #region GetIndexAcsessTest
        [TestCase(2, new int[] { 1, 1, 1 }, 1)]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(0, new int[] { -1, 1 }, -1)]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, 6)]
        public void GetIndexAcsessTest(int index, int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetIndexAcsess(index);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //12
        #region GetFirstIndexByValueTest
        [TestCase(1, new int[] { 1, 1, 1 }, 0)]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(-1, new int[] { -1, 1, -1 }, 0)]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, 2)]
        public void GetFirstIndexByValueTest(int value, int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //13
        #region GetChangeByIndexTest
        [TestCase(0, 2, new int[] { 1, 1, 1, 1, 1, }, new int[] { 2, 1, 1, 1, 1, })]
        //[TestCase(0, new int[] { }, new int[] { })]
        [TestCase(1, 2, new int[] { 1, 1 }, new int[] { 1, 2 })]
        [TestCase(3, 2, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 3, 2, 7 })]
        public void GetChangeByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetChangeByIndex(index, value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //14
        #region GetReverseTest
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1 })]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 7, 6, 3, 5, 9 })]
        public void GetReverseTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetReverse();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //15
        #region GetMaximumElementTest
        [TestCase(new int[] { 1, 1, 1 }, 1)]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, 1 }, 1)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 9)]
        public void GetMaximumElementTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetMaximumElement();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //16
        #region GetMinimumElementTest
        [TestCase(new int[] { 1, 1, 1 }, 1)]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, 1 }, -1)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 3)]
        public void GetMinimumElementTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetMinimumElement();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //17
        #region GetIndexMaximumElementTest
        [TestCase(new int[] { 1, 1, 1, 1, 1, }, 0)]
        //[TestCase(new int[] { }, )]
        [TestCase(new int[] { -1, 1 }, 1)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 0)]
        public void GetIndexMaximumElementTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetIndexMaximumElement();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //18
        #region GetIndexMinimumElementTest
        [TestCase(new int[] { 1, 1, 1, 1, 1, }, 0)]
        //[TestCase(new int[] { }, )]
        [TestCase(new int[] { -1, 1 }, 0)]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, 2)]
        public void GetIndexMinimumElementTest(int[] array, int expected)
        {
            ArrayList _array = new ArrayList(array);
            int actual = _array.GetIndexMinimumElement();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //19
        #region GetSortAscerdingTest
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0, 2, -1 }, new int[] { -1, 0, 2 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 3, 5, 6, 7, 9})]
        public void GetSortAscerdingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetSortAscerding();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //20
        #region GetSortDescendingTest
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        //[TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 2, -1, 0 }, new int[] { 2, 0, -1 })]
        [TestCase(new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 7, 6, 5, 3 })]
        public void GetSortDescendingTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.GetSortDescending();

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //21
        #region RemoveByValueOfFirstTest
        [TestCase(3, new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 })]
        [TestCase(1, new int[] { }, new int[] { })]
        [TestCase(-1, new int[] { -1, 1 }, new int[] { 1 })]
        [TestCase(3, new int[] { 9, 5, 3, 6, 7 }, new int[] { 9, 5, 6, 7 })]
        public void RemoveByValueOfFirstTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveByValueOfFirst(value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

        //22
        #region RemoveAllValueTest
        //[TestCase(1, new int[] { 1, 1, 1 }, new int[] { })]
        [TestCase(1, new int[] { }, new int[] { })]
        [TestCase(-1, new int[] { -1, 1, -1, 1}, new int[] { 1, 1 })]
        [TestCase(7, new int[] { 9, 5, 7, 3, 6, 7 }, new int[] { 9, 5, 3, 6 })]
        public void RemoveAllValueTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.RemoveAllValue(value);

            Assert.AreEqual(expected, actual);

        }
        #endregion

    }
}
