using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BorderAnimation : MonoBehaviour
{
    private Tween _fadeTween;
    private Image _borderImage;
    private float _fadeDuration = 0.5f;
    private void Start()
    {
        _borderImage = GetComponent<Image>();
    }
    public void FadeIn()
    {
        Fade(1);
    }
    public void FadeOut()
    {
        Fade(0);
    }
    private void Fade(float value)
    {
        _fadeTween.Kill();

        _fadeTween = _borderImage.DOFade(value, _fadeDuration);
    }
}
