using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class Сотрудник
    {
        public Сотрудник()
        {
            Сделкаs = new HashSet<Сделка>();
        }

        public string Имя { get; set; } = null!;
        public string? КодРуководителя { get; set; }
        public DateTime ДатаУстройстваНаРаботу { get; set; }
        public int IdСотрудника { get; set; }

        public virtual ICollection<Сделка> Сделкаs { get; set; }
    }
}
