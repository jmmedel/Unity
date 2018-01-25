using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aipaddle : MonoBehaviour {
    public ball theball;
    public float speed = 30;
    public float lerptweak = 2f;
    private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (theball.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0, 1).normalized;
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, dir * speed,
             lerptweak * Time.deltaTime);
        }
         else if (theball.transform.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0, -1).normalized;
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, dir * speed,
             lerptweak * Time.deltaTime);
        }
        else
        {
            Vector2 dir = new Vector2(0, 0).normalized;
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity,
             dir * speed, lerptweak * Time.deltaTime);
        }

    }

}
