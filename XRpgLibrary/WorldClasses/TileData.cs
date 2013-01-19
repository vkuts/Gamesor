using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RpgLibrary.WorldClasses
{
    [DataContract]
    public class TileData
    {
        [DataMember]
        public int TileIndex;
        [DataMember]
        public int TileSetIndex;
        [DataMember]
        public bool IsPassable;

        public TileData(int tileIndex, int tileSetIndex, bool isPassable = true)
        {
            TileIndex = tileIndex;
            TileSetIndex = tileSetIndex;
            IsPassable = isPassable;
        }
    }
}
