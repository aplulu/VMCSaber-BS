using System;
using System.IO;
using IPA.Loader;
using IPA.Utilities;
using UnityEngine;
using VMCSaberBS.Util.Saber;

namespace VMCSaberBS.Util
{
    public class SaberUtil
    {
        public static string GetCurrentSaberPath()
        {
            if (PluginManager.GetPlugin("Saber Factory") != null)
            {
                try
                {
                    var current = SaberFactoryUtil.GetCurrentSaber();
                    if (!string.IsNullOrEmpty(current))
                    {
                        return Path.Combine(UnityGame.InstallPath, current);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            if (PluginManager.GetPlugin("Custom Sabers") != null)
            {
                try
                {
                    return Path.Combine(UnityGame.InstallPath, "CustomSabers", CustomSaberUtil.GetCurrentSaber());
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return null;
        }

        public static Vector3 GetLeftControllerRot()
        {
            if (PluginManager.GetPlugin("SaberTailor") != null && PluginConfig.Instance.EnableControllerRot)
            {
                return SaberTailorUtil.GetLeftControllerRot();
            }
            return Vector3.zero;
        }
        
        public static Vector3 GetRightControllerRot()
        {
            if (PluginManager.GetPlugin("SaberTailor") != null && PluginConfig.Instance.EnableControllerRot)
            {
                return SaberTailorUtil.GetRightControllerRot();
            }
            return Vector3.zero;
        }
        
        public static Vector3 GetLeftControllerPos()
        {
            if (PluginManager.GetPlugin("SaberTailor") != null && PluginConfig.Instance.EnableControllerPos)
            {
                return SaberTailorUtil.GetLeftControllerPos();
            }
            return Vector3.zero;
        }
        
        public static Vector3 GetRightControllerPos()
        {
            if (PluginManager.GetPlugin("SaberTailor") != null && PluginConfig.Instance.EnableControllerPos)
            {
                return SaberTailorUtil.GetRightControllerPos();
            }
            return Vector3.zero;
        }
    }
}