using UnityEngine;

// Custome component with field checking if the object is colliding other objects
public class CustomeComponent : MonoBehaviour
{
    public bool isCollide = false;
}

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
