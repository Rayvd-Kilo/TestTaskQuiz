using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class QuizAnswer : MonoBehaviour
{
    private Text _text;
    private CellData _answer;
    public string Answer { get { return _answer.Identifier; } }

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    public void SetAnswerText(CellData data)
    {
        _answer = data;
        _text.text = "Find " + _answer.Identifier;
    }
}
