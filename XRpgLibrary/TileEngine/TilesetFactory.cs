using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.WorldClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace XRpgLibrary.TileEngine
{
    public class TilesetFactory
    {
        public const string TilesetContentSubdir = "Tilesets";

        public static Tileset Create(TilesetData data, Game game)
        {
            // assumption is that game's content contains a subdir with all of our tilesets
            var contentString = Path.Combine(TilesetContentSubdir, Path.GetFileNameWithoutExtension(data.TilesetImageName));
            var texture = game.Content.Load<Texture2D>(contentString);
            return new Tileset(texture, 
                                data.TilesWide, 
                                data.TilesHigh,                            
                                data.TileWidthInPixels, 
                                data.TileHeightInPixels);
        }
    }
}
