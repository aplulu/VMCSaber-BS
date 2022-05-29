using System;
using OscJack;
using UnityEngine;
using Zenject;

namespace VMCSaberBS.Managers
{
    public class SaberEventEmitter : IInitializable, IDisposable
    {
        private string _host = "127.0.0.1";
        private OscClient _client;
        private PluginConfig _pluginConfig;
        
        public SaberEventEmitter(PluginConfig pluginConfig)
        {
            _pluginConfig = pluginConfig;
        }


        public void Initialize()
        {
            _client?.Dispose();
            _client = new OscClient(_host, _pluginConfig.SendPort);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public void SendSaberState(bool state)
        {
            _client.Send($"/VMCSaber/Saber/{(state ? "On" : "Off")}");
        }

        public void SendSaberPath(string path)
        {
            _client.Send("/VMCSaber/Saber/Path", path);
        }

        public void SendSaberColor(SaberType saberType, Color color)
        {
            _client.Send($"/VMCSaber/Saber/Color/{(saberType == SaberType.SaberA ? "Left" : "Right")}", color.r, color.g, color.b, color.a);
        }

        public void SendSaberScale(float scale)
        {
            _client.Send("/VMCSaber/Saber/Scale", scale);
        }
        
        public void SendControllerRot(SaberType saberType, Vector3 rot)
        {
            _client.Send($"/VMCSaber/Controller/Rot/{(saberType == SaberType.SaberA ? "Left" : "Right")}", rot.x, rot.y, rot.z);
        }

        public void SendControllerPos(SaberType saberType, Vector3 pos)
        {
            _client.Send($"/VMCSaber/Controller/Pos/{(saberType == SaberType.SaberA ? "Left" : "Right")}", pos.x, pos.y, pos.z);
        }
    }
}
