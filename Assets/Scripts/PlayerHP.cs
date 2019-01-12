using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

    private Text playerHP;

    private int hp;

    private void Start()
    {
        playerHP = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();
    }

    void Update () {
        hp = FindObjectOfType<Player>().playerHP;
        playerHP.text = "HP : " + hp;
	}

    private void OnDestroy()
    {
        playerHP.text = "HP";
    }
}
