using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyCube;
    public GameObject enemyCapsule;
    public float enemySpeed;
    public static int trigger1 = 0;
    public static int trigger2 = 0;
    public static bool defeat;
    public static bool isCollideCube;
    public static bool isCollideCapsule;
    private Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            defeat = false;

            for (int i = 0; i < 4; i++)
            {
                coroutineQueue.Enqueue(CoroutineSpawnCube(enemySpeed, enemyCube));
                coroutineQueue.Enqueue(CoroutineSpawnCapsule(enemySpeed * 1.5f));
            }

            StartCoroutine(DeQueue(1f));
        }
    }


    // Виконати корутини в черзі
    private IEnumerator DeQueue(float period)
    {
        while (coroutineQueue.Count > 0 && defeat == false)
        {
            StartCoroutine(coroutineQueue.Dequeue());
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(coroutineQueue.Dequeue());
        }
    }

   
    
   private IEnumerator CoroutineSpawnCube(float speed, GameObject prefab)
   {
        GameObject enemy = Instantiate(prefab, RanPos(), RanRot());
        Vector3 target = new Vector3(Random.Range(1.5f, 8.5f), Random.Range(0.9f, 3f), -14.2f);

        while (trigger1 == 0)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, Time.deltaTime * speed);

            yield return null;
        }

        trigger1 = 0;
   }

    private IEnumerator CoroutineSpawnCapsule(float speed)
    {
        GameObject enemy = Instantiate(enemyCapsule, RanPos(), RanRot());
        Vector3 target = new Vector3(Random.Range(1.5f, 8.5f), Random.Range(0.9f, 3f), -14.2f);

        while (trigger2 == 0)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, Time.deltaTime * speed);

            yield return null;
        }

        trigger2 = 0;
    }

    private Vector3 RanPos()
    {
        return new Vector3(Random.Range(-7f, 17f), Random.Range(2f, 5f), Random.Range(-6f, 4f));
    }

    private Quaternion RanRot()
    {
        return Quaternion.Euler(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));
    }


    /*
        private IEnumerator CoroutineSample()
    {
        int x, z;

        yield return new WaitForSeconds(2f);
        GameObject enemy = Instantiate(cube, RanPos(), RanRot());

        if (enemy.transform.position.x > 5)
            x = -400;
        else
            x = 400;

        if (enemy.transform.position.z < -4)
            z = 400;
        else
            z = -400;

        yield return new WaitForSeconds(2f);

        enemy.GetComponent<Rigidbody>().AddForce(new Vector3(x, 0, z));
    }
   */

    /*
    private IEnumerator CoroutineS1()
    {
        GameObject enemy = Instantiate(cube, RanPos(), RanRot());

        yield return new WaitForSeconds(2f);

        enemy.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, -500));

        //while (enemy.transform.position.x > 5 && enemy.transform.position.z > -4)
        //{
        //    Debug.Log(enemy.transform.position.x + " " + enemy.transform.position.z);
        //    yield return null;
        //}

        //yield return new WaitUntil(() => enemy.transform.position.x < 5 || enemy.transform.position.z < -4); 

        Destroy(enemy.gameObject);
    }
    */

    /*
    private IEnumerator Lerp()
    {
        float t = 0.5f;

        Mathf.Lerp(42, 90, t);
        Vector3.Lerp(transform.position, Vector2.zero, t);

        Quaternion.Lerp(transform.rotation, Quaternion.identity, t);
        Quaternion.Slerp(transform.rotation, Quaternion.identity, t);

        Color.Lerp(Color.cyan, Color.magenta, t);

        GetComponent<MeshRenderer>().sharedMaterial.Lerp(Mat1, Mat2, t);

        yield break;
    }
    */

    /*
   private IEnumerator CoroutineS3()
    {
        GameObject enemy = Instantiate(cube, RanPos(), RanRot());

        yield return StartCoroutine(Utils.MoveToTarget(enemy.transform, new Vector3(1f, 0.55f, -10f)));

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        yield return StartCoroutine(Utils.MoveToTarget(enemy.transform, new Vector3(5f, 0.55f, -2f)));

        yield return new WaitForSeconds(1);

        enemy.GetComponent<Rigidbody>().AddForce(new Vector3(-200, 0, -200));

        yield return new WaitForSeconds(2);

        Debug.Log("Over");
    }
    */

    /*
   private IEnumerator CoroutineS4()
    {
        AsyncOperation op = Resources.LoadAsync<Sprite>("big_image.png");
        yield return op;

        yield return new WaitForKeyDown(KeyCode.Delete);
    }
    */

    /*
      private IEnumerator MoveToTarget(Transform obj, Vector3 target)
   {
       while(obj.position != target)
       {
           obj.position = Vector3.MoveTowards(obj.position, target, Time.deltaTime * 5);
           yield return null;
       }
       Destroy(obj.gameObject);
   }
   */
}
