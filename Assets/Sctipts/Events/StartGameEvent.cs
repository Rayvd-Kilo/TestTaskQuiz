using UnityEngine;
using UnityEngine.Events;

public class StartGameEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _startGameEvent;
    private void Start()
    {
        InvokeEvent();
    }
    public void InvokeEvent()
    {
        _startGameEvent?.Invoke();
    }
}
