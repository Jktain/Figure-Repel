using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;

    // enemies prefabs
    public GameObject enemyCube;
    public GameObject enemyCapsule;

    // Canvas objects
    public TMP_Text text;
    public GameObject startGamePanel;
    public Button startBtn;
    public Button restartBtn;
    public Button nextRoundBtn;

    public static bool defeat;
    public static int currentRound = 1;

    // Coroutine queue
    public static Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();

    // Enemy speed movement
    public float enemySpeed;

    // Launching coroutines from queue
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

        if (!defeat)
            RoundExodus.WinRound(text, nextRoundBtn, startGamePanel, player, restartBtn);
    }

    // Spawning enemies, adding to them field "isCollide" and making move to the random place in gates
    private IEnumerator CoroutineSpawnEnemy(float speed, GameObject prefab, float lifeDuration)
    {
        GameObject enemy = Instantiate(prefab, RanPos(), RanRot());

        enemy.AddComponent<CustomeComponent>();

        Vector3 target = new Vector3(Random.Range(1.5f, 8.5f), Random.Range(0.9f, 3f), -14.2f);

        Destroy(enemy, lifeDuration);

        while (enemy.GetComponent<CustomeComponent>().isCollide == false)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, Time.deltaTime * speed);

            yield return null;
        }

        if (defeat)
        {
            StopAllCoroutines();
            RoundExodus.LoseRound(text, restartBtn, startGamePanel, player);
        }
    }

    // Starts one of the following rounds in order to current round
    public void StartRound()
    {
        player.gameObject.SetActive(true);

        switch (currentRound)
        {
            case 1:
                Round1();
                break;
            case 2:
                Round2();
                break;
            case 3:
                Round3();
                break;
        }
    }

    public void Round1()
    {
        defeat = false;

        for (int i = 0; i < 4; i++)
        {
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed, enemyCube, 2.2f));
        }

        StartCoroutine(CoroutineDeQueue(1f, 1));
    }

    public void Round2()
    {
        defeat = false;

        for (int i = 0; i < 4; i++)
        {
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed, enemyCube, 2f));
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed * 1.3f, enemyCapsule, 1.8f));
        }

        StartCoroutine(CoroutineDeQueue(1f, 2));
    }

    public void Round3()
    {
        defeat = false;

        for (int i = 0; i < 4; i++)
        {
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed * 1.2f, enemyCube, 1.8f));
            coroutineQueue.Enqueue(CoroutineSpawnEnemy(enemySpeed * 1.4f, enemyCapsule, 1.8f));
        }

        StartCoroutine(CoroutineDeQueue(0.3f, 3));
    }

    // Randomizer for Instantiate()
    private Vector3 RanPos()
    {
        return new Vector3(Random.Range(-4f, 14f), Random.Range(1.5f, 3.5f), Random.Range(-6f, 4f));
    }

    private Quaternion RanRot()
    {
        return Quaternion.Euler(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));
    }

}
