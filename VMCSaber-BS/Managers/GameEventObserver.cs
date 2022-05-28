using System;
using SiraUtil.Logging;
using SiraUtil.Sabers;
using UnityEngine;
using VMCSaberBS.Util;
using Zenject;

namespace VMCSaberBS.Managers
{
    public class GameEventObserver: IInitializable, IDisposable
    {
        private readonly SiraLog _log;
        private readonly PluginConfig _pluginConfig;
        private readonly SaberEventEmitter _emitter;
        private readonly ColorManager _colorManager;
        private readonly SaberModelManager _saberModelManager;

        public GameEventObserver(SiraLog log, SaberEventEmitter emitter, ColorManager colorManager, PluginConfig pluginConfig, SaberModelManager saberModelManager)
        {
            _log = log;
            _emitter = emitter;
            _colorManager = colorManager;
            _pluginConfig = pluginConfig;
            _saberModelManager = saberModelManager;
        }

        public void Initialize()
        {
            var path = SaberUtil.GetCurrentSaberPath();
            if (!string.IsNullOrEmpty(path))
            {
                _log.Info($"SaberPath={path}");
                _emitter.SendSaberPath(path);
            }

            var leftColor = _colorManager.ColorForSaberType(SaberType.SaberA);
            _emitter.SendSaberColor(SaberType.SaberA, leftColor);
            
            var rightColor = _colorManager.ColorForSaberType(SaberType.SaberB);
            _emitter.SendSaberColor(SaberType.SaberB, rightColor);

            _emitter.SendSaberScale(_pluginConfig.SaberScale);

            // Send Controller Rotation
            var leftRot = SaberUtil.GetLeftControllerRot();
            _emitter.SendControllerRot(SaberType.SaberA, leftRot);
            var rightRot = SaberUtil.GetRightControllerRot();
            _emitter.SendControllerRot(SaberType.SaberB, rightRot);
            _log.Info($"Controller Rot: Left={leftRot}, Right={rightRot}");

            _saberModelManager.ColorUpdated += OnColorUpdated;
        }

        private void OnColorUpdated(Saber saber, Color color)
        {
            _emitter.SendSaberColor(saber.saberType, color);
        }

        public void Dispose()
        {
            _emitter.SendSaberState(false);
            _saberModelManager.ColorUpdated -= OnColorUpdated;
        }
    }
}