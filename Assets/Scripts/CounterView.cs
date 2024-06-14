using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= OnScoreChanged;
    }

    private void Start()
    {
        _score.text = "-";
    }

    private void OnScoreChanged(float score)
    {
        _score.text = score.ToString();
    }
}
