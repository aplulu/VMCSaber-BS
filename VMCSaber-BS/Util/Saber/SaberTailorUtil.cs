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
        
        public static Vector3 GetLeftControllerPos()
        {
            return SaberTailor.Settings.Configuration.Grip.PosLeft;
        }
        
        public static Vector3 GetRightControllerPos()
        {
            return SaberTailor.Settings.Configuration.Grip.PosRight;
        }
    }
}