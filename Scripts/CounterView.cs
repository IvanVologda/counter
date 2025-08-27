using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        _counter.OnValueChanged += UpdateView;
    }

    private void OnDisable()
    {
        _counter.OnValueChanged -= UpdateView;
    }

    private void UpdateView(int currentValue)
    {
        _counterText.text = currentValue.ToString();
    }
}
