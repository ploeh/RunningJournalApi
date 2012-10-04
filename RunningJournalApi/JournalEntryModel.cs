using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ploeh.Samples.RunningJournalApi
{
    [XmlRoot("journal-entry", Namespace = "http://samples.ploeh.dk/journal/2012")]
    public class JournalEntryModel
    {
        [XmlElement("time")]
        public DateTimeOffset Time { get; set; }

        [XmlElement("distance")]
        public int Distance { get; set; }

        [XmlElement("duration")]
        public TimeSpan Duration { get; set; }
    }
}
