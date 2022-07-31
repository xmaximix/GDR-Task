using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public static Camera cam;

    [SerializeField] Spawner spawner;

    [SerializeField] Player player;

    [SerializeField] int coinsAmount;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] int spikesAmount;
    [SerializeField] GameObject spikePrefab;

    [SerializeField] TextMeshProUGUI currentCoinsText;
    private int currentCoins;
    private int coinsLeft;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        EventManager.OnCoinCollected.AddListener(CoinCollected);
        InitLevel();
        SetCoinsText();
    }

    private void SetCoinsText()
    {
        coinsLeft = coinsAmount;
        currentCoinsText.text = "Coins " + currentCoins;
    }

    private void InitLevel()
    {
        spawner.Spawn(player.gameObject, 1);
        spawner.Spawn(coinPrefab, coinsAmount);
        spawner.Spawn(spikePrefab, spikesAmount);
    }

    private void CoinCollected()
    {
        coinsLeft--;
        if (coinsLeft <= 0)
        {
            coinsLeft = 0;
            EventManager.SendAllCoinsCollected();
        }

        IncreaseCoinsCount();
    }

    private void IncreaseCoinsCount()
    {
        currentCoins++;
        currentCoinsText.text = "Coins " + currentCoins;
    }
}
