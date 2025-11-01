using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public TMP_Text scoreText;

    private Rigidbody rb;
    private Vector2 inputMovement;
    private int scoreCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent rolling
        scoreCounter = 0;
        scoreText.text = "Score: " + scoreCounter;
    }

    public void OnMove(InputValue value)
    {
        inputMovement = value.Get<Vector2>();
    }

    void FixedUpdate()
{
Vector3 movement = transform.right * inputMovement.x + transform.forward * inputMovement.y;
rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

}
}
