using UnityEngine;
using System.Collections;

public class Pistol : GunParent
{
    [SerializeField] private int maxAmmo;
    private int currentAmmo;

    [Header("Reloading")]
    [SerializeField] private float reloadTime;
    [SerializeField] private bool isReloading = true;
    private float timeSinceLastFire;
    [SerializeField] private float fireRate;

    private int reloading = Animator.StringToHash("Reloading");

    Coroutine reload;


    private void Update()
    {
        if (currentAmmo < maxAmmo && Input.GetKeyDown(KeyCode.R) || currentAmmo <= 0) reload = StartCoroutine(ReloadWeapon());

        if(Input.GetKey(KeyCode.Mouse0) && timeSinceLastFire > fireRate)
        {
            Shoot();
            timeSinceLastFire = 0;
            currentAmmo--;
        }
        timeSinceLastFire += Time.deltaTime;
    }

    private IEnumerator ReloadWeapon()
    {
        isReloading = true;

        animator.SetBool(reloading, true);

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;

        animator.SetBool(reloading, false);

        isReloading = false;    

    }
}
