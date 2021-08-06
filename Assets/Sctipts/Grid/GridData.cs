using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private QuizAnswer _quizAnswer;
    private GridHandler _gridHandler;
    private List<CellSegment> _cellSegments { get { return (List<CellSegment>)_gridHandler.Segments; } } 
    public LevelData LevelData { get { return _levelData; } }

    private void Awake()
    {
        _gridHandler = GetComponent<GridHandler>();
    }
    public void WriteSegmentData(int levelCount)
    {
        var gridDataList = GenerateCellsList(levelCount);
        for (int segmentID = 0; segmentID < _cellSegments.Count; segmentID++)
        {
            _cellSegments[segmentID].InitializeSegment(gridDataList[segmentID]);
        }
        GetComponent<EndGameEvent>().SubscribeAllSegments(_cellSegments);
        _quizAnswer.SetAnswerText(GetRightAnswer(gridDataList));
    }
    private List<CellData> GenerateCellsList(int levelCount)
    {
        var resultList = new List<CellData>();
        while (resultList.Count != _cellSegments.Count)
        {
            var element = _levelData.Levels[levelCount].CellsDataSet.CellsData[Random.Range(0, _levelData.Levels[levelCount].CellsDataSet.CellsData.Length)];
            if (!resultList.Contains(element))
            {
                resultList.Add(element);
            }
        }
        return resultList;
    }
    private CellData GetRightAnswer(List<CellData> cells)
    {
        return cells[Random.Range(0, cells.Count)];
    }

}
