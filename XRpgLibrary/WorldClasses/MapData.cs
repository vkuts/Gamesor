using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RpgLibrary.WorldClasses
{
    [DataContract]
    public class MapData
    {
        [DataMember]
        public string MapName;
        [DataMember]
        public MapLayerData[] Layers;
        [DataMember]
        public TilesetData[] Tilesets;

        private MapData()
        {
        }

        public MapData(string mapName, List<TilesetData> tilesets, List<MapLayerData> layers)
        {
            MapName = mapName;
            Tilesets = tilesets.ToArray();
            Layers = layers.ToArray();
        }
    }
}
