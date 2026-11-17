using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealth;

    [Header("JUICE")]
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private AudioSource[] hitSounds;

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage, Vector3 hitPoint)
    {
        enemyHealth -= damage;

        Instantiate(hitParticle, hitPoint, Quaternion.identity);

        int random = Random.Range(0, hitSounds.Length);
        hitSounds[random].Play();

        if (enemyHealth <= 0) Die();
    }
}
