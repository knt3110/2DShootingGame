using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public int power;

    public float lifeTime = 5f;

	void Start () {
        Destroy(gameObject, lifeTime);
	}
	
	void Update () {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}
}
