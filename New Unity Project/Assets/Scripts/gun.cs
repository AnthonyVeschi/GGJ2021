using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : weapon
{
    private GameObject bullet;
    private Rigidbody2D rb;
    private Transform bulletTransform;

    private float force = 20;
    private Vector2 forceVector;

    public override void Init()
    {
        player = GameObject.Find("Player");
        pw = player.GetComponent<playerWeapon>();
        bulletTransform = player.transform.Find("BulletTransform");
    }

    public override void Fire()
    {
        forceVector = Input.mousePosition;
        forceVector = Camera.main.ScreenToWorldPoint(forceVector);
        forceVector -= (Vector2)bulletTransform.position;
        forceVector.Normalize();
        forceVector *= force;

        bullet = GameObject.Instantiate(pw.bulletPrefab, bulletTransform.position, Quaternion.identity);
        rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(forceVector, ForceMode2D.Impulse);
    }
}
