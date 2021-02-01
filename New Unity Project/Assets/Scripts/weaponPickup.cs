using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
    public enum WeaponType { Sword, Gun }
    public WeaponType type;

    public WeaponType GetWeaponType()
    {
        return type;
    }
}
