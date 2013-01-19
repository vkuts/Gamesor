using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RpgLibrary.WorldClasses
{
    [DataContract]
    public class TilesetData
    {
        [DataMember]
        public string TilesetName;
        [DataMember]
        public string TilesetImageName;
        [DataMember]
        public int TileWidthInPixels;
        [DataMember]
        public int TileHeightInPixels;
        [DataMember]
        public int TilesWide;
        [DataMember]
        public int TilesHigh;
    }
}
