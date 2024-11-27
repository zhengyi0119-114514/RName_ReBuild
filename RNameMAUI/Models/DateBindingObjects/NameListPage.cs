using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RNameMAUI.Models;

public class NameListPageBinding : BindableObject
{
    public NameListPageBinding()
    {
    }
    private NameList _nameList = new() { };
    private Dictionary<String,Int32> _nameMap = new();
    public NameList NameList
    {
        get { return this._nameList; }
        set
        {
            this._nameList = value;
            OnPropertyChanged();
        }
    }
}
