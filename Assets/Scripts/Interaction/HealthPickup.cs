using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private GameObject healParticle;
    [SerializeField] private float healing;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();

        if(player != null)
        {
            if (healParticle != null) Instantiate(healParticle, transform.position, Quaternion.identity);
            player.Heal(healing);
            Destroy(gameObject);
        }
    }
}
