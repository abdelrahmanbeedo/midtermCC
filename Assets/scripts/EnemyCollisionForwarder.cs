using UnityEngine;

public class EnemyCollisionForwarder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<EnemyMovement>()?.OnTriggerEnter(other);
    }
}
