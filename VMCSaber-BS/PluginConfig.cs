namespace VMCSaberBS
{
    public class PluginConfig
    {
        public static PluginConfig Instance { get; set; }

        public float SaberScale { get; set; } = 1.0f;

        public bool EnableControllerRot { get; set; } = true;

        public bool EnableControllerPos { get; set; } = false;

        public int SendPort { get; set; } = 39540;
    }
}