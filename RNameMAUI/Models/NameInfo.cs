using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RNameMAUI.Models;

public class NameInfo : BindableObject
{
    public NameInfo(String fullName) { this._name = fullName.Trim(); }
    private readonly string _name = String.Empty;
    private Int32 _weight = 100;
    private Boolean _isEnable = true;
    private Int32 _ID = 0;
    private NameList? _nameList = null;
    public Int32 ID
    {
        get { return _ID; }
        set { _ID = value; OnPropertyChanged(); }
    }
    public NameList? NameList
    {
        get => this._nameList;
        set { this._nameList = value; }
    }
    public String FullName
    {
        get
        { return _name; }
        init
        {
            _name = _name ?? String.Empty;
            OnPropertyChanged();
        }
    }
    public Int32 Weight
    {
        get { return _weight; }
        set
        {
            _weight = value; OnPropertyChanged();
        }
    }
    public Boolean IsEnable
    {
        get { return _isEnable; }
        set
        {
            _isEnable = value; OnPropertyChanged();
        }
    }
    public ICommand Del
    {
        get
        {
            return new Command(() =>{NameList?.RemoveAt(ID);});
        }
    }
    public static Boolean operator ==(NameInfo left, NameInfo right)
    {
        return String.Equals(left._name, right._name);
    }
    public static Boolean operator !=(NameInfo left, NameInfo right)
    {
        return !String.Equals(left._name, right._name);
    }
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return _name.GetHashCode();
    }
}
