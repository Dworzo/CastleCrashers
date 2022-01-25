using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : MonoBehaviour
{
    static public int EnemiesLeft = 0;

    static void Awake()
    {
        EnemiesLeft = 0;
    }
}
