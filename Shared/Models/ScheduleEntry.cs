using System;
using System.Xml;
using System.Xml.Serialization;

namespace FERITOrganizator.Shared.Models
{
    [Serializable, XmlType("stavkaRasporeda")]
    public partial class ScheduleEntry
    {
        public ScheduleEntry()
        {
            Subject = new Subject();
        }

        [XmlElement("smjer")]
        public string Course { get; set; }

        [XmlElement("predmet")]
        public Subject Subject { get; set; }
        
        [XmlElement("nastavnik")]
        public string Professor { get; set; }

        [XmlElement("vrstanastave")]
        public string ClassType { get; set; }

        [XmlIgnore]
        public DateTime Start { get; set; }
        [XmlElement("pocetak")]
        public string StartString
        {
            get { return this.Start.ToString("HH:mm"); }
            set { this.Start = DateTime.Parse(value); }
        }
        
        [XmlIgnore]
        public DateTime End { get; set; }
        [XmlElement("kraj")]
        public string EndString
        {
            get { return this.End.ToString("HH:mm"); }
            set { this.End = DateTime.Parse(value); }
        }

        [XmlElement("prostorija")]
        public string Classroom { get; set; }

        [XmlElement("grupastudenata")]
        public string Group { get; set; }

        [XmlElement("dodatniopis")]
        public string Details { get; set; }

        [XmlElement("odradjeno")]
        public int Done { get; set; }

        [XmlElement("planirano")]
        public int Expected { get; set; }
    }
}
