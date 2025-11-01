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
        // pass color name + position to GameManager
        GameManager.instance.CollectItem(colorName, transform.position);
        Destroy(gameObject);
    }
}
}
