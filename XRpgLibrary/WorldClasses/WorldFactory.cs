using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.WorldClasses;
using XRpgLibrary.TileEngine;
using Microsoft.Xna.Framework;

namespace XRpgLibrary.WorldClasses
{
    public class WorldFactory
    {

        public static World Create(MapData mapData, LevelData newLevel, Game game, Rectangle screenRec)
        {
            var tilesetList = new List<Tileset>();
            foreach (TilesetData data in mapData.Tilesets)
            {
                tilesetList.Add(
                    TilesetFactory.Create(data, game)
                    );
            }

            var mapLayers = mapData.Layers.Select(l => MapLayer.FromMapLayerData(l)).ToList();

            // MUSTDO: modify TileMap to be able to accept multiple tile sets
            var map = new TileMap(tilesetList[0], mapLayers[0]);

            // SHOULDDO: find out why does map need tilesets to?
            for (int i = 1; i < tilesetList.Count; i++)
                map.AddTileset(tilesetList[i]);

            for (int i = 1; i < mapLayers.Count; i++)
                map.AddLayer(mapLayers[i]);

            var level = new Level(map);

            var world = new World(game, screenRec);
            world.Levels.Add(level);
            world.CurrentLevel = 0;

            return world;



        }

    }
}
