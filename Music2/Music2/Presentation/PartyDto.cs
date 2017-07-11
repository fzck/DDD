using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Presentation
{
    public class PartyDto : BaseDto
    {
        public string DisplayName { get; set; }
        public uint RowVersion { get; set; }

        public PartyDto() { }

        public PartyDto(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
