using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RName_MAUI
{
    public class MainPageDateBinding : BindableObject
    {
        private ObservableCollection<NameInfo> nameInfos = new ObservableCollection<NameInfo>();
        public ObservableCollection<NameInfo> NameInfos
        {
            get { return nameInfos; }
            set { nameInfos = value; }
        }
    }
}
