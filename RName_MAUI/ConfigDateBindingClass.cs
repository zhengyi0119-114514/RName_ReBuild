using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RName_MAUI
{
    public class ConfigDateBindingClass :BindableObject
    {
        public ConfigDateBindingClass() { }
        ObservableCollection<NameInfo> nameInfos = new ObservableCollection<NameInfo>();
        public ObservableCollection<NameInfo> NameInfos
        {
            get { return nameInfos; }
            set 
            {
                nameInfos = value; 
                this.OnPropertyChanged(nameof(NameInfos));
            }
        }
        private String nameToAddText = String.Empty;
        public String NameToAddText
        {
            get { return nameToAddText; }
            set {
                nameToAddText = value; 
                this.OnPropertyChanged(nameof(NameToAddText));
            }
        }
    }
}
