using System;
using System.Collections.Generic;
using лаба11;
using DifferentMenus;
using FuncThat;

namespace лаба12
{
    class StackWork
    {
        private Stack<IPerson> _stack;

        public StackWork()
        {

        }

        public StackWork(Stack<IPerson> stack)
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

            _stack = new Stack<IPerson>(size);
            var array = IPersonCreate.CreateArray(size);
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
                var sw = Use.Menu(0, "Меню для добавления элемента", addMenu);
                IPerson person;
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

        #region DeleteElement

        //Удалить объект
        private void Delete(out int k)
        {
            string[] addMenu =
                {"Удалить рабочего", "Удалить инженера", "Удалить администратора", "Назад"};
            k = 0;
            while (true)
            {
                var sw = Use.Menu(0, "Выберите действие:", addMenu);
                IPerson person;
                switch (sw)
                {
                    case 1:
                        Console.WriteLine("Введите рабочего для удаления:");
                        person = new Worker();
                        person.Input();

                        var tmp = _stack.ToArray();
                        var preSize = tmp.Length;
                        RemoveFromArray(ref tmp, person);
                        CreateStack(tmp);
                        if (preSize == tmp.Length)
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в стэке.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_stack.Count == 0)
                        {
                            k = 6;
                            return;
                        }

                        break;
                    case 2:
                        Console.WriteLine("Введите инженера для удаления:");
                        person = new Engineer();
                        person.Input();
                        tmp = _stack.ToArray();
                        preSize = tmp.Length;
                        RemoveFromArray(ref tmp, person);
                        CreateStack(tmp);
                        if (preSize == tmp.Length)
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в стэке.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_stack.Count == 0)
                        {
                            k = 6;
                            return;
                        }

                        break;
                    case 3:
                        Console.WriteLine("Введите администратора для удаления:");
                        person = new Administration();
                        person.Input();
                        tmp = _stack.ToArray();
                        preSize = tmp.Length;
                        RemoveFromArray(ref tmp, person);
                        CreateStack(tmp);
                        if (preSize == tmp.Length)
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в стэке.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_stack.Count == 0)
                        {
                            k = 6;
                            return;
                        }

