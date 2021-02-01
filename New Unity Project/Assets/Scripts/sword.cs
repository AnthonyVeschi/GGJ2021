using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : weapon
{
    private GameObject slash;
    private Transform slashTransform;

    public override void Init()
    {
        player = GameObject.Find("Player");
        pw = player.GetComponent<playerWeapon>();
        slashTransform = player.transform.Find("SlashTransform");
    }

    public override void Fire()
    {
        slash = GameObject.Instantiate(pw.slashPrefab, slashTransform);
    }
}
