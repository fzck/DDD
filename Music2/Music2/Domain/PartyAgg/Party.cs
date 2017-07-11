using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Domain.PartyAgg
{
    public class Party : Entity
    {
        public string DisplayName { get; set; }
        public uint ConcurrencyStamp { get; set; }

        public Party() { }

        public Party (string displayName)
        {
            DisplayName = displayName;
        }

        public virtual void ChangeDisplayName(string newPartyName)
        {
            DisplayName = newPartyName;
        }
     
    }
}
