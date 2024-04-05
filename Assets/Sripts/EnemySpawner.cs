using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomeComponent : MonoBehaviour
{
    public bool isCollide = false;
}

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyCube;
    public GameObject enemyCapsule;
    public GameObject enemies;
    public TMP_Text text;
    public Button startBtn;
    public Button restartBtn;
    public Button nextRoundBtn;
    public GameObject startGamePanel;
    public static EnemySpawner instance;
    public static int currentRound = 1;
    public float enemySpeed;
    public static bool defeat;

    public Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {

    }

    public void LoseRound()
    {
        StopAllCoroutines();
        coroutineQueue.Clear();
        Debug.Log(coroutineQueue.Count);
        text.text = "Lose";
        text.color = Color.red;
        restartBtn.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        startGamePanel.gameObject.SetActive(true);
    }

    public void WinRound()
    {
        text.text = "Victory";
        text.color = Color.green;
        nextRoundBtn.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        startGamePanel.gameObject.SetActive(true);
    }

    // Виконати корутини в черзі
    private IEnumerator CoroutineDeQueue(float period, int round)
    {
        yield return new WaitForSeconds(1f);
        while (coroutineQueue.Count > 0 && defeat == false)
        {
            if (round > 1)
            {
                StartCoroutine(coroutineQueue.Dequeue());
                yield return new WaitForSeconds(period);
            }
            yield return StartCoroutine(coroutineQueue.Dequeue());
        }

        WinRound();
    }

    private IEnumerator CoroutineSpawnEnemy(float speed, GameObject prefab, GameObject parent)
    {
        GameObject enemy = Instantiate(prefab, RanPos(), RanRot(), parent.transform);
        enemy.AddComponent<CustomeComponent>();

        Vector3 target = new Vector3(Random.Range(1.5f, 8.5f), Random.Range(0.9f, 3f), -14.2f);

        while (enemy.GetComponent<CustomeComponent>().isCollide == false)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, Time.deltaTime * speed);

            yield return null;
        }

        if (defeat)
            LoseRound();
    }

    private Vector3 RanPos()
    {
        return new Vector3(Random.Range(-7f, 17f), Random.Range(2f, 5f), Random.Range(-6f, 4f));
    }

    private Quaternion RanRot()
    {
        return Quaternion.Euler(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));
    }

    public void StartRound()
    {
        switch (currentRound)
        {
            case 1:
                Round1();
                break;
            case 2:
                Round2();
                break;
            case 3:
                Round1();
                break;
        }
    }

    public void Round1()
    {
        GameObject enemiesParent = Instantiate(enemies, Vector3.zero, Quaternion.identity);

        defeat = false;

        for (int i = 0; i < 4; i++)
        {
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed, enemyCube, enemiesParent));
        }

        StartCoroutine(CoroutineDeQueue(1f, 1));
    }

    public void Round2()
    {
        GameObject enemiesParent = Instantiate(enemies, Vector3.zero, Quaternion.identity);

        defeat = false;

        for (int i = 0; i < 4; i++)
        {
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed, enemyCube, enemiesParent));
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed * 1.5f, enemyCapsule, enemiesParent));
        }

        StartCoroutine(CoroutineDeQueue(1f, 2));
    }

    public void Round3()
    {
        GameObject enemiesParent = Instantiate(enemies, Vector3.zero, Quaternion.identity);

        defeat = false;

        for (int i = 0; i < 4; i++)
        {
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed * 1.3f, enemyCube, enemiesParent));
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed * 1.3f, enemyCapsule, enemiesParent));
        }

        StartCoroutine(CoroutineDeQueue(0f, 3));
    }

}
