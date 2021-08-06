using UnityEngine;
using UnityEngine.Events;

public class Restar : MonoBehaviour
{
    [SerializeField] private UnityEvent _restarGameEvent;
    public void RestarGame()
    {
        _restarGameEvent?.Invoke();
        gameObject.SetActive(false);
    }
}
