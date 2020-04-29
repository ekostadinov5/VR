using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoveObstacle : MonoBehaviour {
    public GameObject obstacle;
	public Image timerImage;
    public float requiredTime;
    public UnityEvent click;

    private bool status;
    private float gazeTime;
    private bool clicked;

    // Use this for initialization
    void Start()
    {
        status = false;
        gazeTime = 0F;
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
