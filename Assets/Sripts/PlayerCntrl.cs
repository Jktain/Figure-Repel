using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{

    public float speed;

    private void FixedUpdate()
    {
        // Player`s moving 
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Jump");

        GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(h, z, v) * speed * Time.fixedDeltaTime);

        // Increasing gravity to make player fall quicklier
        Physics.gravity = new Vector3(0, -9.81f * 15, 0);
    }

    // Using keys to resize screen
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Screen.SetResolution(1200, 500, false);
        if (Input.GetKey(KeyCode.Alpha2))
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }
}
