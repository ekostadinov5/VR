using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoveObstacle : MonoBehaviour {
    private bool status;
    private float gazeTime;
    private AudioSource buttonClickSound;

    public GameObject obstacle;
	public Image timerImage;
    public float requiredTime;
    public UnityEvent click;

    // Use this for initialization
    void Start()
    {
        status = false;
        gazeTime = 0F;
        buttonClickSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status)
        {
            gazeTime += Time.deltaTime;
            timerImage.fillAmount = gazeTime / requiredTime;
        }
        if (gazeTime > requiredTime)
        {
            buttonClickSound.Play();
            gazeTime = 0;
            timerImage.fillAmount = 0;
            GetComponent<Renderer>().material.color = Color.green;
            click.Invoke();   
        }
    }

    public void GazeOn()
    {
        status = true;
    }

    public void GazeOff()
    {
        status = false;
        gazeTime = 0F;
        timerImage.fillAmount = 0;
    }

    public void Move()
    {
        obstacle.transform.position = new Vector3(-12, obstacle.transform.position.y, obstacle.transform.position.z);
    }
}
