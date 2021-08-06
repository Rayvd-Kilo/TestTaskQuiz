using UnityEngine;

[CreateAssetMenu(fileName = "New CellsDataSet",menuName = "Cells Data Set")]
public class CellsDataSet : ScriptableObject
{
    [SerializeField] private CellData[] _cellsData;

    public CellData[] CellsData { get { return _cellsData; } }
}
