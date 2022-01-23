using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySILVER : rangeEnemy
{
    public static int NumberOfBullets = 5;
    public static float Deviation = 12;
    private float Rotation;

    public override void Shoot()
    {
        Rotation = -Deviation*((float)NumberOfBullets/2);
        for(int i=0; i<NumberOfBullets; i++)
        {
            var _bullet = Instantiate(bullet, bulletSpawnPoint.transform.position, gameObject.transform.rotation);
            _bullet.transform.Rotate(0, Rotation, Rotation);
            Rotation += Deviation;
        }
        return;
    }
}
