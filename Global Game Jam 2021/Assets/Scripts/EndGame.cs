using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [Header("Components")]
    public GameObject endGameScreen;
    public Text endGameText;
    public Text endScore;
    public Text endTurns;

    [Header("Values")]
    public Color winColor;
    public Color lossColor;

    public void ShowEndScreen(int score, int total, int turns)
    {
        // Only open if end game screen is not active
        if (endGameScreen.activeSelf)
            return;

        GameManager.instance.PauseGame();
        endGameScreen.SetActive(true);
        if (score == total)
        {
            endGameText.text = "Data Restored";
            endGameText.color = winColor;
        }
        else
        {
            endGameText.text = "Segmentation Fault";
            endGameText.color = lossColor;
        }

        endScore.text = score.ToString() + " / " + total.ToString();
        endTurns.text = turns.ToString();
    }
}
