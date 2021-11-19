using System;
namespace Lists
{
    public class DoublyLinkedList
    {
        public int Length { get; private set; }
        private DNode _root;

        private DNode _tail;

        public DoublyLinkedList()
        {
            _root = null;
            _tail = null;
            Length = 0;
        }

        public DoublyLinkedList(int value)
        {
            _root = new DNode(value);
            _tail = _root;
            Length = 1;

        }

        public DoublyLinkedList(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (_root != null)
                {
                    _tail.Next = new DNode(array[i]);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                    Length++;
                }
                else
                {
                    _root = new DNode(array[i]);
                    _tail = _root;
                    Length = 1;
                }
            }

        }

        //1. добавление значения в конец
        #region Add
        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new DNode(value);
                _tail = _root;
                Length = 1;
            }
            else
            {
                _tail.Next = new DNode(value);//хвост tail ссылается на новую ноду
                _tail.Next.Previous = _tail;//и новая нода ссылается на хвост - замыкающая ссылка назад
                _tail = _tail.Next;
                Length++;
            }
        }
        #endregion

        //2. добавление значения в начало
        #region AddFirst
        public void AddFirst(int value)
        {
            DNode tmp = new DNode(value);

            if (_root != null)
            {
                tmp.Next = _root;
                _root.Previous = tmp;
            }
            _root = tmp;
            Length++;
        }
        #endregion

        //3. добавление значения по индексу
        #region AddByIndex
        public void AddByIndex(int value, int index)//1 2 3 9 4 5 6
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == Length)
            {
                Add(value);
            }
            else
            {
                DNode tmp = _root.Next;
                int position = 1;
                while (tmp != null && position != index)
                {
                    tmp = tmp.Next;
                    position++;
                }
                DNode newNode = new DNode(value);

                tmp.Previous.Next = newNode;
                newNode.Previous = tmp.Previous;
                tmp.Previous = newNode;
                newNode.Next = tmp;

                Length++;
            }
        }
        #endregion

        //4. удаление из конца одного элемента
        #region RemoveLast
        public void RemoveLast()
        {
            if (_root == null && _tail == null)
            {
                throw new NullReferenceException("List is empty");
            }
            else if (_root.Next == null)//_root=_tail
            {
                _root = null;
            }
            else
            {
                _tail = _tail.Previous;
                _tail.Next = null;
                Length--;
            }
        }
        #endregion

        //5. удаление из начала одного элемента
        #region RemoveFirst
        public void RemoveFirst()
        {
            if (_root == null)
            {
                throw new NullReferenceException("List is empty");
            }
            if (_root.Next != null)
            {
                _root = _root.Next;
            }
            else if (_root.Next == null)
            {
                _root = null;
            }
            else
            {
                _root = null;
            }
        }
        #endregion

        //6. удаление по индексу одного элемента
        #region RemoveByIndex
        public void RemoveByIndex(int index)// 1 2 3 4//2
        {
            //3 варианта
            //_рут=_тейл;
            //два элемента
            bool isIndexLeft = index < Length / 2;//к чему ближе находится элемент? к концу или началу?
            DNode crnt;
            int numberOfSteps;
            if (index < 0 || Length < index)
            {
                throw new IndexOutOfRangeException();
            }

            if (isIndexLeft)
            {
                crnt = _root;
                numberOfSteps = index;
            }
            else
            {
                crnt = _tail;
                numberOfSteps = Length - index;
            }

            for (int i = 1; i < numberOfSteps; i++)
            {
                crnt = isIndexLeft ? crnt.Next:crnt.Previous;//условие до ? после будет вот это : иначе
            }

            if (crnt != _root && crnt != _tail)//нода не последняя и не первая
            {
                crnt.Previous.Next = crnt.Next;//удаление ноды
                crnt.Next.Previous = crnt.Previous;//для случаев если нода не первая и не последняя
                Length--;
            }
            else if (crnt == _root && crnt == _tail)//если один элемент
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else if (crnt == _root)
            {
                crnt.Next.Previous = null;//убиваем ссылку второго элемента на первый чтобы на него никто не ссылался
                _root = crnt.Next;
            }
            else 
            {
                crnt.Previous.Next = null;
                _tail = crnt.Previous;
            }
            Length--;
        }
        #endregion

        //7. удаление из конца N элементов
        #region RemoveLastNTimes
        public void RemoveLastNTimes(int n)
        {
            DNode tmp = _tail;
            if (_root == null && _tail == null)
            {
                throw new NullReferenceException("List is empty");
            }

            for (int i = Length; i != n; i--)
            {
                tmp = tmp.Previous;
            }
            _tail.Previous = null;
            _root = _tail.Previous;
        }
        #endregion

        //8. удаление из начала N элементов
        #region RemoveFirstNTimes
        public void RemoveFirstNTimes(int n)
        {
            DNode tmp = _root;
            if (_root == null && _tail == null)
            {
                throw new NullReferenceException("List is empty");
            }

            for (int i = 0; i != n; i++)
            {
                tmp = tmp.Next;
            }
            _tail.Previous = null;
            _root = _tail.Previous;
        }
        //добежать до нужного и рут=новый
        #endregion

        //9. удаление по индексу N элементов
        #region RemoveByIndexNTimes
        public void RemoveByIndexNTimes(int index, int n)
        {
            
        }
        #endregion

        ////10. вернуть длину
        //#region GetLength
        //public int GetLength()
        //{

        //}
        //#endregion

        //11. доступ по индексу// вводим индекс вывести элемент
        #region GetValueByIndex
        public int GetValueByIndex(int index)// 1 2 3 4 5 6 7// 2 index
        {
            DNode tmp = _root;
            if (_root == null && _tail == null)
            {
                throw new NullReferenceException("List is empty");
            }

            if (index < 0 || Length < index)
            {
                throw new IndexOutOfRangeException();
            }

            if (index < (Length / 2))
            {
                tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    if (tmp.Next == null)
                    {
                        return -1;
                    }
                    tmp = tmp.Next;                   
                }

            }
            else
            {
                tmp = _tail;
                for (int i = Length - 1; i > index; i--)
                {
                    if (tmp.Previous == null)
                    {
                        return -1;
                    }
                    tmp = tmp.Previous;
                }
            }
            return tmp.Value;
        }
        #endregion

        //12. первый индекс по значению//вернуть первый индекс с заданным элементом
        #region
        public int GetIndexByValue(int value)
        {
            int index = 0;
            DNode tmp;
            bool isIndexLeft = index < Length / 2;

            if (_root == null && _tail == null)
            {
                throw new NullReferenceException("List is empty");
            }
            if (isIndexLeft)
            {
                tmp = _root;
                while (tmp != null)
                {
                    if (tmp.Value == value)
                    {
                        return index;
                    }
                    else
                    {
                        index++;
                        tmp = tmp.Next;
                    }
                }
            }
            else
            {
                tmp = _tail;
                index = Length - 1;
                while (tmp != null)
                {
                    if (tmp.Value == value)
                    {
                        return index;
                    }
                    else
                    {
                        index--;
                        tmp = tmp.Previous;
                    }
                }
            }
            return -1;
        }
        #endregion

        //13. изменение по индексу//вводим индекс и меняем значение
        public void ChangeValueByIndex(int index, int value)
        {
            DNode tmp = new DNode(value);
            if (_root == null && _tail == null)
            {
                throw new NullReferenceException("List is empty");
            }

            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                bool isIndexLeft = index < Length / 2;
                if (isIndexLeft)
                {
                    tmp = _root;
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    tmp.Value = value;
                }
                else
                {
                    tmp = _tail;
                    for (int i = Length - 1; i > index; i--)
                    {
                        tmp = tmp.Previous;
                    }
                    tmp.Value = value;
                }
            }
        }

        //14. реверс(123 -> 321)
        #region Reverse
        public void Reverse()
        {
            if (_tail == null)
            {
                throw new NullReferenceException("List is empty");
            }
            _root = _tail;
            int count = 0;
            while (_root != null)
            {
                count++;
                _root = _root.Previous;
            }
        
        }
        #endregion

        ////15. поиск значения максимального элемента
        //#region GetMaximumElement
        //public int GetMaximumElement()
        //{
            
        //}
        //#endregion

        ////16. поиск значения минимального элемента
        //#region GetMinimumElement
        //public int GetMinimumElement()
        //{
          
        //}
        //#endregion

        ////17. поиск индекс максимального элемента
        //#region
        //public int GetIndexOfMax()//5 2 6 9 6 5 7//3
        //{
           
        //}
        //#endregion

        ////18. поиск индекс минимального элемента
        //#region
        //public int GetIndexOfMin()
        //{
            
        //}
        //#endregion

        ////19. сортировка по возрастанию !
        //#region
        //public void GetSortAscerding()
        //{
        //    //пузырьком
        //}
        //#endregion

        ////20. сортировка по убыванию !
        //#region
        //public void GetSortDescending()
        //{
        //    //пузырьком
        //}
        //#endregion

        ////21. удаление по значению первого(?вернуть индекс)
        //#region RemoveFirstByValue
        //public int RemoveFirstByValue(int value)
        //{
         
        //}
        //#endregion

        ////22. удаление по значению всех(?вернуть кол-во)
        //#region RemoveAllValue
        //public int RemoveAllValue(int value)
        //{
           
        //}
        //#endregion

        ////23. 3 конструктора(пустой, на основе одного элемента, на основе массива )
        ////24. добавление списка(вашего самодельного) в конец
        //#region
        //public void Add(LinkedList list)
        //{

        //}
        //#endregion

        ////25. добавление списка в начало
        //#region
        //public void AddFirst(LinkedList list)
        //{

        //}
        //#endregion

        ////26. добавление списка по индексу
        //#region
        //public void AddByIndex(LinkedList list, int index)
        //{

        //}
        //#endregion

        #region Equals
        public override bool Equals(object obj)
        {
            DoublyLinkedList myNode = (DoublyLinkedList)obj;
            DNode tmp1;
            DNode tmp2;

            tmp1 = _root;
            tmp2 = myNode._root;
            if (tmp1 == null && tmp2 == null)
            {
                return true;
            }
            while (tmp2 != null && tmp1 != null)
            {
                if ((tmp1.Next == null && tmp2.Next != null)
                || (tmp1.Next != null && tmp2.Next == null))
                {
                    return false;
                }
                if (tmp2.Value != tmp1.Value)
                {
                    return false;
                }
                tmp2 = tmp2.Next;
                tmp1 = tmp1.Next;
            }
            return true;
        }
        #endregion

        public override string ToString()
        {
            string s = "";
            if (_root == null)
                return s;
            DNode myNode = _root;
            while (myNode != null)
            {
                s += myNode.Value + " ";
                myNode = myNode.Next;
            }
            return s;
        }

        #region GetHashCode
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region WriteToConsole
        public void WriteToConsole() //для консоли
        {
            DNode current = _root;
            while (current.Next != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
            Console.Write($"{current.Value} ");
        }
        #endregion
    }
}
