using Homwork23_a.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homwork23_a.Model
{
    class ConvertStringToDigit : IConvertStringToNumbers
    {
        /// <summary>
        /// Свойство строки, содержащей число
        /// </summary>
        public string StringToNumber { get; set; }

        /// <summary>
        /// Результат обработки строки
        /// </summary>
        public double Result { get; set; }

        /// <summary>
        /// Конструктор, приниммающий строку для ее обработки
        /// </summary>
        /// <param name="stringNumber"></param>
        public ConvertStringToDigit(string stringNumber)
        {
            StringToNumber = stringNumber;
        }

        /// <summary>
        /// Метод обрабатывает строку и, при удачной обработке возвращает булевое значение
        /// </summary>
        /// <returns></returns>
        public bool CheckString()
        {
            // Переменная вывода числа
            double result;

            // Обработка входящей строки
            if (double.TryParse(StringToNumber, out result))
            {
                // Присваивание результата входящей строки
                Result = result;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
