using System;
using System.Collections.Generic;
using лаба11;
using DifferentMenus;

namespace лаба12
{
    class StackWork
    {
        private Stack<PersonInterface> _stack;

        public StackWork()
        {
        }

        public StackWork(Stack<PersonInterface> stack)
        {
            _stack = stack;
        }

        #region CreateStack

        //Ввод int
        private static int Input(string str)
        {
            var ok = true;
            var digit = 0;
            while (ok)
            {
                Console.Write(str);
                ok = int.TryParse(Console.ReadLine(), out digit);
                if (!ok)
                {
                    Console.WriteLine("Ошибка! Повторите ввод...");
                    ok = true;
                }
                else
                {
                    ok = false;
                }
            }

            return digit;
        }

        //Создать Stack
        private void CreateStack()
        {
            int size;
            while (true)
            {
                size = Input("Введите размер стэка: ");
                if (size <= 0)
                    Console.WriteLine("Введена пустая/отрицательная последовательность! Повторите ввод...");
                else
                    break;
            }

            _stack = new Stack<PersonInterface>(size);
            var array = CreateIPerson.CreateArray(size);
            for (var i = 0; i < size; i++) _stack.Push(array[i]);
        }

        //Создать Stack
        private void CreateStack(IPerson[] array)
        {
            _stack = new Stack<IPerson>(array.Length);
            foreach (var element in array)
                _stack.Push(element);
        }

        #endregion

        #region AddElement

        //Добавление элемента
        private void Add()
        {
            string[] addMenu =
                {"Добавить рабочего", "Добавить инженера", "Добавить администратора", "Назад"};
            while (true)
            {
                var sw = Use.Menu("Меню для добавления элемента", addMenu);
                PersonInterface person;
                switch (sw)
                {
                    case 1:
                        Console.WriteLine("Введите данные рабочего для добавления:");
                        person = new Worker();
                        person.Input();
                        _stack.Push(person);

                        Console.WriteLine("Объект успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.WriteLine("Введите данные инженера для добавления:");
                        person = new Engineer();
                        person.Input();
                        _stack.Push(person);

                        Console.WriteLine("Объект успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.WriteLine("Введите данные администратора для добавления:");
                        person = new Administration();
                        person.Input();
                        _stack.Push(person);

                        Console.WriteLine("Элемент успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 4:
                        return;
                }
            }
        }

        #endregion

        #region Sort

        //Сортировка стэка
        private void Sort()
        {
            var array = _stack.ToArray();
            Array.Sort(array);
            CreateStack(array);
            Console.WriteLine("Отсортированный стэк: ");
            Output();

            Console.WriteLine("\n\n\nДля продолженния нажать на любую клавишу...");
            Console.ReadKey(true);
        }

        #endregion
    }
}
