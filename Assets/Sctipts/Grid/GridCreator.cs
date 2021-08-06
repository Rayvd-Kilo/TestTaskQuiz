using UnityEngine;

[RequireComponent(typeof(GridData),typeof(GridHandler))]
public class GridCreator : MonoBehaviour
{
    [SerializeField] private int _columns;
    [SerializeField] private float _cellSize;
    [SerializeField] private CellSegment _cellPrefab;
    private GridHandler _gridHandler;
    private GridData _gridData;
    private int _levelCount = 0;
    private int _rows => CalculateRows();
    private void Awake()
    {
        _gridData = GetComponent<GridData>();
        _gridHandler = GetComponent<GridHandler>();
    }
    private int CalculateRows()
    {
        var curentDifficulty = _gridData.LevelData.Levels[_levelCount].Difficulty;
        if (curentDifficulty == Difficulty.Easy)
            return 1;
        else if (curentDifficulty == Difficulty.Medium)
            return 2;
        else
            return 3;
    }
    public void GenerateGrid()
    {
        if (IsEndGame() == false)
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    InstantiateCell(column, row);
                }
            }
            AlignGrid();
            _gridData.WriteSegmentData(_levelCount);
        }
    }
    private void InstantiateCell(int column, int row)
    {
        var spawnedCell = Instantiate(_cellPrefab, transform);

        float positionX = column * _cellSize;
        float positionY = row * -_cellSize;

        spawnedCell.gameObject.transform.position = new Vector2(positionX, positionY);
        _gridHandler.AddSegmentToGridHandler(spawnedCell);
        SubscribeToEvent(spawnedCell);
    }
    private void AlignGrid()
    {
        float gridWidth = _columns * _cellSize;
        float gridHeith = _rows * _cellSize;
        transform.position = new Vector3(-gridWidth / 2 + _cellSize / 2, gridHeith / 2 - _cellSize / 2);
    }
    private void SubscribeToEvent(CellSegment spawnedCell)
    {
        spawnedCell.AddRightrAnswerEventListener(SetNextGrid);
        spawnedCell.AddRightrAnswerEventListener(_gridHandler.WipeAllSegments);
        spawnedCell.AddRightrAnswerEventListener(GenerateGrid);
    }
    private void SetNextGrid()
    {
        if (IsEndGame() == false)
        {
            _levelCount++;
            transform.position = new Vector2(0, 0);
        }
    }
    private bool IsEndGame()
    {
        if (_levelCount < _gridData.LevelData.Levels.Length)
            return false;
        else
        {
            GetComponent<EndGameEvent>().InvokeEvent();
            return true;
        }  
    }
    public void ResetLevelCounter()
    {
        _levelCount = 0;
    }

}
