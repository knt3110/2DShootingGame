using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public int playerHP = 3;

    private AudioSource sound1;
    private AudioSource sound2;

    Spaceship spaceship;

    private IEnumerator Start()
    {
        spaceship = GetComponent<Spaceship>();
        AudioSource[] sounds = GetComponents<AudioSource>();
        sound1 = sounds[0];
        sound2 = sounds[1];

        while (true)
        {
            spaceship.Shot(transform);
            sound1.Play();
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        Vector2 pos = transform.position;

        pos += direction * spaceship.speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {

        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName == "Bullet (Enemy)")
        {
            Destroy(c.gameObject);
        }

        if (layerName == "Bullet (Enemy)" || layerName == "Enemy")
        {
            playerHP -= 1;
            sound2.Play();
            if (playerHP <= 0)
            {
                spaceship.Explosion();
                Destroy(gameObject);
                FindObjectOfType<Manager>().GameOver();
            }
        }
    }
}
