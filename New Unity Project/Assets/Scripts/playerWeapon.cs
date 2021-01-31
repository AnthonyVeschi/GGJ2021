using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon : MonoBehaviour
{
    private weapon currentWeapon;

    public weapon _sword;

    public GameObject swordPrefab;
    public GameObject slashPrefab;

    public LayerMask weaponMask;
    public float pickUpRadius;

    private GameObject droppedWeapon;

    private weaponType weaponType;

    private void Start()
    {
        _sword = new sword();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Equip"))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickUpRadius, weaponMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                GameObject thisObject = colliders[i].gameObject;
                if (thisObject.tag == "Weapon")
                {
                    if (currentWeapon != null)
                    {
                        DropWeapon();
                    }
                    EquipWeapon(thisObject);
                    break;
                }
            }
        }

        if (Input.GetButtonDown("Attack"))
        {
            if (currentWeapon != null)
            {
                currentWeapon.Fire();
            }
        }
    }

    private void DropWeapon()
    {
        if (currentWeapon == _sword) { droppedWeapon = Instantiate(swordPrefab, transform); }
        currentWeapon = null;
    }

    private void EquipWeapon(GameObject thisWeapon)
    {
        weaponType = thisWeapon.GetComponent<weaponType>();
        switch (weaponType.GetWeaponType())
        {
            case weaponType.WeaponType.Sword:
                currentWeapon = _sword;
                break;
        }
    }
}
