using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    public float offset;
    public float health;
    public static float score;
	public GameObject projectile;
	public Transform shotPoint;
 public GameObject deathEffect;
    private float timeBtwShots;
    public float startTimeBtwShots;
    Rigidbody2D rb;
    Vector2 cameraPos;
    Vector2 vdelta = new Vector2(0.0f,0.0f);
    Vector2 force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	void Update()
	{
		    if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
GameObject.FindWithTag("gameover").GetComponent<Text>().text="GAME OVER!\n\n Your Score : " + score.ToString();
        }
	}
    void FixedUpdate()
    {
        cameraPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
        vdelta =  new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	var planets = GameObject.FindGameObjectsWithTag("Planet");
	force = new Vector2(0.0f,0.0f);
	foreach (GameObject planet in planets)
	{	
		var body = planet.GetComponent<Rigidbody2D>();
		var dif = body.position - rb.position;
		var d = dif.magnitude;
		var col = planet.GetComponent<CircleCollider2D>();
		var tr = planet.GetComponent<Transform>();
		if (d<= col.radius*tr.localScale.x+3)
		{
			health-=body.mass*0.001f;
 			UIHealthBar.instance.SetValue(health / 100.0f);
		}
		force += body.mass * dif / (d*d*d);
    }
	//b.AddForce(force);
	Physics2D.gravity = force;
	rb.velocity += vdelta/7.0f;
	    Vector2 pos = rb.position;
        Vector2 difference = cameraPos - pos;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        var angle = Quaternion.Euler(0.0f, 0.0f,rotZ + offset);
        rb.MoveRotation(angle);
	
      if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }

       
    }
}
