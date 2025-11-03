using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Drag player here
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Only chase while the game is active
        if (player != null && GameManager.instance.isGameActive)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            navMeshAgent.ResetPath();
        }
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("💀 Player caught by enemy!");
        GameManager.instance.EndGame();
        GameManager.instance.finalScoreText.text =
            "Caught by Enemy!\nScore: " + GameManager.instance.score;
    }
}

}
