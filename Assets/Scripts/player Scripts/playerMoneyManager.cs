using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoneyManager : MonoBehaviour
{
    public static int playerGold;

    public static void playerReceiveGold(int amount)
    {
        playerGold += amount;
    }

    public static void playerLostGold(int amount)
    {
        playerGold -= amount;
    }
}
