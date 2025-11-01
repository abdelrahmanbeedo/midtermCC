using UnityEngine;

public class TargetColorChanger : MonoBehaviour
{
    public float changeInterval = 5f;
    private float timer = 0f;

    void Start()
    {
        // pick first target at start
        ChooseRandomTarget();
    }

    void Update()
    {
        if (!GameManager.instance.isGameActive) return;

        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            timer = 0f;
            ChooseRandomTarget();
        }
    }

    void ChooseRandomTarget()
    {
        if (GameManager.instance == null || GameManager.instance.colorMaterials.Length == 0) return;

        int idx = Random.Range(0, GameManager.instance.colorMaterials.Length);
        GameManager.instance.SetTargetByIndex(idx);
    }
}
