using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Клиент
    {
        public Клиент()
        {
            Сделкаs = new HashSet<Сделка>();
        }

        public string Имя { get; set; } = null!;
        public int Телефон { get; set; }
        public string Пол { get; set; } = null!;
        public int IdКлиента { get; set; }

        public virtual ICollection<Сделка> Сделкаs { get; set; }
    }
}
