using System;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
        }
        public WorldData WorldData;
    }
}