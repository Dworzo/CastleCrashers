using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class goldUIScript : MonoBehaviour
{
    public GameObject player;
    public TMP_Text goldText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        goldText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + playerMoneyManager.playerGold.ToString();
    }
}
