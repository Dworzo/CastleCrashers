using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedFAT : rangeEnemy
{
    public float bulletDeviation;

    public override void Shoot()
    {
        float rand = Random.Range(-bulletDeviation, bulletDeviation);
        var _bullet = Instantiate(bullet, bulletSpawnPoint.transform.position, gameObject.transform.rotation);
        _bullet.transform.Rotate(0, rand, rand);
        return;
    }
}
