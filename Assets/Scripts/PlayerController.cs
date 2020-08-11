using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    private float xForce = 0;
    private float zForce = 0;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Fixed-update is called once physics refresh
    void FixedUpdate()
    {
        // Take force applied against horizontal axis (i.e left/right, a/d)
        xForce = Input.GetAxis("Horizontal") * speed;
        // Take force applied against vertical axis (i.e forward/backward, w/s)
        zForce = Input.GetAxis("Vertical") * speed;

        // Apply force to player rigidbody
        rb.AddForce(xForce, 0, zForce); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
    }
}
