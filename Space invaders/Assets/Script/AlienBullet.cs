using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour {
    private Rigidbody2D rigidbody;
    public float speed = 30;
    public Sprite explodedShipImage;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.down * speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);

        }
        if(collision.gameObject.tag == "Player")
        {
            SoundManager.Instance.Playoneshot(SoundManager.Instance.shipexplosion);
            collision.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
            Destroy(gameObject);
            DestroyObject(collision.gameObject, 0.5f);
        }

        if (collision.tag == "Shield")
        {
            Destroy(gameObject);
            DestroyObject(collision.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
