using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject endGameScreen;
    public Text endGameText;

    public void ShowEndScreen(bool win)
    {
        // Only open if end game screen is not active
        if (endGameScreen.activeSelf)
            return;

        GameManager.instance.PauseGame();
        endGameScreen.SetActive(true);
        if (win)
            endGameText.text = "Data Restored";
        else
            endGameText.text = "Segmentation Fault";
    }
}
