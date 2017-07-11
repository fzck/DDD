using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.RecordAgg
{
    public class Record : Entity
    {
        public string Title { get; set; }

        public uint ConcurrencyStamp { get; set; }

        public Record() { }

        public Record(string displayName)
        {
            Title = displayName;
        }
        
    }
}
