using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseCkicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseCkicked?.Invoke();
        }
    }
}