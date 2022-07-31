using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI GameEndText;
    [SerializeField] GameObject gameEndPanel;
    [SerializeField] Button restartButton;

    private void Start()
    {
        EventManager.OnAllCoinsCollected.AddListener(RenderWinScreen);
        EventManager.OnPlayerDied.AddListener(RenderLoseScreen);

        restartButton.onClick.AddListener(RestartGame);
    }

    private void RenderWinScreen()
    {
        gameEndPanel.SetActive(true);
        GameEndText.text = "You Win!";
    }

    private void RenderLoseScreen()
    {
        gameEndPanel.SetActive(true);
        GameEndText.text = "Game Over";
    }

    private void RestartGame()
    {
        Pause.UnpauseGame();
        SceneManager.LoadScene(0);
    }
}
