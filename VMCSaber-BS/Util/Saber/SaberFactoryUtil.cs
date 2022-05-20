using System;
using System.IO;
using IPA.Utilities;
using Newtonsoft.Json;

namespace VMCSaberBS.Util.Saber
{
    public static class SaberFactoryUtil
    {
        public static string GetCurrentSaber()
        {
            var configurationPath = Path.Combine(UnityGame.UserDataPath, "Saber Factory", "Presets", "default");
                
            try
            {
                using var file = File.OpenText(configurationPath);
                var serializer = new JsonSerializer();
                var conf = (SaberSet) serializer.Deserialize(file, typeof(SaberSet));

                if (conf != null)
                {
                    if (conf.LeftSaber != null && conf.LeftSaber.PieceCollection != null &&
                        conf.LeftSaber.PieceCollection.Length > 0)
                    {
                        return conf.LeftSaber.PieceCollection[0].Path;
                    }
                    if (conf.RightSaber != null && conf.RightSaber.PieceCollection != null &&
                        conf.RightSaber.PieceCollection.Length > 0)
                    {
                        return conf.RightSaber.PieceCollection[0].Path;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }
        
        class SaberSet
        {
            public SaberModel LeftSaber = null;
            public SaberModel RightSaber = null;
        }

        class SaberModel
        {
            public SaberPiece[] PieceCollection = null;
        }

        class SaberPiece
        {
            public string Path = null;
        }
    }
}