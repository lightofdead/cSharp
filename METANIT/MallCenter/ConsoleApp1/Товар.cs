using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Товар
    {
        public Товар()
        {
            Складs = new HashSet<Склад>();
        }

        public string Наименование { get; set; } = null!;
        public string Описание { get; set; } = null!;
        public int IdТовара { get; set; }

        public virtual ICollection<Склад> Складs { get; set; }
    }
}
