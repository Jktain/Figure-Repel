using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gates")
        {
            Debug.Log(gameObject.GetComponent<CustomeComponent>().isCollide = true);
            EnemySpawner.defeat = true;
        }
        else
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.GetComponent<CustomeComponent>().isCollide = true);
        }
    }
}
