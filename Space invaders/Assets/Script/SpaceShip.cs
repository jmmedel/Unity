using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {
    public float speed = 30;
    public GameObject thebullet;

    private void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");// get the axis using keyboard
        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
        {
            Instantiate(thebullet, transform.position, Quaternion.identity);
            SoundManager.Instance.Playoneshot(SoundManager.Instance.bulletfire);
        }
	}
}
