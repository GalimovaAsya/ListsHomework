using System;

namespace Lists
{

    public class LinkedList
    {
        private Node _root;

        public LinkedList()
        {
            _root = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
        }

        public LinkedList(int[] array)
        {
            for (int i = 0; i < array.Length; i++)// 1 2 3 4
            {
                    Node tmp = _root;// корень теперь ровняется 1
                if (_root != null)
                {
                    while (tmp.Next != null)//тепрь есть ли у головы сслыка?
                    {
                        tmp = tmp.Next;
                    }
                        tmp.Next = new Node(array[i]);
                }
                else
                {
                    _root = new Node(array[i]);
                }
            }
            //exception empty array?

        }


        //1. добавление значения в конец
        #region Add
        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
            }
            else
            {
                Node tmp = _root;// корень теперь ровняется 1
                while (tmp.Next != null)//тепрь есть ли у головы сслыка?
                {
                    tmp = tmp.Next;
                }
                tmp.Next = new Node(value);
            }
        }
        #endregion

        //2. добавление значения в начало
        #region AddFirst
        public void AddFirst(int value)
        {
            Node tmp = new Node(value);
            if (_root == null)//линк лист содержит в себе голову?
            {
                _root = tmp;// голова это нода
            }
            else
            {
                tmp.Next = _root;//тпм ссылается на голову(они были по отдельности )
                _root = tmp;// голова - тмп
            }
        }
        #endregion

        //3. добавление значения по индексу
        #region AddByIndex
        public void AddByIndex(int value, int index)//1 2 3 9 4 5 6
        {
            Node tmp = _root;
            if (index == 0)
            {
                AddFirst(value);
            }

            if (_root == null)
            {
                _root = tmp; //туфтология
            }
            else
            {
                int position = 0;

                while (tmp.Next != null && index > 0)
                {
                    //Console.WriteLine($"current_position: {position}, current_tmp_value:{tmp.Value}, index: {index}");//условный дебаг
                    position = position + 1 ;

                    if (position == index)//tmp на конкретном индексе
                    {
                        Node tmp2=new Node(value);//новая летучая нода у которой значение из вне
                        tmp2.Next = tmp.Next;//у летучей ноды ссылка теперь будет на элемент на который ссылался тмп
                        tmp.Next = tmp2;//тпм ссылается на новую ноду которая ссылается тмп
                        
                    }

                    tmp = tmp.Next;//переходим к следующему элементу после проверки ифа, иначе позиция будет ссылаться всегда на следующий элемент внутри ифа
                }

                if ((_root.Next != null && index < 0) ||
                    (position < index))
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
        }
        #endregion

        //4. удаление из конца одного элемента
        #region RemoveLast
        public void RemoveLast()
        {
            Node tmp = _root;
            if (_root == null)
            {
                throw new NullReferenceException("List is empty");
            }
            else if (_root.Next == null)//прочесть
            {
                _root = null;
            }
            else 
            {
                while (tmp.Next.Next != null)
                {
                    tmp = tmp.Next;
                }
                
                tmp.Next = null;
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
            else if (_root.Next == null)//прочесть
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
            Node tmp = _root;

            if (_root == null)
            {
                throw new NullReferenceException("List is empty");
            }
            else if (index == 0 && _root.Next == null)
            {
                _root = _root.Next;
            }

            if (index == 0 && _root.Next != null)
            {
                _root = _root.Next;
            }

            if (index < 0 || (index != 0 && _root.Next==null))
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }


            for (int i = 0; i < index - 1; i++)
            {
                //Console.WriteLine($"current_index: {index}, tmp: {tmp}");
                tmp = tmp.Next;
            }
            tmp.Next = tmp.Next.Next;

        }
        #endregion

        //7. удаление из конца N элементов
        #region RemoveLastNTimes
        public void RemoveLastNTimes(int n)
        {
            Node tmp = _root.Next;
            for (int i = 0; i < n; i++)
            {
                RemoveLast();
            }

            //понять до куда добежать, добежать до нужного места, отсюда некст равен нал
        }
        #endregion

        //8. удаление из начала N элементов
        #region RemoveFirstNTimes
        public void RemoveFirstNTimes(int n)
        {
            Node tmp = _root.Next;
            for (int i = 0; i < n; i++)
            {
                RemoveFirst();
            }
        }
        //добежать до нужного и рут=новый
        #endregion

        //9. удаление по индексу N элементов
        #region RemoveByIndexNTimes
        public void RemoveByIndexNTimes(int index, int n)
        {
            Node tmp = _root;

            for (int i = 0; i < n; i++)
            {
                RemoveByIndex(index);
            }
        }
        #endregion

        //10. вернуть длину
        #region GetLength
        public int GetLength()
        {
            int length = 0;
            Node tmp = _root;
            while (tmp != null)
            {
                length++;
                tmp = tmp.Next;
            }

            if (_root == null)
            {
                throw new NullReferenceException("List is empty");
            }
            return length;
        }
        #endregion

        //11. доступ по индексу// вводим индекс вывести элемент
        #region GetValueByIndex
        public int GetValueByIndex(int index)// 1 2 3 4 5 6 7// 2 index
        {
            Node tmp = _root;
            for (int i = 0; i < index; i++)
            {
                if (tmp.Next == null)//на случай если индекс больше количества элементов
                {
                    return -1;
                }
                tmp = tmp.Next;//на выходе из цикла останется тройка из-за назначения _root.next
            }

            if (_root.Next == null && index != 0 || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if (_root == null)
            {
                throw new NullReferenceException("List is empty");
            }

            return tmp.Value;
        }
        #endregion

        //12. первый индекс по значению//вернуть первый индекс с заданным элементом
        #region
        public int GetIndexByValue(int value) //1 2 3 4 5 6 7 -> 
        {
            Node tmp = _root;
            int index = 0;
            while (tmp.Next != null)
            {
                if (tmp.Value == value)
                {
                    return index;
                }
                else
                {
                    index = index + 1;
                    tmp = tmp.Next;
                }
            }
            if (tmp == null)
            {
                throw new NullReferenceException("List is empty");
            }
            //return -1;
            return index;
        }
        #endregion
        //13. изменение по индексу//вводим индекс и меняем значение
        public void ChangeValueByIndex(int index, int value)//1 2 3 4 5 6 7//index 2
        {
            Node tmp = _root;
            for (int i = 0; i < index; i++)
            {
                if (tmp == null)
                {
                    throw new NullReferenceException("List is empty");
                }
                tmp = tmp.Next;
            }
            tmp.Value = value;

        }

        //14. реверс(123 -> 321)
        #region Reverse
        public void Reverse()
        {
            Node oldRoot = _root;
            Node current;
            while (oldRoot.Next != null)
            {
                current = oldRoot.Next;
                oldRoot.Next = current.Next;
                current.Next = _root;
                _root = current;
            }

            if (_root == null)
            {
                throw new NullReferenceException("List is empty");
            }
        }
        #endregion

        //15. поиск значения максимального элемента
        #region GetMaximumElement
        public int GetMaximumElement()
        {
            Node tmp = _root;
            int max = tmp.Value;
            if (_root == null)
            {
                throw new NullReferenceException("List is empty");
            }
            else
            {
                while (tmp != null)
                {
                    if (tmp.Value > max)
                    {
                        max = tmp.Value;
                    }
                    else
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            return max;
        }
        #endregion

        //16. поиск значения минимального элемента
        #region GetMinimumElement
        public int GetMinimumElement()
        {
            Node tmp = _root;
            int min = tmp.Value;
            if (_root == null)
            {
                throw new NullReferenceException("List is empty");
            }
            else
            {
                while (tmp != null)
                {
                    if (tmp.Value < min)
                    {
                        min = tmp.Value;
                    }
                    else
                    {
                        tmp = tmp.Next;
                    }
                }
            }
            return min;
        }
        #endregion

        //17. поиск индекс максимального элемента
        #region
        public int GetIndexOfMax()
        {
            Node tmp = _root;
            int max = tmp.Value;
            int index = 0;
            if (tmp == null)
            {
                throw new NullReferenceException("List is empty");
            }
            else
            {
                while (tmp != null)
                {
                    if (tmp.Value > max)
                    {
                        max = tmp.Value;
                        index = index + 1;
                    }
                        tmp = tmp.Next;
                }
            }
            return index;
        }
        #endregion

        //18. поиск индекс минимального элемента
        #region
        public int GetIndexOfMin()
        {
            Node tmp = _root;
            int min = tmp.Value;
            int index = 0;
            if (tmp == null)
            {
                throw new NullReferenceException("List is empty");
            }
            else
            {
                while (tmp != null)
                {
                    if (tmp.Value < min)
                    {
                        min = tmp.Value;
                        index = index + 1;
                    }
                    tmp = tmp.Next;
                }
            }
            return index;
        }
        #endregion

        //19. сортировка по возрастанию
        #region
        public void GetSortAscerding()
        {
            //пузырьком
        }
        #endregion

        //20. сортировка по убыванию
        #region
        public void GetSortDescending()
        {
            //пузырьком
        }
        #endregion

        //21. удаление по значению первого(?вернуть индекс)
        #region RemoveFirstByValue
        public int RemoveFirstByValue(int value) 
        {
            Node tmp = _root;
            Node tmp2 = tmp;
            int index = 0;
            if (tmp == null)
            {
                throw new NullReferenceException("List is empty");
            }

            while (tmp.Next != null)
            {
                if (tmp.Value == value)
                {
                    tmp2.Next = tmp.Next;
                    tmp2 = tmp2.Next;
                    return index;
                }
                else
                {
                    index = index + 1;
                }
                tmp = tmp.Next;
            }
            return -1;
        }
        #endregion

        //22. удаление по значению всех(?вернуть кол-во)
        #region RemoveAllValue
        public int RemoveAllValue(int value)
        {
            Node tmp = _root;
            Node newRoot = new Node(tmp.Value);
            Node head = newRoot; 

            int count = 0;
                _root = _root.Next;
            while (_root != null)
            {
                if (_root.Value != value)
                {
                    newRoot.Next = new Node(_root.Value);
                    newRoot = newRoot.Next;
                }
                else
                {
                    count++;
                }
                _root = _root.Next;
            }
            _root = head;
            if (_root.Value == value)
            {
                _root = _root.Next;
                count++;
            }
            if (count > 0)
            {
                return count;
            }
            return -1;
            
        }
        #endregion

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
        public void WriteToConsole()
        {
            Node current = _root;
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

            //LinkedList myNode = (LinkedList)obj;

            //while (myNode._root.Next != null)
            //{
            //    if (_root.Next == null && myNode._root.Next != null)
            //    {
            //        return false;
            //    }
            //    if (_root.Next != null && myNode._root.Next == null)
            //    {
            //        return false;
            //    }
            //    if (myNode._root.Value != _root.Value)
            //    {
            //        return false;
            //    }
            //    myNode._root = myNode._root.Next;
            //    _root = _root.Next;
            //}
            //return true;
            LinkedList myNode = (LinkedList)obj;
            Node tmp1;
            Node tmp2;

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
            Node myNode = _root;
            while (myNode != null)
            {
                s += myNode.Value + " ";
                myNode = myNode.Next;
            }
            return s;
        }
        //add first с разными значениями

        #region GetHashCode
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
