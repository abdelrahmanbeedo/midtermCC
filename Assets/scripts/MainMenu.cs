using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource menuMusic;
    public string gameSceneName = "ColorCatchv2"; // change if different
    public float fadeTime = 2f;

    public void StartGame()
    {
        StartCoroutine(FadeOutMusicAndLoad());
    }

    public void QuitGame()
    {
        // In editor, this won't quit; works in built exe
        Application.Quit();
    }

    private System.Collections.IEnumerator FadeOutMusicAndLoad()
    {
        if (menuMusic != null)
        {
            float startVol = menuMusic.volume;
            float t = 0f;
            while (t < fadeTime)
            {
                t += Time.unscaledDeltaTime;
                menuMusic.volume = Mathf.Lerp(startVol, 0f, t / fadeTime);
                yield return null;
            }
            menuMusic.Stop();
        }

        // Load game scene (by name). Game scene should be in Build Settings.
        SceneManager.LoadScene(gameSceneName);
    }
}
