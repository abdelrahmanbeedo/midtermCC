using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string colorName; // store the name directly
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectItem(colorName);
            Destroy(gameObject);
        }
    }
}
