using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public int MaxSize;
    public int currentSize;
    public GameObject snakePrefab;
    public Snake head;
    public Snake tail;
    public int NESW;
    public Vector2 nexPos;
    public int  xBound;
    public int  yBound;
    public GameObject foodPregab;
    public GameObject currentFood;
    public int score;
    public Text ScoreText;
    public float deltaTimer;
    // Use this for initialization

     void OnEnable()
    {
        Snake.hit += hit; 
    }
    private void OnDisable()
    {
        Snake.hit -= hit;
    }
    void Start () {
        // change  the speed
        InvokeRepeating("TimerInvoke", 0, deltaTimer);
        FoodFunction();

	}
	
	// Update is called once per frame
	void Update () {
        ComChangeD();
	}
    void TimerInvoke()
    {
        Movement();
        StartCoroutine(checkVisable());
        if(currentSize >= MaxSize)
        {
            TailFunction();
        }
        else
        {
            currentSize++;

        }
    }
    void Movement()
    {
        GameObject temp;
        nexPos = head.transform.position;
        switch(NESW)
        {
            case 0:
                nexPos = new Vector2(nexPos.x, nexPos.y + 1);
                break;
            case 1:
                nexPos = new Vector2(nexPos.x + 1, nexPos.y);
                break;
            case 2:
                nexPos = new Vector2(nexPos.x, nexPos.y - 1);
                break;
            case 3:
                nexPos = new Vector2(nexPos.x -1, nexPos.y);
                break;

        }

        temp = (GameObject)Instantiate(snakePrefab, nexPos, transform.rotation);
        head.Setnext(temp.GetComponent<Snake>());
        head = temp.GetComponent<Snake>();
        return;
    }

    void ComChangeD()
    {   // very important to remever
        if(NESW != 2 && Input.GetKeyDown(KeyCode.W))
        {
            NESW = 0;
        }
        if (NESW != 3 && Input.GetKeyDown(KeyCode.D))
        {
            NESW = 1;
        }
        if (NESW != 0 && Input.GetKeyDown(KeyCode.S))
        {
            NESW = 2;
        }
        if (NESW != 1 && Input.GetKeyDown(KeyCode.A))
        {
            NESW = 3;
        }


    }

    void TailFunction()
    {
        Snake tempSnake = tail;
        tail = tail.GetNext();
        tempSnake.RemoveTail();
    }

    void FoodFunction()
    {
        int xPos = Random.Range(-xBound, xBound);
        int yPos = Random.Range(-yBound, yBound);
        currentFood = (GameObject)Instantiate(foodPregab, new Vector2(xPos, yPos), transform.rotation);
        StartCoroutine(CheckRender(currentFood));
    }

    IEnumerator CheckRender(GameObject IN)
    {
        yield return new WaitForEndOfFrame();
        if(IN.GetComponent<Renderer>().isVisible == false)
        {
            if(IN.tag == "Food")
            {
                Destroy(IN);
                FoodFunction();
            }

        }

    }

    void hit(string WhatwasSent)
    {
        if(WhatwasSent == "Food")
        {   if(deltaTimer >= .1f)
            {
                deltaTimer -= .05f;
                CancelInvoke("TimerInvoke");
                InvokeRepeating("TimerInvoke", 0, deltaTimer);
            }
            
            FoodFunction();
            MaxSize++;
            score++;
            ScoreText.text = score.ToString();
            // change the name for sure if it wrong
            int temp = PlayerPrefs.GetInt("HighScore");
            // change if it grether than older score
            if(score > temp)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        if(WhatwasSent == "Snake")
        {
            CancelInvoke("TimerInvoke");
            Exit();
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);

    }

    void Wrap()
    {
        if(NESW == 0)
        {
            head.transform.position = new Vector2(head.transform.position.x, -(head.transform.position.y - 1));
        }
        else if (NESW == 1)
        {
            head.transform.position = new Vector2(-(head.transform.position.x - 1), head.transform.position.y);
        }
        else if (NESW == 2)
        {
            head.transform.position = new Vector2(head.transform.position.x, -(head.transform.position.y + 1));
        }
        else if (NESW == 3)
        {
            head.transform.position = new Vector2(-(head.transform.position.x + 1), head.transform.position.y);
        }

    }

    IEnumerator checkVisable()
    {
        yield return new WaitForEndOfFrame();
        if(!head.GetComponent<Renderer>().isVisible )
        {
            Wrap();
        }
    }
}
