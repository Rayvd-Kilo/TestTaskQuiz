using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField] Level[] _levels;

    public Level[] Levels { get { return _levels; } }
}
