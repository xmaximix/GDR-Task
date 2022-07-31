using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent OnCoinCollected = new UnityEvent();
    public static UnityEvent OnAllCoinsCollected = new UnityEvent();
    public static UnityEvent OnPlayerDied = new UnityEvent();

    public static void SendPlayerDied()
    {
        OnPlayerDied.Invoke();
        Pause.PauseGame();
    }

    public static void SendCoinCollected()
    {
        OnCoinCollected.Invoke();
    }

    public static void SendAllCoinsCollected()
    {
        OnAllCoinsCollected.Invoke();
        Pause.PauseGame();
    }
}
