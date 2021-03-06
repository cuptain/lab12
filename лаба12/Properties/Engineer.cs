﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncThat;

namespace лаба11
{
    class Engineer : Worker, IPerson, IComparable
    {
        protected int factory;

        //Получение завода
        public int GetFactory
        {
            get { return factory; }
            protected set { factory = value; }
        }

        //Конструктор без параметров
        public Engineer():base()
        {
            factory = 0;
        }

        //Конструктор с параметрами
        public Engineer(string Name, string Surname, int Experience, int Salary, int Factory) 
            : base (Name, Surname, Experience, Salary)
        {
            factory = Factory;
        }

        //Вывод инженера
        public override void Show()
        {
            Console.WriteLine(surname + " " + name + "\nСтаж: " + experience + "\n" +
                              "Зарплата: " + salary + " тыс. руб." + "\nРаботает в цеху № " + factory + "\n");
        }

        //Ввод инженера
        public override void Input()
        {
            string[] input = null;

            string inputFI = Easy.EnterName("Введите Фамилию и Имя инженера, которого необходимо найти: ");

            Console.WriteLine("Введите стаж инженерп: ");
            int exp = Easy.ReadVGran(1, 5, "Стаж инженера");

            Console.WriteLine("Введите зарплату инженера: ");
            int money = Easy.ReadVGran(5000, 100000, "Зарплата инженера");

            Console.WriteLine("Введите цех, в котором работает инженер: ");
            int fac = Easy.ReadVGran(1, 100, "Рабочий цех");

            input = inputFI.Split(' ');

            name = input[1];
            surname = input[0];
            experience = exp;
            salary = money;
            factory = fac;
        }
    }
}
