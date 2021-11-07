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

		public ArrayList(int[] array)
		{
			_array = new int[(int)(array.Length * 1.5 + 1)];
			Array.Copy(array, _array, array.Length);
			Length = array.Length;
		}

		//1. добавление значения в конец
		public void AddElementToEnd(int value)
		{
			if (Length == _array.Length)
			{
				IncreaseArraySize();
			}
			_array[Length] = value;
			Length++;
		}

		// 2. добавление значения в начало
		public void AddToBeginning(int value)
		{
			if (Length == _array.Length)
			{
				IncreaseArraySize();
			}
			ShiftRight();
			Length++;
			_array[0] = value;
		}

		//3. добавление значения по индексу
		public void AddElementByIndex(int value, int index)
		{
			if (Length == _array.Length)
			{
				IncreaseArraySize();
			}
			ShiftRight(index);
			Length++;
			_array[index] = value;
		}

		//4. удаление из конца одного элемента
		public void RemoveLastElement()
		{
			_array[Length - 1] = 0;
			Length--;
		}

		//5. удаление из начала одного элемента
		public void RemoveFirstElement()
		{
			_array[0] = 0;
			ShiftLeft();
			Length--;
		}

		//6. удаление по индексу одного элемента
		public void RemoveAtIndex(int index)
		{
			_array[index] = 0;
			ShiftLeft(index);
			Length--;
		}

		//7. удаление из конца N элементов 
		public void RemoveLastNTimes(int n)
		{
			for (int i = 0; i < n; i++)
			{
				RemoveLastElement();
			}
		}

		//8. удаление из начала N элементов
		public void RemoveFirstNTimes(int n)
		{
			for (int i = 0; i < n; i++)
			{
				RemoveFirstElement();
			}
		}

		//9.удаление по индексу N элементов 
		public void RemoveAtIndexNTimes(int n, int index)
		{
			for (int i = 0; i < n; i++)
			{
				RemoveAtIndex(index);
			}
		}

		//10. вернуть длину
		public int GetLength()
		{
			int length = 0;
			length = Length;
			return length;
		}

		//11. доступ по индексу
		public int GetIndexAcsess(int index)
		{
			int value = 0;
			value = _array[index];
			return value;
		}

		//12. первый индекс по значению
		public int GetFirstIndexByValue(int value)
		{
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

		//13. изменение по индексу 
		public void GetChangeByIndex(int index, int value)
		{
			int tmp = 0;
			tmp = _array[index];
			_array[index] = value;
			value = tmp;
        }

		//14.реверс
        public void GetReverse()
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

        //15. поиск значения максимального элемента
        public int GetMaximumElement()
		{
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
		//16. поиск значения минимального элемента
		public int GetMinimumElement()
		{
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
		//17. поиск индекс максимального элемента
		public int GetIndexMaximumElement()
		{
            int max = _array[0];
            int indexMax = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    indexMax = i;
                }
            }
            return indexMax;
        }
		//18. поиск индекс минимального элемента
		public int GetIndexMinimumElement()
		{
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
		//19. сортировка по возрастанию
		public void GetSortAscerding()
		{
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
		//20. сортировка по убыванию
		public void GetSortDescending()
		{
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
		//21. удаление по значению первого(?вернуть индекс) -удали первую 7= первую семерку котоорую он встретит удаляетБ если нет -1
		public void RemoveByValueOfFirst(int value)
		{
			for (int i = 0; i < Length; i++)
			{
				if (_array[i] == value)
				{
					_array[i] = 0;
					ShiftLeft(i);
					Length--;
				}
			}
		}
		//22. удаление по значению всех(?вернуть кол-во)- удаление всех 7 в массиве
		public void RemoveAllValue(int value)
		{
			int count = 0;
			for (int i = 0; i < Length; i++)
			{
				if (_array[i] == value)
				{
					_array[i] = 0;
					count++;
					ShiftLeft(i);
					Length--;
				}
			}
		}
		//23. 3 конструктора(пустой, на основе одного элемента, на основе массива ) -  метод добавить по индексу
		//24. добавление списка(вашего самодельного) в конец
		//25. добавление списка в начало
		//26. добавление списка по индексу


		//увеличение размера массива
		private void IncreaseArraySize()
		{
			int[] tmpArray = new int[(int)(_array.Length * 1.5)];
			for (int i = 0; i < Length; i++)
			{
				tmpArray[i] = _array[i];
			}
			_array = tmpArray;
		}

		//уменьшение размера массива
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

		// Смещает элементы массива с определённой позиции вправо на единицу
		private void ShiftRight(int position = 0)
		{
			// Проверка position
			if (position >= Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			while (Length == _array.Length)
			{
				IncreaseArraySize();
			}
			for (int i = Length - 1; i >= position; i--)
			{
				_array[i + 1] = _array[i];
			}
			for (int i = position; i <= position; i++)
			{
				_array[i] = 0;
			}
		}

		// Смещает элементы массива с определённой позиции влево на единицу
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

		public void WriteToConsole() //для консоли
		{
			for (int i = 0; i < Length; i++)
			{
				Console.Write($"{_array[i]} ");
			}
			Console.WriteLine();
		}

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

		public override string ToString()
		{
			string s = "";
			for (int i = 0; i < Length; i++)
			{
				s += $"{_array[i]} ";
			}
			return s;
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}
