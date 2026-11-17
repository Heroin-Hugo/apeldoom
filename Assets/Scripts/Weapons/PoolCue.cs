using UnityEngine;
using System;

public class PoolCue : GunParent
{
    [Space]
    [SerializeField] private GameObject supernova;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    public void SuperNova()
    {
        supernova.SetActive(true);
        Invoke(nameof(ResetSupernova), 0.2f);
    }

    private void ResetSupernova() => supernova.SetActive(false);
}
