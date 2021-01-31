using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageArea : MonoBehaviour
{
    public int damage;
    [SerializeField] private List<GameObject> hitEnemies;
    private GameObject hitEnemy;
    private enemy hitEnemyScript;

    public float lifespan;

    private void Start()
    {
        hitEnemies = new List<GameObject>();

        StartCoroutine("DestroySelf");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitEnemy = collision.gameObject;
        if (hitEnemy.tag == "Enemy")
        {
            if (!hitEnemies.Contains(hitEnemy))
            {
                hitEnemyScript = hitEnemy.GetComponent<enemy>();
                hitEnemyScript.TakeDamage(damage);

                hitEnemies.Add(hitEnemy);
            }
        }
    }

    IEnumerator DestroySelf()
    {
        float startTime = Time.time;
        while (Time.time - startTime <= lifespan)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
