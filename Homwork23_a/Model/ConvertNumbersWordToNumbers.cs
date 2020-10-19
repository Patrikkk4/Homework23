using Homwork23_a.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Homwork23_a.Model
{
    class ConvertNumbersWordToNumbers : IConvertStringToNumbers
    {
        /// <summary>
        /// Словарь чисел
        /// </summary>
        public static Dictionary<string, int> Number = new Dictionary<string, int>()
        {
            ["ноль"] = 0,
            ["нуль"] = 0,
            ["один"] = 1,
            ["одна"] = 1,
            ["два"] = 2,
            ["две"] = 2,
            ["три"] = 3,
            ["четыре"] = 4,
            ["пять"] = 5,
            ["шесть"] = 6,
            ["семь"] = 7,
            ["восемь"] = 8,
            ["девять"] = 9,
            ["десять"] = 10,
            ["одиннадцать"] = 11,
            ["двенадцать"] = 12,
            ["тринадцать"] = 13,
            ["четырнадцать"] = 14,
            ["пятнадцать"] = 15,
            ["шестнадцать"] = 16,
            ["семнадцать"] = 17,
            ["восемнадцать"] = 18,
            ["девятнадцать"] = 19,
            ["двадцать"] = 20,
            ["тридцать"] = 30,
            ["сорок"] = 40,
            ["пятьдесят"] = 50,
            ["шестьдесят"] = 60,
            ["семьдесят"] = 70,
            ["восемьдесят"] = 80,
            ["девяносто"] = 90,
            ["сто"] = 100,
            ["двести"] = 200,
            ["триста"] = 300,
            ["четыреста"] = 400,
            ["пятьсот"] = 500,
            ["шестьсот"] = 600,
            ["семьсот"] = 700,
            ["восемьсот"] = 800,
            ["девятьсот"] = 900,
            ["тысяч"] = 0,
            ["тысячи"] = 0,
            ["тысяча"] = 0,
            ["миллион"] = 0,
            ["миллионов"] = 0,
            ["миллиона"] = 0
        };

        /// <summary>
        /// Поле временного числа
        /// </summary>
        private int tempNum;

        /// <summary>
        /// Временная коллекция
        /// </summary>
        static List<string> tempCol;

        /// <summary>
        /// Входящая строка
        /// </summary>
        public string StringToNumber { get; set; }

        /// <summary>
        /// Результат преобразования
        /// </summary>
        public double Result { get; set; }

        public ConvertNumbersWordToNumbers(string stringNumber)
        {
            StringToNumber = stringNumber;
        }

        /// <summary>
        /// Метод проверки входящей строки
        /// </summary>
        /// <returns></returns>
        public bool CheckString()
        {
            // Коллекция входящих слов
            List<string> input = new List<string>(StringToNumber.ToLower().Split(new char[] { ' ' }));

            // Возвращаемое значение корректности ввода
            bool check = true;

            // Цикл проверки ввода
            foreach (var s in input)
            {
                // Условия удалния пробелов для корректного отображения результата на основе текущего слова
                if (s.Length > 0)
                {
                    if (Number.Keys.Contains(s.Trim(' ')))
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;

                        break;
                    }
                }
            }

            // Запуск преобразования
            if(check) Millions(input);

            return check;
        }

        /// <summary>
        /// Метод выделяет из общей коллекции миллионы
        /// </summary>
        /// <param name="input"></param>
        public void Millions(List<string> input)
        {
            tempCol = new List<string>(input);

            int millions = 0;

            // Условие проверки наличия миллионов в коллекции слов входящей строки
            if (input.Contains("миллион") || input.Contains("миллионов") || input.Contains("миллиона"))
            {
                // Условие определения одного миллиона, если не указано количество миллионов
                if (input.FirstOrDefault() == "миллион") millions = 1000000;
                else
                {
                    // Цикл преобразования слов в числа
                    foreach (var i in tempCol)
                    {
                        // Вывод временного числа
                        Number.TryGetValue(i, out tempNum);

                        // Получение количества миллионов
                        millions = millions + tempNum;

                        // Удаление преобразованного слова
                        input.Remove(i);

                        // Удаление обозначение миллионов
                        if (i == "миллион" || i == "миллионов" || i == "миллиона")
                        {
                            input.Remove(i);

                            break;
                        }
                    }

                    // Получение числа миллионов
                    millions = millions * 1000000;
                }

                // Присваивание временной коллекции оставшегося количества слов в коллекции
                tempCol = input;
            }

            // Вызов метода преобразования тысяч
            Thousands(tempCol, millions);
        }

        /// <summary>
        /// Метод выделяет из общей коллекции тысячи
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        public void Thousands(List<string> input, int result)
        {
            tempCol = new List<string>(input);

            int thousands = 0;

            // Условие проверки наличия Тысяч в коллекции слов входящей строки
            if (input.Contains("тысяч") || input.Contains("тысяча") || input.Contains("тысячи"))
            {
                // Условие определения одной тысячи, если не указано количество тысяч
                if (input.FirstOrDefault() == "тысяча") thousands = 1000;
                else
                {
                    // Цикл преобразования слов в числа
                    foreach (var i in tempCol)
                    {
                        // Вывод временного числа
                        Number.TryGetValue(i, out tempNum);

                        // Получение количества тысяч
                        thousands = thousands + tempNum;

                        // Удаление преобразованного слова
                        input.Remove(i);

                        if (i == "тысяча" || i == "тысяч" || i == "тысячи")
                        {
                            input.Remove(i);

                            break;
                        }
                    }

                    // Получение числа тысяч
                    thousands = thousands * 1000;
                }

                // Промежуточный итог преобразования
                result = result + thousands;

                // Присваивание временной коллекции оставшегося количества слов в коллекции
                tempCol = input;
            }

            // Вызов метода преобразования оставшихся чисел
            Numbers(tempCol, result);
        }

        /// <summary>
        /// Метод выделяет из общей оставшиеся числа
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        public void Numbers(List<string> input, int result)
        {
            var numbers = 0;

            int tempNum;

            // Цикл преобразования слов в числа
            foreach (var i in input)
            {
                Number.TryGetValue(i, out tempNum);

                numbers = numbers + tempNum;
            }

            // Конечный результат
            Result = result + numbers;
        }
    }
}
