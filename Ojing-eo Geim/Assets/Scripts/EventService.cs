﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventService : MonoBehaviour
{
    public static EventService Instance { get; private set; }
    private EventService()
    {
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public event Action OnStart;
    public event Action OnRandomValue;
    public event Action OnMove;
    public event Action OnWin;
    public event Action OnLose;

    public void CallOnWin()
    {
        OnWin?.Invoke();
    }
    public void CallOnLose()
    {
        OnLose?.Invoke();
    }

    public void ToMove()
    {
        OnMove?.Invoke();
    }

    public void SetRandomValue()
    {
        OnRandomValue?.Invoke();
    }

    public void ToStart()
    {
        OnStart?.Invoke();
    }
}
