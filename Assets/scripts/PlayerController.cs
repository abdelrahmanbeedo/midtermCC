using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public TMP_Text scoreText;
    public Transform model;

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

if (movement.magnitude > 0.1f)
{
    // Figure out which way the player is moving
    float angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;

    // Make only the model rotate visually
    Quaternion currentRotation = model.localRotation;
    Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
    model.localRotation = Quaternion.Slerp(currentRotation, targetRotation, 10f * Time.deltaTime);

}
}
}
