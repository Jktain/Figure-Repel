using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{

    public float speed;

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Jump");

        GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(h, z, v) * speed * Time.fixedDeltaTime);

        // Increasing gravity to make player fall quicklier
        Physics.gravity = new Vector3(0, -9.81f * 15, 0);
    }
}
