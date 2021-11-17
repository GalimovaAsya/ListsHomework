using System;
namespace Lists
{
    public class DoublyLinkedList
    {
        public int Length { get; set; }
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
                    _tail.Next.Privious = _tail;
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
                _tail.Next.Privious = _tail;//и новая нода ссылается на хвост - замыкающая ссылка назад
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
            if (_root == null)
            {
                _root = tmp;
            }
            else
            {
                tmp.Next = _root;
                _root = tmp;
            }
        }
        #endregion

        //3. добавление значения по индексу
        #region AddByIndex
        public void AddByIndex(int value, int index)//1 2 3 9 4 5 6
        {
            bool isIndexLeft = index <= Length / 2;//к чему ближе находится элемент? к концу или началу?
            DNode crnt;
            int numberOfSteps;
            if (index < 0 || index > 0)
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
            for (int i = 1; i <= numberOfSteps; i++)
            {

            }

            //3 варианта
            //_рут=_тейл;
            //два элемента

            //if (index < 0 || index > 0)
            //{
            //    throw new IndexOutOfRangeException();
            //}


            //for (int i = 1; i <= numberOfSteps; i++)
            //{
            //    crnt = isIndexLeft ? crnt.Next : crnt.Privious;//условие до ? после будет вот это : иначе
            //}

            //if (crnt != _root && crnt != _tail)//если карент не равен нулю и
            //{
            //    crnt.Privious.Next = crnt.Next;//удаление ноды
            //    crnt.Next.Privious = crnt.Privious;//для случаев если нода не первая и не последняя
            //    Length--;
            //}
            //else if (crnt == _root && crnt == _tail)
            //{
            //    _root = null;
            //    _tail = null;
            //    Length = 0;
            //}
            //else if (crnt == _root)
            //{
            //    crnt.Next.Privious = null;//убиваем ссылку второго элемента на первый чтобы на него никто не ссылался
            //    _root = crnt.Next;
            //}
            //else
            //{
            //    crnt.Privious.Next = null;
            //    _tail = crnt.Privious;
            //}
            //Length--;
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
                _tail = _tail.Privious;
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
            if (index < 0 || index > Length)
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
                crnt=_tail;
                numberOfSteps = Length - index; //- index;
            }

            for (int i = 1; i < numberOfSteps; i++)
            {
                crnt = isIndexLeft ? crnt.Next:crnt.Privious;//условие до ? после будет вот это : иначе
            }

            if (crnt != _root && crnt != _tail)//если карент не равен нулю и
            {
                crnt.Privious.Next = crnt.Next;//удаление ноды
                crnt.Next.Privious = crnt.Privious;//для случаев если нода не первая и не последняя
                Length--;
            }
            else if (crnt == _root && crnt == _tail)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else if (crnt == _root)
            {
                crnt.Next.Privious = null;//убиваем ссылку второго элемента на первый чтобы на него никто не ссылался
                _root = crnt.Next;
            }
            else
            {
                crnt.Privious.Next = null;
                _tail = crnt.Privious;
            }
            Length--;
        }
        #endregion

        //7. удаление из конца N элементов
        #region RemoveLastNTimes
        public void RemoveLastNTimes(int n)
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
                for (int i = n; n != 0; n--)
                {
                    _tail = _tail.Privious;
                    _tail.Next = null;
                    Length--;
                }
            }
        }
        #endregion

        //8. удаление из начала N элементов
        #region RemoveFirstNTimes
        public void RemoveFirstNTimes(int n)
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
                for (int i = n; n != 0; n--)
                {
                    _root = null;
                }
            }
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

        ////11. доступ по индексу// вводим индекс вывести элемент
        //#region GetValueByIndex
        //public int GetValueByIndex(int index)// 1 2 3 4 5 6 7// 2 index
        //{
           
        //}
        //#endregion

        ////12. первый индекс по значению//вернуть первый индекс с заданным элементом
        //#region
        //public int GetIndexByValue(int value) //1 2 3 4 5 6 7 -> 
        //{
           
        //}
        //#endregion

        //13. изменение по индексу//вводим индекс и меняем значение
        public void ChangeValueByIndex(int index, int value)//1 2 3 4 5 6 7//index 2
        {
           
        }

        //14. реверс(123 -> 321)
        #region Reverse
        public void Reverse()
        {
        
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

        //19. сортировка по возрастанию !
        #region
        public void GetSortAscerding()
        {
            //пузырьком
        }
        #endregion

        //20. сортировка по убыванию !
        #region
        public void GetSortDescending()
        {
            //пузырьком
        }
        #endregion

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

        //23. 3 конструктора(пустой, на основе одного элемента, на основе массива )
        //24. добавление списка(вашего самодельного) в конец
        #region
        public void Add(LinkedList list)
        {

        }
        #endregion

        //25. добавление списка в начало
        #region
        public void AddFirst(LinkedList list)
        {

        }
        #endregion

        //26. добавление списка по индексу
        #region
        public void AddByIndex(LinkedList list, int index)
        {

        }
        #endregion


        #region WriteToConsole
        public void WriteToConsole() //для консоли
        {
            DNode current = _root;
            while (current.Next != null)
            {
                // Node (value:5, next: null)
                Console.Write($"{current.Value} ");
                current = current.Next;
                //if (current.Next != null)
                //{
                //}
            }
            Console.Write($"{current.Value} ");
        }
        #endregion

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
    }
}
