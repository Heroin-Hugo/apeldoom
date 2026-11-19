using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    [SerializeField] private bool hasPrimaryEquipped = true;
    [SerializeField] private GameObject primaryWeapon;
    [SerializeField] private GameObject secondaryWeapon;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hasPrimaryEquipped = true;
            primaryWeapon.SetActive(true);
            secondaryWeapon.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hasPrimaryEquipped = false;
            primaryWeapon.SetActive(false);
            secondaryWeapon.SetActive(true);
        }
    }
}
