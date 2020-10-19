using Homwork23_a.Interfaces;
using Homwork23_a.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Homwork23_a.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Поле события изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private string mess;
        public string Mess
        {
            get => mess;
            set
            {
                mess = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mess)));
            }
        }

        private string input;
        /// <summary>
        /// Свойтсво вводимых данных
        /// </summary>
        public string Input
        {
            get => input;
            set 
            {
                input = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Input)));

                OutputResult();
            }
        }

        private bool words;
        /// <summary>
        /// Свойство вводимых чисел словами
        /// </summary>
        public bool Words
        {
            get => words;
            set
            {
                words = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Words)));

                OutputResult();
            }
        }

        public MainViewModel()
        {
        }

        /// <summary>
        /// Метод вывода результата в форму
        /// </summary>
        private void OutputResult()
        {
            IConvertStringToNumbers convert = null;

            if (Words)
            {
                // Создание экземпляра класса перевода строкового представление числа в числовое
                convert = new ConvertStringToDigit(Input);
            }
            else
            {
                // Создание экземпляра класса перевода текстовое представление числа в числовое
                convert = new ConvertNumbersWordToNumbers(Input);
            }

            // Условие корректного вывода
            if (convert.CheckString())
            {
                Mess = convert.Result.ToString();
            }
            else
            {
                // Вывод сообщения о некорректном вводе
                if (!string.IsNullOrEmpty(input))
                {
                    // Сообщенние об ошибке
                    Mess = "Введенные данные не являются числом.";
                }
                else
                {
                    Mess = string.Empty;
                }
            }
        }
    }
}
