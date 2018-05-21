using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба11
{
    //Базовый интерфейс
    interface PersonInterface:IComparable
    {
        void Input(); //метод ввода

        void Show(); //метод вывода

        new int CompareTo(object other); //сравнение
    }
}
