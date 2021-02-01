using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon : MonoBehaviour
{
    private weapon currentWeapon;

    public weapon _sword;
    public weapon _gun;

    public GameObject swordPrefab;
    public GameObject slashPrefab;
    public GameObject gunPrefab;
    public GameObject bulletPrefab;

    public LayerMask weaponMask;
    public float pickUpRadius;

    private GameObject droppedWeapon;

    private weaponPickup weaponPickup;

    public float swordCooldown;
    public bool swordOnCooldown = false;
    private float swordCooldownProgress;
    public float gunCooldown;
    public bool gunOnCooldown = false;
    private float gunCooldownProgress;

    private void Start()
    {
        _sword = new sword();
        _sword.Init();

        _gun = new gun();
        _gun.Init();
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
                if (currentWeapon == _sword && !swordOnCooldown) 
                { 
                    currentWeapon.Fire();
                    StartSwordCooldown();
                }
                if (currentWeapon == _gun && !gunOnCooldown)
                {
                    currentWeapon.Fire();
                    StartGunCooldown();
                }
            }
        }
    }

    private void DropWeapon()
    {
        if (currentWeapon == _sword) { droppedWeapon = Instantiate(swordPrefab, transform.position, Quaternion.identity); }
        if (currentWeapon == _gun) { droppedWeapon = Instantiate(gunPrefab, transform.position, Quaternion.identity); }
        currentWeapon = null;
    }

    private void EquipWeapon(GameObject thisWeapon)
    {
        weaponPickup = thisWeapon.GetComponent<weaponPickup>();
        switch (weaponPickup.GetWeaponType())
        {
            case weaponPickup.WeaponType.Sword:
                currentWeapon = _sword;
                break;

            case weaponPickup.WeaponType.Gun:
                currentWeapon = _gun;
                break;
        }
        Destroy(thisWeapon);
    }

    private void StartSwordCooldown()
    {
        swordOnCooldown = true;
        StartCoroutine("SwordCooldown");
    }
    IEnumerator SwordCooldown()
    {
        float startTime = Time.time;
        while (Time.time - startTime <= swordCooldown)
        {
            swordCooldownProgress = (Time.time - startTime) / swordCooldown;
            yield return null;
        }
        swordCooldownProgress = 1;
        swordOnCooldown = false;
    }

    private void StartGunCooldown()
    {
        gunOnCooldown = true;
        StartCoroutine("GunCooldown");
    }
    IEnumerator GunCooldown()
    {
        float startTime = Time.time;
        while (Time.time - startTime <= gunCooldown)
        {
            gunCooldownProgress = (Time.time - startTime) / gunCooldown;
            yield return null;
        }
        gunCooldownProgress = 1;
        gunOnCooldown = false;
    }
}
