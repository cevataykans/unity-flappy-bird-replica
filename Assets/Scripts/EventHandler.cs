using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{
    public static event Action OnBirdDied;
    public static event Action OnBirdScore;
    public static event Action OnGameStart;

    public static void TriggerOnBirdDied()
    {
        OnBirdDied?.Invoke();
    }

    public static void TriggerOnBirdScore()
    {
        OnBirdScore?.Invoke();
    }

    public static void TriggerOnGameStart()
    {
        OnGameStart?.Invoke();
    }
}
