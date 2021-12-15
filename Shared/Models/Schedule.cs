using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FERITOrganizator.Shared.Models
{
    [Serializable, XmlRoot("raspored")]
    public partial class Schedule
    {
        public Schedule()
        {
            Entries = new List<ScheduleEntry>();
        }

        [XmlIgnore]
        public DateTime Date { get; set; }
        [XmlAttribute("datum")]
        public string DateString
        {
            get { return Date.ToString("yyyy-MM-dd"); }
            set { Date = DateTime.Parse(value); }
        }

        [XmlAttribute("tjedan")]
        public int Week { get; set; }

        [XmlAttribute("tiptjedna")]
        public int WeekType { get; set; }

        [XmlAttribute("rednibrojtjedna")]
        public int WeekNumber { get; set; }

        [XmlElement("stavkaRasporeda")]
        public List<ScheduleEntry> Entries { get; set; }
    }
}
