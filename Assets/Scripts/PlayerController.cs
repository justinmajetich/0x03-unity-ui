using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public int health = 5;
    public Text scoreText;

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

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    void SetScoreText()
    {
        scoreText.text = $"Score: {score.ToString()}";
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Pickup":  // On collision with coin
                score++;
                Destroy(other.gameObject);
                SetScoreText();
                break;

            case "Trap":  // On collision with trap
                health--;
                Debug.Log($"Health: {health}");
                break;

            case "Goal":  // On collision with goal
                Debug.Log("You win!");
                break;

            default:
                Debug.Log("Unknown trigger.");
                break;
        }
    }
}
