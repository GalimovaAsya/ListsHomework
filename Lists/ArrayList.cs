using System;

namespace Lists
{
	public class ArrayList
	{
		private const int _minArrayLength = 10;

		private int[] _array; //для меня

		public int Length { get; private set; } //пользовательский (количество элементов в массиве)

		public ArrayList()
		{
			Length = 0;
			_array = new int[_minArrayLength];
		}

		public ArrayList(int value)
		{

		}

		public ArrayList(int[] array)
		{
			_array = new int[(int)(array.Length * 1.5 + 1)];
			Array.Copy(array, _array, array.Length);
			Length = array.Length;
		}

		//1. добавление значения в конец
		#region Add
		public void Add(int value)
		{
			if (Length == _array.Length)
			{
				IncreaseArraySize();
			}
			_array[Length] = value;
			Length++;
		}
		#endregion

		// 2. добавление значения в начало
		#region AddFirst
		public void AddFirst(int value)
		{
			if (Length == _array.Length)
			{
				IncreaseArraySize();
			}
			if (Length == 0)
			{
				_array[0] = value;
			}
			ShiftRight();
			Length++;
			_array[0] = value;
		}
		#endregion

		//3. добавление значения по индексу
		#region AddByIndex
		public void AddByIndex(int value, int index)
		{
			if (index >= Length || index < 0)
			{
				throw new IndexOutOfRangeException("index is out of range");
			}
			if (Length == _array.Length)
			{
				IncreaseArraySize();
			}
			ShiftRight(index);
			Length++;
			_array[index] = value;
		}
		#endregion

		//4. удаление из конца одного элемента
		#region RemoveLast
		public void RemoveLast()
		{
			if (Length > 0)
			{
				_array[Length - 1] = 0;
				Length--;
			}
		}
		#endregion

		//5. удаление из начала одного элемента
		#region RemoveFirst
		public void RemoveFirst()
		{
			if (Length > 0)
			{
				_array[0] = 0;
				ShiftLeft();
				Length--;
			}
		}
		#endregion

		//6. удаление по индексу одного элемента
		#region RemoveByIndex
		public void RemoveByIndex(int index)
		{
			if (index > Length || index < 0)
			{
				throw new IndexOutOfRangeException();
			}
			_array[index] = 0;
			ShiftLeft(index);
			Length--;
		}
		#endregion

		//7. удаление из конца N элементов
		#region RemoveLastNTimes
		public void RemoveLastNTimes(int n)
		{
            for (int i = 0; i < n; i++)//долгий метод
            {
                RemoveLast();
            }
            //if (n > Length)
            //{
            //	throw new IndexOutOfRangeException();
            //}
            //Length -= n;
        }
		#endregion

		//8. удаление из начала N элементов
		#region RemoveFirstNTimes
		public void RemoveFirstNTimes(int n)
		{
            for (int i = 0; i < n; i++)//долгий метод
            {
                RemoveFirst();
            }
        }
		#endregion

		//9.удаление по индексу N элементов
		#region RemoveByIndexNTimes
		public void RemoveByIndexNTimes(int index, int n)
		{
			if (index >= Length || index < 0)
			{
				throw new IndexOutOfRangeException();
			}


            for (int i = index + n; i !=index; i--)
            {
                RemoveByIndex(i);
            }
        }
    
		#endregion

		//10. вернуть длину
		#region GetLength
		public int GetLength()
		{
			int length = 0;
			length = Length;
			return length;
		}
		#endregion

		//11. доступ по индексу
		#region GetValueByIndex
		public int GetValueByIndex(int index)
		{
			if (index > Length || index < 0)
			{
				throw new IndexOutOfRangeException();
			}
			int value = 0;
			value = _array[index];
			return value;
		}
		#endregion

		//12. первый индекс по значению
		#region GetIndexByValue
		public int GetIndexByValue(int value)
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int index = 0;
			for (int i = 0; i < Length; i++)
			{
				if (value == _array[i])
				{
					index = i;
					return index;
				}
			}
			return -1;
		}
		#endregion

