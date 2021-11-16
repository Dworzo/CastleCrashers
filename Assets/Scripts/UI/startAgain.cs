using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startAgain : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("tuvalu_test");
    }
}
