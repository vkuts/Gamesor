using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CommonLibrary;

namespace XLevelEditor.Settings
{
    public class SettingsManager
    {
        #region Location Defaults

        const string _editorSettingsSubdirName = "Gamesor";
        const string _editorSettingsFilename = "LevelEditor.settings";

        string _settingsRootPath;
        string _settingsFilePath;

        LevelEditorSettings _settings;
        #endregion

        #region Properties
        
        //public LevelEditorSettings Settings
        //{
        //    get { return _settings; }
        //    private set { _settings = value; }
        //}

        public string DefaultTileSetLocation
        {
            get { return _settings.DefaultTileSetLocation; }
            set
            {
                _settings.DefaultTileSetLocation = value;
                SaveSettings();
            }
        }

        public string DefaultLevelSaveLocation
        {
            get { return _settings.DefaultLevelSaveLocation; }
            set
            {
                _settings.DefaultLevelSaveLocation = value;
                SaveSettings();
            }
        }

        public string DefaultGameSaveLocation
        {
            get { return _settings.DefaultGameSaveLocation; }
            set
            {
                _settings.DefaultGameSaveLocation = value;
                SaveSettings();
            }
        }
        
        #endregion

        public SettingsManager()
        {
            // attempt to read in default locations
            string myDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _settingsRootPath = Path.Combine(myDocsPath, _editorSettingsSubdirName);

            if (!Directory.Exists(_settingsRootPath))
                Directory.CreateDirectory(_settingsRootPath);

            _settingsFilePath = Path.Combine(_settingsRootPath, _editorSettingsFilename);

            // if we already have a settings file saved from a previous run, load it
            if (File.Exists(_settingsFilePath))
            {
                _settings = Serializer.DeserializeFromFile<LevelEditorSettings>(_settingsFilePath);
            }
            else
            {
                string currentDir = Environment.CurrentDirectory;
                _settings = new LevelEditorSettings()
                {
                    DefaultLevelSaveLocation = currentDir,
                    DefaultTileSetLocation = currentDir,
                    DefaultGameSaveLocation = currentDir
                };

                SaveSettings();
            }
            
        }

        private void SaveSettings()
        {
            // else create it for later
            Serializer.SerializeToFile(_settings, _settingsFilePath);
        }
    }
}
