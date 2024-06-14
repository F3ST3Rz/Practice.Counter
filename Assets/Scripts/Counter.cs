using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _step = 0.5f;
    [SerializeField] private KeyCode _keyScore = KeyCode.Mouse0;

    private float _count = 0f;
    private bool _isStart = false;

    public event Action<float> ScoreChanged;

    private void Update()
    {
        if (Input.GetKeyUp(_keyScore))
        {
            _isStart = !_isStart;

            if (_isStart)
            {
                StartCoroutine(Score());
            }
            else
            {
                StopCoroutine(Score());
            }
        }
    }

    private IEnumerator Score()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isStart)
        {
            yield return wait;
            _count += _step;
            ScoreChanged?.Invoke(_count);
        }
    }
}
