using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealth;

    [Header("JUICE")]
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private GameObject dieParticle;
    [SerializeField] private AudioSource dieSound;
    [SerializeField] private AudioSource[] hitSounds;

    private void Die()
    {
        AudioSource.PlayClipAtPoint(dieSound.clip, transform.position);
        Instantiate(dieParticle, transform.position, Quaternion.identity);
        WinGame.instance.AddKill();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage, Vector3 hitPoint)
    {
        enemyHealth -= damage;

        if(hitParticle != null) Instantiate(hitParticle, hitPoint, Quaternion.identity);

        int random = Random.Range(0, hitSounds.Length);
        hitSounds[random].Play();

        if (enemyHealth <= 0) Die();
    }
}