		//13. изменение по индексу
		#region ChangeValueByIndex
		public void ChangeValueByIndex(int index, int value)
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int tmp = 0;
			tmp = _array[index];
			_array[index] = value;
			value = tmp;
			
        }
		#endregion

		//14.реверс
		#region Reverse
		public void Reverse()
        {
            int x = 0;
			int y = Length - 1;
			while (x < y)
            {
                int tmp = _array[x];
                _array[x] = _array[y];
                _array[y] = tmp;
                x++;
				y--;
			}
        }
		#endregion

		//15. поиск значения максимального элемента
		#region GetMaximumElement
		public int GetMaximumElement()
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int max = _array[0];
			for (int i = 0; i < Length; i++)
			{
				if (_array[i] > max)
				{
					max = _array[i];
				}
			}
			return max;
		}
		#endregion

		//16. поиск значения минимального элемента
		#region GetMinimumElement
		public int GetMinimumElement()
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int min = _array[0];
			for (int i = 0; i < Length; i++)
			{
				if (_array[i] < min)
				{
					min = _array[i];
				}
			}
			return min;
		}
		#endregion

		//17. поиск индекс максимального элемента
		#region GetIndexOfMax
		public int GetIndexOfMax()
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int max = _array[0];
            int indexMax = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    indexMax = i;
                }
            }
            return indexMax;
        }
		#endregion

		//18. поиск индекс минимального элемента
		#region GetIndexOfMin
		public int GetIndexOfMin()
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int min = _array[0];
			int indexMin = 0;
			for (int i = 0; i < Length; i++)
			{
				if (_array[i] < min)
				{
					min = _array[i];
					indexMin = i;
				}
			}
			return indexMin;
		}
		#endregion

		//19. сортировка по возрастанию
		# region GetSortAscerding
		public void GetSortAscerding()
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int tmp = 0;
			for (int i = 0; i < Length - 1; i++)
			{
				for (int j = 0; j < Length - i - 1; j++)
				{
					if (_array[j] > _array[j + 1])
					{
						tmp = _array[j];
						_array[j] = _array[j + 1];
						_array[j + 1] = tmp;
					}
				}
			}
		}
		#endregion

		//20. сортировка по убыванию
		#region GetSortDescending
		public void GetSortDescending()
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int tmp = 0;
			for (int i = 0; i < Length; i++)
			{
				for (int j = i + 1; j < Length; j++)
				{
					if (_array[i] < _array[j])
					{
						tmp = _array[i];
						_array[i] = _array[j];
						_array[j] = tmp;
					}
				}
			}
		}
		#endregion

		//21. удаление по значению первого(?вернуть индекс)
		#region RemoveFirstByValue
		public int RemoveFirstByValue(int value)
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			for (int i = 0; i < Length; i++)
			{
				if (_array[i] == value)
				{
					int index = i;
					_array[i] = 0;
					ShiftLeft(i);
					Length--;
					return index;
				}
			}
			return -1;
		}
		#endregion

		//22. удаление по значению всех(?вернуть кол-во)- удаление всех 7 в массиве
		#region RemoveAllValue
		public int RemoveAllValue(int value)
		{
			if (Length == 0)
			{
				throw new NullReferenceException("Array is empty");
			}

			int count = 0;
			int i = 0;
			while (i <= Length)
			{
				if (_array[i] == value)
				{
					count++;
					_array[i] = 0;
					ShiftLeft(i);
					Length--;
				i--;
				}
				i++;
			}
			if (count > 0)
			{
				return count;
			}
			return -1;
		}
		#endregion

		//23. 3 конструктора(пустой, на основе одного элемента, на основе массива ) -  метод добавить по индексу

		//24. добавление списка(вашего самодельного) в конец
		#region
		public void Add(ArrayList array)
		{

		}
        #endregion

        //25. добавление списка в начало
        #region
		public void AddFirst(ArrayList array)
		{

		}
		#endregion

		//26. добавление списка по индексу
		#region
		public void AddByIndex(ArrayList array, int index)
		{

		}
        #endregion


        //увеличение размера массива
        #region IncreaseArraySize
        private void IncreaseArraySize()
		{
			int[] tmpArray = new int[(int)(_array.Length * 1.5)];
			for (int i = 0; i < Length; i++)
			{
				tmpArray[i] = _array[i];
			}
			_array = tmpArray;
		}
		#endregion

		//уменьшение размера массива
		#region DescreaseArraySize
		private void DescreaseArraySize()
		{
			if (Length < _array.Length)
			{
				int[] tmpArray = new int[(int)(Length * 0.75)];
				for (int i = 0; i < Length; i++)
				{
					tmpArray[i] = _array[i];
				}
				_array = tmpArray;
			}
		}
		#endregion

		// Смещает элементы массива с определённой позиции вправо на единицу
		#region ShiftRight
		private void ShiftRight(int position = 0)
		{
			for (int i = Length - 1; i >= position; i--)
			{
				_array[i + 1] = _array[i];
			}
			for (int i = position; i <= position; i++)
			{
				_array[i] = 0;
			}
		}
		#endregion

		// Смещает элементы массива с определённой позиции влево на единицу
		#region ShiftLeft
		private void ShiftLeft(int position = 0)
		{
			if (position < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			for (int i = position + 1; i <= Length - 1; i++)
			{
				_array[i - 1] = _array[i];
			}
			_array[Length - 1] = 0;
		}
		#endregion

		#region WriteToConsole
		public void WriteToConsole() //для консоли
		{
			for (int i = 0; i < Length; i++)
			{
				Console.Write($"{_array[i]} ");
			}
			Console.WriteLine();
		}
		#endregion

		#region Equals
		public override bool Equals(object obj)
		{
			ArrayList arrayList = (ArrayList)obj;

			if (Length != arrayList.Length)
			{
				return false;
			}

			for (int i = 0; i < Length; i++)
			{
				if (arrayList._array[i] != _array[i])
				{
					return false;
				}
			}

			return true;
		}
		#endregion

		#region ToString
		public override string ToString()
		{
			string s = "";
			for (int i = 0; i < Length; i++)
			{
				s += $"{_array[i]} ";
			}
			return s;
		}
		#endregion

		#region GetHashCode
		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

        public void Add(int[] array)
        {
            throw new NotImplementedException();
        }
        #endregion


        //отбить ошибки с отрицательными индексами
        //отбить пустые массивы

        //ТЕСТЫ:
        //пустой
        //один элемент
        //отрицательные
        //все с нулями
        //отсортированный список


        //если есть индексы => indexoutofrange

        //1 and24 add or addlast
        //2addfirst
        //addbyindex
        //removelast
        //removefirstlast
        //12getfirstindexbyvalue
        //14reverse
        //15getmaxvalue or getmax
        //17getindexofmax
        //21removefirstbyvalue
        //removeallbyvalue
    }
}
