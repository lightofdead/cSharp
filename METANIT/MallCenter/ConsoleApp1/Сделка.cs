using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Сделка
    {
        public int КодНаСкладе { get; set; }
        public int КодКлиента { get; set; }
        public int КодСотрудника { get; set; }
        public decimal Количество { get; set; }
        public DateTime Дата { get; set; }
        public int IdСделки { get; set; }

        public virtual Клиент КодКлиентаNavigation { get; set; } = null!;
        public virtual Склад КодНаСкладеNavigation { get; set; } = null!;
        public virtual Сотрудник КодСотрудникаNavigation { get; set; } = null!;
    }
}
