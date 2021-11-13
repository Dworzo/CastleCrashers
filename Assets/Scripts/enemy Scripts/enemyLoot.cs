using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLoot : MonoBehaviour
{
    public int goldAmount; //Gold recieved by player while killing this enemy
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void givePlayerGold()
    {
        player.GetComponent<playerMoneyManager>().plyaerRecieveGold(goldAmount);
    }
}
