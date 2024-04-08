using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Utils
{
    public static void LoseRound(TMP_Text text, Button restartBtn, GameObject startGamePanel, GameObject player)
    {
        EnemySpawner.coroutineQueue.Clear();
        Debug.Log(EnemySpawner.coroutineQueue.Count);
        text.text = "Lose";
        text.color = Color.red;
        restartBtn.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        startGamePanel.gameObject.SetActive(true);
    }

    public static void WinRound(TMP_Text text, Button nextRoundBtn, GameObject startGamePanel, GameObject player, Button restartBtn)
    {
        text.color = Color.green;
        startGamePanel.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        if(EnemySpawner.currentRound < 3)
        {
            text.text = "Victory";
            nextRoundBtn.gameObject.SetActive(true);
            text.fontSize = 34;
        }
        else
        {
            restartBtn.gameObject.SetActive(true);
            text.text = "You won the last round";
        }
        text.gameObject.SetActive(true);
    }

}

