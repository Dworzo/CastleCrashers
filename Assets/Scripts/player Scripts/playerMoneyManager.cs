using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoneyManager : MonoBehaviour
{
    public int playerGold;
    

    public void plyaerRecieveGold(int amount)
    {
        playerGold += amount;
    }

    public void playerLostGold(int amount)
    {
        playerGold -= amount;
    }
}
