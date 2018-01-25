using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepaddle : MonoBehaviour {
    public float speed = 30;

    private void FixedUpdate()
    {
        float vertpress = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertpress) * speed;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
