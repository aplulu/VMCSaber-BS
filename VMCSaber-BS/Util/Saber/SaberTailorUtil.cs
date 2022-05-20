using UnityEngine;

namespace VMCSaberBS.Util.Saber
{
    public static class SaberTailorUtil
    {
        public static Vector3 GetLeftControllerRot()
        {
            return SaberTailor.Settings.Configuration.Grip.RotLeft;
        }
        
        public static Vector3 GetRightControllerRot()
        {
            return SaberTailor.Settings.Configuration.Grip.RotRight;
        }
    }
}