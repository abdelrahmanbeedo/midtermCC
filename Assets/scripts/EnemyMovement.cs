using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null && GameManager.instance.isGameActive)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("💀 Player caught by enemy logic triggered!");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Enemy confirmed player collision!");
            GameManager.instance.EndGame();
            GameManager.instance.finalScoreText.text =
                "Caught by Enemy!\nScore: " + GameManager.instance.score;
        }
    }
}
