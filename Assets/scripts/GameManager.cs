using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text targetColorText;
    public GameObject gameOverPanel; // assign panel (inactive by default)
    public TMP_Text finalScoreText; // inside Game Over panel

    [Header("Gameplay")]
    public int score = 0;
    public Material[] colorMaterials;

    [Header("VFX & Floating Text")]
    public GameObject collectParticlePrefab; // particle prefab (optional)
    public GameObject floatingTextPrefab; // floating TMP prefab (optional)

    [HideInInspector]
    public bool isGameActive = true;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    // Called by Collectible when player picks it up
    // collectedName = "red"/"blue"/etc, pos = world position of collectible
    public void CollectItem(string collectedName, Vector3 pos)
    {
        if (!isGameActive) return;

        string targetName = targetColorText.text.ToLower().Replace("target: ", "").Trim();

        int delta = 0;
        if (collectedName == targetName)
        {
            delta = 10;
            score += 10;
            Debug.Log("✅ Correct color: " + collectedName);
        }
        else
        {
            delta = -5;
            score -= 5;
            Debug.Log("❌ Wrong color: " + collectedName);
        }

        UpdateScoreUI();

        // spawn particle (if assigned)
        if (collectParticlePrefab != null)
        {
            GameObject p = Instantiate(collectParticlePrefab, pos, Quaternion.identity);
            // try to tint particle main color if it has ParticleSystem
            var ps = p.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                var main = ps.main;
                // find material color from name
                Color c = GetColorByName(collectedName);
                main.startColor = c;
            }

            Destroy(p, 2f); // auto cleanup
        }

        // spawn floating text (if assigned)
        if (floatingTextPrefab != null)
        {
            GameObject ft = Instantiate(floatingTextPrefab, pos + Vector3.up * 0.5f, Quaternion.identity);
            var ftComp = ft.GetComponent<FloatingText>();
            if (ftComp != null) ftComp.Show((delta>0? "+"+delta.ToString(): delta.ToString()), delta>0);
            Destroy(ft, 2.5f);
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score.ToString();
    }

    // utility: find color in materials by cleaned name (red/blue/green)
    Color GetColorByName(string name)
    {
        string cleaned = name.ToLower().Trim();
        foreach (var m in colorMaterials)
        {
            string mn = m.name.ToLower().Replace("pickup_", "").Trim();
            if (mn == cleaned) return m.color;
        }
        return Color.white;
    }

    // Change the target manually (used by TargetColorChanger)
    public void SetTargetByIndex(int index)
    {
        if (index < 0 || index >= colorMaterials.Length) return;
        targetColorText.text = "Target: " + colorMaterials[index].name.ToLower().Replace("pickup_", "").Trim();
        targetColorText.color = colorMaterials[index].color;
    }

    // Call this to end the game
public void EndGame()
{
    Debug.Log("EndGame() called!");

    isGameActive = false;

    if (gameOverPanel != null)
    {
        gameOverPanel.SetActive(true);
        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + score.ToString();
    }
    else
    {
        Debug.LogWarning("GameOverPanel not assigned in Inspector!");
    }

    Time.timeScale = 0f;
}


    // Optional retry button action (assign to Button OnClick)
    public void RetryScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
