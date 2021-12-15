using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FERITOrganizator.Shared.Models
{
    [Serializable, XmlType("predmet")]
    public partial class Subject
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("semestar")]
        public int Semester { get; set; }
    }
}
