using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public int health;
    public GameObject deathEffect;
    public GameObject explosion;

    private void Update()
    {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
	    float bodymass = gameObject.GetComponent<Rigidbody2D>().mass;
            Destroy(gameObject);
	    Weapon.score+=bodymass;
	    GameObject.FindWithTag("score").GetComponent<Text>().text=Weapon.score.ToString();
        }
    }

    public void TakeDamage(int damage) {
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
