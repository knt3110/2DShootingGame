using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public GameObject player;
    public Text title;
    public Text press;

    private void Update()
    {
        if(isPlaying()==false && Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
    }

    void GameStart()
    {
        title.text = "";
        press.text = "";
        Instantiate(player, transform.position, transform.rotation);
    }

    public void GameOver()
    {
        title.text = "Shooting Game";
        press.text = "Press Space";

        FindObjectOfType<Score>().Save();
    }

    public bool isPlaying()
    {
        return title.text == "";
    }
}
