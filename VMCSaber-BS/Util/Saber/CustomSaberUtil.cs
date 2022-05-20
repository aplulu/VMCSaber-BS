using CustomSaber.Settings;

namespace VMCSaberBS.Util.Saber
{
    public static class CustomSaberUtil
    {
        public static string GetCurrentSaber()
        {
            return Configuration.CurrentlySelectedSaber;
        }
    }
}
