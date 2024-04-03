using UnityEngine;

public class CapsuleEnemy : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        EnemySpawner.trigger2 = 1;

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
