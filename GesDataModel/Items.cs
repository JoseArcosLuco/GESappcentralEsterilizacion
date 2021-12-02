using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ges.data.model
{
    public class Items
    {
        public Items()
        {
        }
        public Items(String variable, String valor)
        {
            this.variable = variable;
            this.valor = valor;
        }

        public String variable { get; set; }
        public String valor { get; set; }
    }
}
