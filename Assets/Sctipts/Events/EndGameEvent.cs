using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGameEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _endgameEvent;
    public void SubscribeAllSegments(List<CellSegment> segments)
    {
        foreach(var segment in segments)
        {
            _endgameEvent.AddListener(segment.SetInactive);
        }
    }
    public void InvokeEvent()
    {
        _endgameEvent?.Invoke();
    }
}
