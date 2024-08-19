using System;

namespace _project.Scripts
{
    [Serializable]
    public sealed class LevelData
    {
        public float time = 60;
        public float coinsRate = 1f;
        public float coinsSpeed = 3f;
        public float collectionDistance = 0.5f;
        public int coinScoreAddition = 5;
        public float shipSpeed = 300f;
    }
}