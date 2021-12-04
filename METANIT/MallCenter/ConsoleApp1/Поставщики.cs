using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Поставщики
    {
        public Поставщики()
        {
            Складs = new HashSet<Склад>();
        }

        public string Наименование { get; set; } = null!;
        public int Телефон { get; set; }
        public int IdПоставщика { get; set; }

        public virtual ICollection<Склад> Складs { get; set; }
    }
}
