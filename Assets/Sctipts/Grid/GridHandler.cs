using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    private List<CellSegment> _segments = new List<CellSegment>();
    
    public IList<CellSegment> Segments { get { return _segments; } }

    public void BounceInSegments()
    {
        foreach(var segment in _segments)
        {
            segment.GetComponent<CellAnimation>().ScaleBounce();
        }
    }
    public void AddSegmentToGridHandler(CellSegment segment)
    {
        _segments.Add(segment);
    }
    public void WipeAllSegments()
    {
        foreach (var segment in _segments)
        {
            segment.DestroySegment();
        }
        _segments.Clear();
    }
}
