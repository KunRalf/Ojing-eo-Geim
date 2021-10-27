using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventService : MonoBehaviour
{
    public event Action OnStart;
    public void ToStart()
    {
        OnStart?.Invoke();
    }
}
