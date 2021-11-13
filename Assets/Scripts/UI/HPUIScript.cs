using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPUIScript : MonoBehaviour
{
    public GameObject player;
    public TMP_Text HPText;
    public string maxHP, currentHP;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        HPText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        maxHP = player.GetComponent<playerHP>().maxHealth.ToString();
        currentHP = player.GetComponent<playerHP>().playerHealth.ToString();

        HPText.text = "HP: " + currentHP + "/" + maxHP;
    }
}
