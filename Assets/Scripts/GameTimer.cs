using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {
    private float timer;
    private TextMesh textMesh;

    public float timeLimit;

	// Use this for initialization
	void Start () {
        timer = 0;
        textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        float timeLeft = timeLimit - timer;
        int minutes = (int)(timeLeft / 60);
        int seconds = (int)timeLeft % 60;

        string timeText = "";
        if(minutes > 0)
        {
            timeText += minutes.ToString("00") + ":";
        }
        timeText += seconds.ToString("00");

        textMesh.text = timeText;

        if(timeLeft < 10.0F)
        {
            textMesh.color = Color.red;
        }

        if(timer > timeLimit)
        {
            SceneManager.LoadScene("startAgainMenu");
        }
	}
}
