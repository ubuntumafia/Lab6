using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public interface IFractionOperations
    {
        double GetDecimalValue(); // Получение вещественного значения
        void SetNumerator(int numerator); // Установка числителя
        void SetDenominator(int denominator); // Установка знаменателя
    }
}
