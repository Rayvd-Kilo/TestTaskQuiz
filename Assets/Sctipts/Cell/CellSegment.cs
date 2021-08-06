using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class CellSegment : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private CellData _cellData;
    private QuizAnswer _quizAnswer;

    [SerializeField] private ParticleSystem _sparcleParticle;

    [SerializeField] private UnityEvent _rightAnswerEvent;
    [SerializeField] private UnityEvent _wrongAnswerEvent;

    public void InitializeSegment(CellData data)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _quizAnswer = FindObjectOfType<QuizAnswer>();

        _cellData = data;
        _spriteRenderer.sprite = _cellData.Sprite;
    }
    private void OnMouseDown()
    {
        if (_quizAnswer.Answer == _cellData.Identifier)
        {
            _sparcleParticle.Play();
            GetComponent<CellAnimation>().TransformBounce(_rightAnswerEvent);
        }
        else
            _wrongAnswerEvent?.Invoke();
    }
    public void AddRightrAnswerEventListener(UnityAction action)
    {
        _rightAnswerEvent.AddListener(action);
    }
    public void SetInactive()
    {
        enabled = false;
    }
    public void DestroySegment()
    {
        Destroy(gameObject);
    }
}
