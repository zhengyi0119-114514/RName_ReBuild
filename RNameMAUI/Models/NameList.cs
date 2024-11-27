using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RNameMAUI.Models;

public class NameList : ObservableCollection<NameInfo>
{
    public NameList() : base()
    {
        (this as INotifyCollectionChanged).CollectionChanged += (s, e) =>
        {
            var items = this.ToArray();
            for (int i = 0;i<items.Length;i++)
            {
                items[i].NameList = this;
                items[i].ID = (int)i;
            }
        };
    }
    public new void Add(NameInfo nameInfo)
    {

        Boolean hasName = false;
        if (String.IsNullOrWhiteSpace(nameInfo.FullName))
        {
            return;
        }
        foreach (var item in this)
        {
            if (item.FullName == nameInfo.FullName)
            {
                hasName = true;
            }
        }
        if (!hasName)
        {
            base.Add(nameInfo);
        }
    }
}
