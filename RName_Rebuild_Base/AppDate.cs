using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RName_Rebuild_Base
{
    public class AppDate
    {
        public AppDate()
        { }
        private Boolean m_isRepeat = true;
        public Boolean IsRepeat
        {
            get
            {
                return m_isRepeat;
            }
            set
            {
                m_isRepeat = value;
            }
        }
        private Int32 m_repeatTimes = 1;
        public Int32 RepeatTimes
        {
            get
            {
                return m_repeatTimes;
            }
            set
            {
                m_repeatTimes = value;
            }
        }
        private Boolean m_isMultipleChoices = true;
        public Boolean IsMultipleChoices
        {
            get
            {
                return m_isMultipleChoices;
            }
            set
            {
                m_isMultipleChoices = value;
            }
        }
        private Dictionary<String, (Boolean,Byte)> m_name = new Dictionary<String, (Boolean,Byte)>();
        public Dictionary<String, (Boolean,Byte)> Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
    
    }
    public static class
    {
        public static AppDate ReadFromXmlFile(String xmlPath)
        {
            using Stream stream = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);
            return ReadFromXmlFile(stream);
        }
        public static AppDate ReadFromXmlFile(Stream stream)
        {
            using StreamReader streamReader = new StreamReader(stream , Encoding.UTF8);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(streamReader.ReadToEnd());
            XmlElement? rootElement = xmlDocument.DocumentElement;
            AppDate appDate = new AppDate();
            if(rootElement != null)
            {
                foreach(XmlElement xmlElement in rootElement.ChildNodes)
                {
                    switch(xmlElement.Name)
                    {
                        case nameof(AppDate.IsRepeat):
                            appDate.IsRepeat = Boolean.Parse(xmlElement.GetAttribute(nameof(AppDate.IsRepeat)));
                            break;
                        case nameof(AppDate.IsMultipleChoices):
                            appDate.IsMultipleChoices = Boolean.Parse(xmlElement.GetAttribute(nameof(AppDate.IsMultipleChoices)));
                            break;
                        case nameof(AppDate.RepeatTimes):
                            appDate.RepeatTimes = Int32.Parse(xmlElement.GetAttribute(nameof(AppDate.RepeatTimes)));
                            break;
                    }
                }
            }
            return appDate;
        }
        public static void ReadNamesFromXmlFile(this AppDate appDate,String path)
        {
            using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(streamReader.ReadToEnd());
            XmlElement? xmlElement = xmlDocument.DocumentElement;
            if (xmlElement != null)
            {
                foreach (XmlElement element in xmlElement.ChildNodes)
                {
                    String value = element.GetAttribute("VALUE");
                    String weight = element.GetAttribute("WEIGHT");
                    Boolean enable = Boolean.Parse(element.GetAttribute("ENABLE"));
                    appDate.Name.Add(value,(enable,Convert.ToByte(weight)));
                }
            }
        }
    }
}
