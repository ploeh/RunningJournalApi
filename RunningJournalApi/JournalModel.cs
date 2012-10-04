using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ploeh.Samples.RunningJournalApi
{
    [XmlRoot("journal", Namespace = "http://samples.ploeh.dk/journal/2012")]
    public class JournalModel
    {
        [XmlArray("entries")]
        [XmlArrayItem("entry")]
        public JournalEntryModel[] Entries { get; set; }
    }
}
