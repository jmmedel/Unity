using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour {
    public float speed = 30;
    private Rigidbody2D rigibody;
    private AudioSource audiosource;

	// Use this for initialization
	void Start () {
        rigibody = GetComponent<Rigidbody2D>();
        rigibody.velocity = Vector2.right * speed;

	}

     void OnCollisionEnter2D(Collision2D collision)
    {
        // left paddle or right paddle
        if((collision.gameObject.name == "leftpaddle") || 
           (collision.gameObject.name == "rightpaddle"))
        {
            handlepaddlehit(collision);
        }
        // wallbotoom or wall top
        if ((collision.gameObject.name == "walltop") ||
          (collision.gameObject.name == "walldown"))
        {
            soundmanager.Instance.playoneshot(soundmanager.Instance.wallbloop);
        }
        // left goal or rightgoal
        if ((collision.gameObject.name == "goalleft") ||
          (collision.gameObject.name == "goalright"))
        {
            soundmanager.Instance.playoneshot(soundmanager.Instance.goalbloop);

            
            if(collision.gameObject.name == "goalleft")
            {
                increase_text_Ui_score("rightscoreUI");
            }
            if (collision.gameObject.name == "goalright")
            {
                increase_text_Ui_score("leftscoreUI");
            }


            transform.position = new Vector2(0, 0);

        }

    }

    void handlepaddlehit(Collision2D col)
    {
        float y = ballhitpaddlewhere(transform.position, col.transform.position,
            col.collider.bounds.size.y
            );
        Vector2 dir = new Vector2();
        if (col.gameObject.name == "leftpaddle")
        {
            dir = new Vector2(1, y).normalized;
        }
        if (col.gameObject.name == "rightpaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }
        rigibody.velocity = dir * speed;
        soundmanager.Instance.playoneshot(soundmanager.Instance.hitpaddlebloop);
    }

    float ballhitpaddlewhere(Vector2 ball, Vector2 paddle, float paddleheight)
    {
        return (ball.y - paddle.y) / paddleheight;
    }

    void increase_text_Ui_score(string textUiname)
    {
        var textUicomp = GameObject.Find(textUiname).GetComponent<Text>();
        int score = int.Parse(textUicomp.text);
        score++;
        textUicomp.text = score.ToString();

    }


}
