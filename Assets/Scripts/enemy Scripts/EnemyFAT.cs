using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFAT : rangeEnemy
{
    public float bulletDeviation;
    public float bulletElevation = 0;

    public override void Shoot()
    {
        float rand = Random.Range(-bulletDeviation, bulletDeviation);
        var _bullet = Instantiate(bullet, bulletSpawnPoint.transform.position, gameObject.transform.rotation);
        _bullet.transform.Rotate(bulletElevation, rand, 0);
        return;
    }
}
