using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Game/Levels", order = 0)]
    public sealed class Levels : ScriptableObject
    {
        [SerializeField] private List<LevelData> levels = new List<LevelData>();

        public IReadOnlyList<LevelData> GameLevels => levels;
    }
}