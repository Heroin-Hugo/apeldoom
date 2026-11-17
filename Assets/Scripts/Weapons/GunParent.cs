using System;
using UnityEngine;

public class GunParent : MonoBehaviour
{
    [SerializeField] protected float weaponDamage;
    [SerializeField] protected float weaponRange;
    [Space]
    [SerializeField] protected Transform fpsCam;
    [SerializeField] protected LayerMask hitLayers;

    [Header("Juice")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected AudioSource hitSound;
    [SerializeField] protected AudioSource shootSound;
    [Space]
    [SerializeField] private PoolCue cue;

    private int shoot = Animator.StringToHash("Shoot");
    private int holster = Animator.StringToHash("Holster");


    private void Start()
    {
    }

    protected void Shoot()
    {
        animator.SetTrigger("Shoot");

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.position, fpsCam.forward, out hit, weaponRange, hitLayers))
        {
            shootSound.Play();
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if(enemy != null)
            {
                if (cue != null) cue.SuperNova();

                hitSound.pitch = UnityEngine.Random.Range(0.9f, 1.1f);

                hitSound.Play();
                enemy.TakeDamage(weaponDamage, hit.point);
            }
        }
    }

    public void PlayerDeath()
    {
        cue.enabled = false;
        animator.SetTrigger("Holster");
    }
}
