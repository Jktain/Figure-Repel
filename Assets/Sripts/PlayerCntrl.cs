using UnityEngine.UI;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    //private int bufsCount = 0;
    public Text Score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Jump");

        rb.velocity = transform.TransformDirection(new Vector3(h, z, v) * speed * Time.fixedDeltaTime);
        Physics.gravity = new Vector3(0, -9.81f * 15, 0);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "buf")
    //    {
    //        bufsCount++;
    //        if (bufsCount < 7)
    //            Score.text = "Score: " + bufsCount;
    //        else
    //            Score.text = "You won";
    //        Destroy(other.gameObject);
    //    }
    //}
}
