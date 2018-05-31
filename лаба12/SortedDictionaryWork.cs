using System;
using System.Collections.Generic;
using лаба11;
using DifferentMenus;

namespace лаба12
{
    public class SortedDictionaryWork
    {
        private SortedDictionary<string, IPerson> _persons;

        public SortedDictionaryWork()
        {
        }

        private SortedDictionaryWork(SortedDictionary<string, IPerson> persons)
        {
            _persons = persons;
        }

        #region AddElement

        //Добавить объект
        private void Add()
        {
            string[] addMenu =
                {"Добавить рабочего", "Добавить инженера", "Добавить администратора", "Назад"};
            while (true)
            {
                var sw = Use.Menu(0, "Выберите действие:", addMenu);
                IPerson person;
                switch (sw)
                {
                    case 1:
                        Console.WriteLine("Введите рабочего для добавления:");
                        person = new Worker();
                        person.Input();
                        _persons.Add(person.Return_se_name() + " " + person.Return_name(), person);

                        Console.WriteLine("Объект успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.WriteLine("Введите инженера для добавления:");
                        person = new Engineer();
                        person.Input();
                        _persons.Add(person.Return_se_name() + " " + person.Return_name(), person);

                        Console.WriteLine("Объект успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.WriteLine("Введите администратора для добавления:");
                        person = new Administration();
                        person.Input();
                        _persons.Add(person.Return_se_name() + " " + person.Return_name(), person);

                        Console.WriteLine("Объект успешно добавлен.\n\n\nДля продолженния нажать на любую клавишу...");
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

                        if (!_persons.ContainsKey(person.Return_se_name() + " " + person.Return_name()))
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в словаре.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            _persons.Remove(person.Return_se_name() + " " + person.Return_name());
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_persons.Count == 0)
                        {
                            k = 6;
                            return;
                        }

                        break;
                    case 2:
                        Console.WriteLine("Введите инженера для удаления:");
                        person = new Engineer();
                        person.Input();
                        if (!_persons.ContainsKey(person.Return_se_name() + " " + person.Return_name()))
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в словаре.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            _persons.Remove(person.Return_se_name() + " " + person.Return_name());
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_persons.Count == 0)
                        {
                            k = 6;
                            return;
                        }

                        break;
                    case 3:
                        Console.WriteLine("Введите администратора для удаления:");
                        person = new Administration();
                        person.Input();
                        if (!_persons.ContainsKey(person.Return_se_name() + " " + person.Return_name()))
                        {
                            Console.
                                WriteLine("Объект для удаления отсутсвует в словаре.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            _persons.Remove(person.Return_se_name() + " " + person.Return_name());
                            Console.
                                WriteLine("Объект успешно удален.\n\n\nДля продолженния нажать на любую клавишу...");
                            Console.ReadKey(true);
                        }

                        if (_persons.Count == 0)
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
                        IPerson person = new Worker();
                        person.Input();
                        if (_persons.ContainsKey(person.Return_se_name() + " " + person.Return_name()))
                            Console.
                                WriteLine("Введенный элемент - {0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          _persons[person.Return_se_name() + " " + person.Return_name()]);
                        else
                            Console.
                                WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");

                        Console.ReadKey(true);
                        break;
                    case 2:
                        person = new Engineer();
                        person.Input();
                        if (_persons.ContainsKey(person.Return_se_name() + " " + person.Return_name()))
                            Console.
                                WriteLine("Введенный элемент - {0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          _persons[person.Return_se_name() + " " + person.Return_name()]);
                        else
                            Console.
                                WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");

                        Console.ReadKey(true);
                        break;
                    case 3:
                        person = new Administration();
                        person.Input();
                        if (_persons.ContainsKey(person.Return_se_name() + " " + person.Return_name()))
                            Console.
                                WriteLine("Введенный элемент - {0}.\n\n\nДля продолженния нажать на любую клавишу...",
                                          _persons[person.Return_se_name() + " " + person.Return_name()]);
                        else
                            Console.
                                WriteLine("Заданный объект не был найден в стэке.\n\n\nДля продолженния нажать на любую клавишу...");

                        Console.ReadKey(true);
                        break;
                    case 4:
                        return;
                }
            }
        }

        #endregion

        #region Output

        //Вывод
        public void Output()
        {
            foreach (var key in _persons.Keys) _persons[key].Show();

            Console.WriteLine("\n\n\nДля продолженния нажать на любую клавишу...");
            Console.ReadKey(true);
        }

        #endregion

        public void Start()
        {
            string[] stackMenu = {
                "Создать коллекцию", "Добавить элемент", "Удалить элемент", "Выполнение запросов",
                "Клонирование коллекции.", "Сортировка коллекции и поиск элемента",
                "Вывод коллекции, с использованием foreach", "Назад"
            };
            var k = 6;
            while (true)
            {
                var sw = Use.Menu(k, "Выберите действие:", stackMenu);
                switch (sw)
                {
                    case 1:
                        CreateDictionary();
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

        #region CreateDictionary

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
                    Console.WriteLine("Ошибка ввода! Повтире ввода...");
                    ok = true;
                }
                else
                {
                    ok = false;
                }
            }

            return digit;
        }

        //Создать коллекцию
        private void CreateDictionary()
        {
            _persons = new SortedDictionary<string, IPerson>(new ComparerForDictionary());
            int size;
            while (true)
            {
                size = Input("Введите размер коллекции: ");
                if (size == 0)
                    Console.WriteLine("Введена пустая коллекция. Повторите ввод...");
                else
                    break;
            }

            var array = IPersonCreate.CreateArray(size);
            foreach (var element in array) _persons.Add(element.Return_se_name() + " " + element.Return_name(), element);
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
                var sw = Use.Menu(0, "Выберите нужную опцию:", queriesMenu);
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
            string[] queriesMenu = { "Количество объектов", "Печать объектов", "Перегенерировать объекты", "Назад" };
            while (true)
            {
                var sw = Use.Menu(0, "Выберите нужный пункт:", queriesMenu);
                switch (sw)
                {
                    case 1:
                        var count = 0;
                        foreach (var key in _persons.Keys)
                            try
                            {
                                var element = (T)_persons[key];
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
                        foreach (var key in _persons.Keys)
                            try
                            {
                                var element = (T)_persons[key];
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
                        var tmp = new SortedDictionary<string, IPerson>(ClonaDictionary());
                        foreach (var key in tmp.Keys)
                            try
                            {
                                var element = (T)_persons[key];
                                _persons.Remove(key);
                                count++;
                            }
                            catch
                            {
                                // ignored
                            }

                        for (var i = 0; i < count; i++)
                        {
                            var add = IPersonCreate.CreateElement<T>();
                            _persons.Add(add.Return_se_name() + " " + add.Return_name(), add);
                        }

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
            Console.WriteLine("Исходный словарь: ");
            Output();
            Console.WriteLine("\n\n\nСклонированный стэк: ");
            var clone = new SortedDictionaryWork(ClonaDictionary());
            clone.Output();
        }

        //Клон
        private SortedDictionary<string, IPerson> ClonaDictionary()
        {
            var newDictionary = new SortedDictionary<string, IPerson>(new ComparerForDictionary());
            foreach (var keys in _persons.Keys) newDictionary.Add(keys, _persons[keys]);

            return newDictionary;
        }

        #endregion
    }

    internal class ComparerForDictionary : IComparer<string>
    {
        int IComparer<string>.Compare(string obj1, string obj2)
        {
            var person1 = obj1.Split(' ');
            var person2 = obj2.Split(' ');

            if (string.CompareOrdinal(person1[0], person2[0]) >= 1) return 1;

            if (string.CompareOrdinal(person1[0], person2[0]) <= -1) return -1;

            if (string.CompareOrdinal(person1[1], person2[1]) >= 1) return 1;

            if (string.CompareOrdinal(person1[1], person2[1]) <= -1) return -1;

            return 0;
        }
    }
}
