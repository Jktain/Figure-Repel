using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        EnemySpawner.trigger1 = 1;

        if (collision.gameObject.tag == "Gates")
        {
            EnemySpawner.defeat = true;
            Destroy(gameObject);
        } 
        else
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        //EnemySpawner.trigger = 0;
    }
}
