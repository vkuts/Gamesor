using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RpgLibrary.WorldClasses
{
    [DataContract]
    public class LevelData
    {
        [DataMember]
        public string LevelName;
        [DataMember]
        public string MapName;
        [DataMember]
        public int MapWidth;
        [DataMember]
        public int MapHeight;
        [DataMember]
        public string[] CharacterNames;
        [DataMember]
        public string[] ChestNames;
        [DataMember]
        public string[] TrapNames;

        private LevelData()
        {
        }

        public LevelData(
            string levelName, 
            string mapName,
            int mapWidth, 
            int mapHeight, 
            List<string> characterNames, 
            List<string> chestNames, 
            List<string> trapNames)
        {
            LevelName = levelName;
            MapName = mapName;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            CharacterNames = characterNames.ToArray();
            ChestNames = chestNames.ToArray();
            TrapNames = trapNames.ToArray();
        }
    }
}
