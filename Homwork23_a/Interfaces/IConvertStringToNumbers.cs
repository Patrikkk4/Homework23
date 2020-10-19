using System;
using System.Collections.Generic;
using System.Text;

namespace Homwork23_a.Interfaces
{
    public interface IConvertStringToNumbers
    {
        /// <summary>
        /// Свойство строки, содержащей число
        /// </summary>
        string StringToNumber { get; set; }

        /// <summary>
        /// Результат обработки строки
        /// </summary>
        double Result { get; set; }

        bool CheckString();
    }
}
