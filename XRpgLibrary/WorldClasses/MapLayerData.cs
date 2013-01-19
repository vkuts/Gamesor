using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RpgLibrary.WorldClasses
{
    [DataContract]
    public class MapLayerData
    {
        [DataMember]
        public string MapLayerName;
        [DataMember]
        public int Width;
        [DataMember]
        public int Height;
        [DataMember]
        public TileData[] Layer;

        private MapLayerData()
        {
        }

        public MapLayerData(string mapLayerName, int width, int height)
        {
            MapLayerName = mapLayerName;
            Width = width;
            Height = height;

            Layer = new TileData[height * width];
        }

        public MapLayerData(string mapLayerName, int width, int height, int tileIndex, int tileSet)
        {
            MapLayerName = mapLayerName;
            Width = width;
            Height = height;

            Layer = new TileData[height * width];

            TileData tile = new TileData(tileIndex, tileSet);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    SetTile(x, y, tile);
        }

        public void SetTile(int x, int y, TileData tile)
        {
            Layer[y * Width + x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileSet)
        {
            Layer[y * Width + x] = new TileData(tileIndex, tileSet);
        }

        public TileData GetTile(int x, int y)
        {
            return Layer[y * Width + x];
        }
    }
}
