using System;
using UnityEngine;

public class MemorySystemTriggerTest : MonoBehaviour
{
    public static event Action<int> OnTriggerEnter;
    
    public void OnClick0()
    {
        OnTriggerEnter?.Invoke(0);
    }
    public void OnClick1()
    {
        OnTriggerEnter?.Invoke(1);
    }
}
