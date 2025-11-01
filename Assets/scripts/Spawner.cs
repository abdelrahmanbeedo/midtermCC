using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public Material[] materials;
    public int collectibleCount = 10;
    public float spawnRange = 6f;

    void Start()
    {
        for (int i = 0; i < collectibleCount; i++)
        {
            Vector3 pos = new Vector3(
                transform.position.x + Random.Range(-spawnRange, spawnRange),
                transform.position.y + 0.6f,
                transform.position.z + Random.Range(-spawnRange, spawnRange)
            );

            GameObject c = Instantiate(collectiblePrefab, pos, Quaternion.identity);
            Renderer rend = c.GetComponent<Renderer>();
Collectible col = c.GetComponent<Collectible>();

if (rend != null && materials.Length > 0 && col != null)
{
    int randomIndex = Random.Range(0, materials.Length);
    rend.sharedMaterial = materials[randomIndex];

    // Store color name cleanly (lowercase, no spaces)
    col.colorName = materials[randomIndex].name.ToLower().Replace("pickup_", "").Trim();
}
        }
    }
}