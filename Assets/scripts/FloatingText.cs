using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public TMP_Text tmp;
    public float moveSpeed = 0.8f;
    public float fadeSpeed = 1.2f;

    void Awake()
    {
        if (tmp == null)
            tmp = GetComponentInChildren<TMP_Text>();
    }

    public void Show(string text, bool positive)
    {
        if (tmp != null)
        {
            tmp.text = text;
            tmp.color = positive ? Color.green : Color.red;
        }
    }

    void Update()
    {
        // Move upward
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // Fade out
        if (tmp != null)
        {
            Color c = tmp.color;
            c.a -= fadeSpeed * Time.deltaTime;
            tmp.color = c;
            if (c.a <= 0f) Destroy(gameObject);
        }
    }
}
