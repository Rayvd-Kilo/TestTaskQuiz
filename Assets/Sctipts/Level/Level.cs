using System;
using UnityEngine;

[Serializable]
public class Level 
{
    [SerializeField] private Difficulty _difficulty;
    [SerializeField] private CellsDataSet _cellsDataSet;

    public Difficulty Difficulty { get { return _difficulty; } }
    public CellsDataSet CellsDataSet { get { return _cellsDataSet; } }
}
