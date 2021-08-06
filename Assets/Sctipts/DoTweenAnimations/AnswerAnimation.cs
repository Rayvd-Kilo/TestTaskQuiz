using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnswerAnimation : MonoBehaviour
{
    private Tween _fadeTween;
    private Text _answerText;
    private float _fadeDuration = 1.5f;
    private void Awake()
    {
        _answerText = GetComponent<Text>();
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

        _fadeTween = _answerText.DOFade(value,_fadeDuration);
    }
}
