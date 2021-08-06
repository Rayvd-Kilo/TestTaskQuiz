using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class CellAnimation : MonoBehaviour
{
    private Tween _tween;
    public void ScaleBounce()
    {
        _tween?.Kill();

        _tween = transform
                 .DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f, 10, 1f);
    }
    public void TransformBounce(UnityEvent rightAnswerEvent)
    {
        _tween?.Kill();

        _tween = transform
				.DOMoveY(transform.position.y + 0.4f, 0.5f/2)
				.SetEase(Ease.OutQuad)
				.OnComplete(() =>
				{
                    transform
                        .DOMoveY(transform.position.y - 0.4f, 0.5f/2)
                        .SetEase(Ease.InQuad)
                        .OnComplete(() =>
                        {
                            rightAnswerEvent?.Invoke();
                        });
				});
    }

    public void Shake()
    {
        _tween?.Kill();

        _tween = transform.DOShakePosition(1, 0.2f);
    }
}
