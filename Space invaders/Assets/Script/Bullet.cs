using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    public float speed = 30;
    // Use this for initialization
    private Rigidbody2D Rigibody;
    public Sprite exolodedALienImage;

	void Start () {
        Rigibody = GetComponent<Rigidbody2D>();
        Rigibody.velocity = Vector2.up * speed;
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "Alien")
        {
            SoundManager.Instance.Playoneshot(SoundManager.Instance.aliendies);
            IncreaseTextUlscore();
            collision.GetComponent<SpriteRenderer>().sprite = exolodedALienImage;
            Destroy(gameObject); // Destroy when hit 
            DestroyObject(collision.gameObject, 0.5f);
        }

        if(collision.tag == "Shield")
        {
            Destroy(gameObject);
            DestroyObject(collision.gameObject);
        }

    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void IncreaseTextUlscore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);
        score += 10;
        textUIComp.text = score.ToString();
    }

}