                        break;
                    case 4:
                        return;
                }
            }
        }

        //Удаление из массива IPerson[]
        private static void RemoveFromArray(ref IPerson[] array, IPerson element)
        {
            bool ok = false;
            for (var i = 0; i < array.Length - 1; i++)
                if (array[i].CompareTo(element) == 0)
                {
                    ok = true;
                    Easy.Swap(ref array[i], ref array[i + 1]);
                }
            if (ok)
                Array.Resize(ref array, array.Length - 1);
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

        #region Queries

        //Меню
        private void TypeQueries()
        {
            string[] queriesMenu =
                {"Запросы к типу Worker", "Запросы к типу Engineer", "Запросы к типу Administration", "Назад"};
            while (true)
            {
                var sw = Use.Menu(0, "Выберите нужный пункт:", queriesMenu);
                switch (sw)
                {
                    case 1:
                        Queries<Worker>();
                        break;
                    case 2:
                        Queries<Engineer>();
                        break;
                    case 3:
                        Queries<Administration>();
                        break;
                    case 4:
                        return;
                }
            }
        }

        //Запросы
        private void Queries<T>()
        {
            string[] queriesMenu = { "Кол-во объектов.", "Печать объектов.", "Перегенерировать объекты", "Назад." };
            while (true)
            {
                var sw = Use.Menu(0, "Выберите нужную опцию:", queriesMenu);
                switch (sw)
                {
                    case 1:
                        var count = 0;
                        foreach (var person in _stack)
                            try
                            {
                                var element = (T)person;
                                count++;
                            }
                            catch
                            {
                                // ignored
                            }

                        Console.
                            WriteLine("Кол-во объектов выбранного типа = {0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                      count);
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.WriteLine("Объекты выбранного типа: ");
                        foreach (var person in _stack)
                            try
                            {
                                var element = (T)person;
                                IPersonCreate.Show(element);
                            }
                            catch
                            {
                                // ignored
                            }

                        Console.WriteLine("\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        count = 0;
                        var array = _stack.ToArray();
                        foreach (var person in _stack)
                            try
                            {
                                var element = (T)person;
                                RemoveFromArray(ref array, (IPerson)element);
                                count++;
                            }
                            catch
                            {
                                // ignored
                            }

                        CreateStack(array);
                        for (var i = 0; i < count; i++) _stack.Push(IPersonCreate.CreateElement<T>());
                        Console.
                            WriteLine("Объекты выбранного типы были перезаписаны.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 4:
                        return;
                }
            }
        }

        #endregion

        #region Clone

        //Клон
        private void Clone()
        {
            Console.WriteLine("Исходный стэк: ");
            Output();
            Console.WriteLine("\n\n\nСклонированный стэк: ");
            var clone = new StackWork(CloneStack());
            clone.Output();
        }

        //Клон
        private Stack<IPerson> CloneStack()
        {
            var newStack = new Stack<IPerson>(_stack.Count);
            foreach (var element in _stack) newStack.Push(element);

            return newStack;
        }

        #endregion

        #region Find

        //Тип поиска
        private void TypeFind()
        {
            string[] queriesMenu =
                {"Поиск элемента типа Worker", "Поиск элемента типа Engineer", "Поиск элемента типа Administration", "Назад"};
            while (true)
            {
                var sw = Use.Menu(0, "Выберите нужную опцию:", queriesMenu);
                switch (sw)
                {
                    case 1:
                        var worker = new Worker();
                        worker.Input();
                        var number = Find(worker);
                        if (number == 0)
                            Console.
                                WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");
                        else
                            Console.
                                WriteLine("Номер объекта в отсортированном массиве - {0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          number);
                        Console.ReadKey(true);
                        break;
                    case 2:
                        var engineer = new Engineer();
                        engineer.Input();
                        number = Find(engineer);
                        if (number == 0)
                            Console.
                                WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");
                        else
                            Console.
                                WriteLine("Номер объекта в отсортированном массиве - {0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          number);
                        Console.ReadKey(true);
                        break;
                    case 3:
                        var administration = new Administration();
                        administration.Input();
                        number = Find(administration);
                        if (number == 0)
                            Console.
                                WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");
                        else
                            Console.
                                WriteLine("Номер объекта в отсортированном массиве - {0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          number);
                        Console.ReadKey(true);
                        break;
                    case 4:
                        return;
                }
            }
        }

        //Поиск объекта
        private int Find(IPerson element)
        {
            var array = _stack.ToArray();
            return Array.BinarySearch(array, element) + 1;
        }

        #endregion

        //Вывод
        public void Output()
        {
            foreach (var element in _stack) element.Show();

            Console.WriteLine("\n\n\nДля продолженния нажать на любую клавишу...");
            Console.ReadKey(true);
        }

        //Стартовое меню
        public void Start()
        {
            string[] stackMenu = {
                "Создать коллекцию", "Добавить элемент", "Удалить элемент", "Выполнение запросов",
                "Клонирование коллекции", "Сортировка коллекции и поиск элемента",
                "Вывод коллекции с использованием foreach)", "Назад"
            };
            var k = 6;
            while (true)
            {
                var sw = Use.Menu(k, "Выберите действие:", stackMenu);
                switch (sw)
                {
                    case 1:
                        CreateStack();
                        k = 0;
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Delete(out k);
                        break;
                    case 4:
                        TypeQueries();
                        break;
                    case 5:
                        Clone();
                        break;
                    case 6:
                        Sort();
                        TypeFind();
                        break;
                    case 7:
                        Output();
                        break;
                    case 8:
                        return;
                }
            }
        }

    }
}
