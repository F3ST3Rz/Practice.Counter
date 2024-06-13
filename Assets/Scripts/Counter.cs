using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _step = 0.5f;

    private float _count = 0f;
    private bool _isStart = false;
    private Coroutine _coroutine;

    public event Action<float> ScoreChanged;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            _isStart = !_isStart;

            if(_coroutine != null)
                return;

            _coroutine = StartCoroutine(Scoring());
        }
    }

    private IEnumerator Scoring()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isStart)
        {
            yield return wait;
            _count += _step;
            ScoreChanged?.Invoke(_count);
        }

        _coroutine = null;
    }
}
