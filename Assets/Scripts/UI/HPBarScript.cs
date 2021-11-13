using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    public Slider HPBar;
    public GameObject player;
    public float maxHP, currentHP;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        HPBar = gameObject.GetComponent<Slider>();
    }
    void Update()
    {
        maxHP = player.GetComponent<playerHP>().maxHealth;
        currentHP = player.GetComponent<playerHP>().playerHealth;
        HPBar.value = currentHP / maxHP;
    }
}
