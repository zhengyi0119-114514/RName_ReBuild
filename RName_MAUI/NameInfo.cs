using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RName_MAUI
{
    public class NameInfo
    {
        public NameInfo() { }
        public NameInfo(string name) { this.Name = name; }
        public string Name { get; set; } = string.Empty;
        public Boolean IsEnable { get; set; } = true;
        public Int32 Weigth { get; set; } = 0;
        public override string ToString() { return Name; }
        public Boolean IsChoosed { get; set; } = false;
    }
}
