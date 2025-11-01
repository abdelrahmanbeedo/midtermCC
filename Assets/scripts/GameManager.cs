using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton for easy access

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text targetColorText;

    [Header("Gameplay")]
    public int score = 0;
    public Color targetColor;
    public Material[] colorMaterials;

    void Awake()
    {
        // Make sure there's only one GameManager
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Pick a random color at the start
        int randomIndex = Random.Range(0, colorMaterials.Length);
        targetColor = colorMaterials[randomIndex].color;

        // Display target color text and color
        targetColorText.text = "Target: " + colorMaterials[randomIndex].name.Replace("PickUp_", "");
        targetColorText.color = targetColor;

        UpdateScoreUI();
    }

    public void CollectItem(string collectedName)
{
    // get target name in lowercase
    string targetName = targetColorText.text.ToLower().Replace("target: ", "").Trim();

    if (collectedName == targetName)
    {
        score += 5;
        Debug.Log("✅ Correct color: " + collectedName);
    }
    else
    {
        score -= 15;
        Debug.Log("❌ Wrong color: " + collectedName);
    }

    UpdateScoreUI();
}


    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
