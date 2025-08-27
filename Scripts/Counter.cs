using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _startValue = 0;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _interval = 0.5f;
    [SerializeField] private int _addedValue = 1;

    private int _currentValue;
    private Coroutine _coroutine;
    private bool _isCount = false;
    private WaitForSeconds _wait;

    public event Action<int> OnValueChanged;

    private void Start()
    {
        _currentValue = _startValue;
        _wait = new WaitForSeconds(_interval);
        OnValueChanged?.Invoke(_currentValue);
    }

    private void OnEnable()
    {
        _inputReader.MouseCkicked += ToggleCounter;
    }

    private void OnDisable()
    {
        _inputReader.MouseCkicked -= ToggleCounter;
    }

    private void ToggleCounter()
    {
        if (_isCount)
        {
            _isCount = false;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
        else
        {
            _isCount = true;
            _coroutine = StartCoroutine(IncreaseValue());
        }
    }

    private IEnumerator IncreaseValue()
    {
        while (_isCount)
        {
            _currentValue += _addedValue;
            OnValueChanged?.Invoke(_currentValue);

            yield return _wait;
        }

    }
}