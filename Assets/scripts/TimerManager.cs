using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float levelTime = 60f; // total game time in seconds
    public TMP_Text timerText;

    private float timeLeft;

    void Start()
    {
        timeLeft = levelTime;
        UpdateTimerUI();
    }

    void Update()
    {
        if (!GameManager.instance.isGameActive) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            UpdateTimerUI();
            GameManager.instance.EndGame();
        }
        else
        {
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(timeLeft);
            timerText.text = "Time: " + seconds.ToString();
        }
    }
}
