using System;
using System.Collections;
using лаба11;
using DifferentMenus;

namespace лаба12
{
    public class MyQueueWork
    {
        private MyQueue<IPerson> queue;

        public MyQueueWork()
        {

        }

        private MyQueueWork(MyQueue<IPerson> queue)
        {
            this.queue = queue;
        }

        private void Continue()
        {
            Console.WriteLine("\n\n\nДля продолжения нажать любую клавишу...");
            Console.ReadKey(true);
        }

        #region Create
        //Создать очередь
        private int Create()
        {
            int k = 9;
            string[] createMenu = {
                "Создать очередь с фиксированным объемом (заполнится автоматически)",
                "Создать очередь с заданным объемом (заполнится автоматически)",
                "Создать очередь (скопировать из существующей)", "Назад"
            };
            while (true)
            {
                int sw = Use.Menu(0, "Выберите действие:", createMenu);
                switch (sw)
                {
                    case 1:
                        CreateFixCapacity();
                        return 0;
                    case 2:
                        CreateFromCapacity();
                        return 0;
                    case 3:
                        CreateFromReady();
                        return 0;
                    case 4:
                        return k;
                }
            }
        }

        //Создать очередь из фиксированной Capacity
        private void CreateFixCapacity()
        {
            queue = new MyQueue<IPerson>();
            IPerson[] array = IPersonCreate.CreateArray(queue.Capacity * 2);
            foreach (IPerson arrayElement in array)
            {
                queue.Enqueue(arrayElement);
            }
        }

        //Создать очередь из готовой
        private void CreateFromReady()
        {
            MyQueue<IPerson> tmpQueue = new MyQueue<IPerson>();
            IPerson[] add = IPersonCreate.CreateArray(10);
            foreach (IPerson addElement in add)
            {
                tmpQueue.Enqueue(addElement);
            }
            queue = new MyQueue<IPerson>(tmpQueue);
        }

        //Создать очередь из заданной Capacity
        private void CreateFromCapacity()
        {
            queue = new MyQueue<IPerson>(Input("Введите объем очереди: "));
            IPerson[] array = IPersonCreate.CreateArray(queue.Capacity * 2);
            foreach (IPerson arrayElement in array)
            {
                queue.Enqueue(arrayElement);
            }
        }

        //Ввод int
        private int Input(string str)
        {
            bool ok = true;
            int digit = 0;
            while (ok)
            {
                Console.Write(str);
                ok = Int32.TryParse(Console.ReadLine(), out digit);
                if (!ok)
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод...");
                    ok = true;
                }
                else
                {
                    ok = false;
                }
            }

            return digit;
        }
        #endregion

        #region Output
        //Вывод коллекции
        private void Output()
        {
            foreach (IPerson element in queue)
            {
                element.Show();
            }
        }

        //Вывод текущей очереди
        private void CurrentQueue()
        {
            Console.WriteLine("Текущая очередь: ");
            Output();
        }

        //Вывод массива
        private static void Output(IPerson[] array)
        {
            foreach (IPerson element in array)
            {
                element.Show();
            }
        }
        #endregion

        public void Start()
        {
            string[] mainMenu = {
                "Создать очередь", "Проверка свойств коллекции.", "Проверка метода Contains", "Проверка метода Clear",
                "Проверка метода Dequeue", "Проверка метода Enqueue","Проверка метода Peek","Проверка метода ToArray",
                "Проверка метода Clone","Проверка метода CopyTo","Выход"
            };
            int k = 9;
            while (true)
            {
                int sw = Use.Menu(k, "Выберите действие:", mainMenu);
                switch (sw)
                {
                    case 1:
                        k = Create();
                        break;
                    case 2:
                        CurrentQueue();
                        Console.WriteLine("\nОбъем коллекции: {0}", queue.Capacity);
                        Console.WriteLine("\nКол-во элементов в последовательности: {0}", queue.Count);
                        Continue();
                        break;
                    case 3:
                        CurrentQueue();
                        IPerson person1 = new Worker("Никич", "Семёнов", 48, 15000);
                        IPerson person2 = queue.Peek();
                        Console.WriteLine("\nЧеловек " + person1.Return_se_name() + " " + person1.Return_name() + " содержиться ли в очереди?\n{0}", queue.Contains(person1));
                        Console.WriteLine("\nЧеловек " + person2.Return_se_name() + " " + person2.Return_name() + " содержиться ли в очереди?\n{0}", queue.Contains(person2));
                        Continue();
                        break;
                    case 4:
                        CurrentQueue();
                        queue.Clear();
                        Console.WriteLine("Очередь очищена...");
                        k = 0;
                        Continue();
                        break;
                    case 5:
                        CurrentQueue();
                        IPerson person = queue.Dequeue();
                        Console.WriteLine("\nВывели человека: ");
                        person.Show();
                        Console.WriteLine("\nОчередь после изменения: ");
                        CurrentQueue();
                        Continue();
                        break;
                    case 6:
                        CurrentQueue();
                        IPerson add = IPersonCreate.CreateElement<Engineer>();
                        Console.WriteLine("\nДобавим в конец списка: ");
                        add.Show();
                        queue.Enqueue(add);
                        Console.WriteLine("\nОчередь после изменения: ");
                        CurrentQueue();
                        Continue();
                        break;
                    case 7:
                        CurrentQueue();
                        person = queue.Peek();
                        Console.WriteLine("\nВывели человека: ");
                        person.Show();
                        Console.WriteLine("\nОчередь не изменена: ");
                        CurrentQueue();
                        Continue();
                        break;
                    case 8:
                        CurrentQueue();
                        IPerson[] array = queue.ToArray();
                        Console.WriteLine("Вывод массива: ");
                        Output(array);
                        Continue();
                        break;
                    case 9:
                        CurrentQueue();
                        MyQueue<IPerson> clone = new MyQueue<IPerson>(queue);
                        Console.WriteLine("Вывод копии: ");
                        MyQueueWork cloneMyQueueWork = new MyQueueWork(clone);
                        cloneMyQueueWork.Output();
                        break;
                    case 10:
                        CurrentQueue();
                        queue.CopyTo(out array, queue.Count / 2);
                        Console.WriteLine("Вывод массива: ");
                        Output(array);
                        Continue();
                        break;
                    case 11:
                        return;
                }
            }
        }
    }
}
