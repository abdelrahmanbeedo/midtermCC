using UnityEngine;

public class camerascript : MonoBehaviour
{
    public float speed = 10f;
    public Transform focus;

    void Update()
    {
        if (focus != null)
            transform.LookAt(focus);

        transform.RotateAround(focus.position, Vector3.up, speed * Time.deltaTime);
    }
}

//rotating camera for the main menu