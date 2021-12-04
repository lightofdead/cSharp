using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Склад
    {
        public Склад()
        {
            Сделкаs = new HashSet<Сделка>();
        }

        public int КодТовара { get; set; }
        public int КодПоставщика { get; set; }
        public decimal Количество { get; set; }
        public decimal Цена { get; set; }
        public DateTime ДатаПоставки { get; set; }
        public int IdПоставки { get; set; }

        public virtual Поставщики КодПоставщикаNavigation { get; set; } = null!;
        public virtual Товар КодТовараNavigation { get; set; } = null!;
        public virtual ICollection<Сделка> Сделкаs { get; set; }
    }
}
