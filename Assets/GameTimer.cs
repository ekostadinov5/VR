using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {
    private float timer;

    public float timeLimit;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > timeLimit)
        {
            SceneManager.LoadScene("startAgainMenu");
        }
	}
}
