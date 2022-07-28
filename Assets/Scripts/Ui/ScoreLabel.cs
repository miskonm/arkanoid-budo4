using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreLabel : MonoBehaviour
{
    private TextMeshProUGUI _label;

    private void Awake()
    {
        _label = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += ScoreChanged;

        ScoreChanged(GameManager.Instance.Score);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnScoreChanged -= ScoreChanged;
    }

    private void ScoreChanged(int score) =>
        _label.text = $"Score: {score}";
}