using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponType : MonoBehaviour
{
    public enum WeaponType { Sword }
    public WeaponType type;

    public WeaponType GetWeaponType()
    {
        return type;
    }
}
