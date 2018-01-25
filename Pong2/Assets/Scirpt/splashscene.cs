using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class splashscene : MonoBehaviour {

    public string scenetoload;

    public int sectillsceneload;
	// Use this for initialization
	void Start () {
        Invoke("OpenNextScene", sectillsceneload);
        opennextscene();
	}

    void opennextscene()
    {
        SceneManager.LoadScene(scenetoload);
    }
	

}
