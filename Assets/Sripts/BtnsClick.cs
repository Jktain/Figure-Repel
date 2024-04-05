using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtnsClick : MonoBehaviour
{
    public Button startBtn;
    public Button restartBtn;
    public Button nextRoundBtn;
    public GameObject startGamePanel;
    public TextMeshProUGUI text;

    public void FirstRound()
    {
        startBtn.gameObject.SetActive(false);
        startGamePanel.gameObject.SetActive(false);
    }

    public void RestartRound()
    {
        restartBtn.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        startGamePanel.gameObject.SetActive(false);
    }

    public void NextRound()
    {
        nextRoundBtn.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        startGamePanel.gameObject.SetActive(false);
        EnemySpawner.currentRound++;
    }
}
