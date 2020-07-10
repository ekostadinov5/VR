using UnityEngine;
using UnityEngine.Events;

public class MoveObstacle : MonoBehaviour {
    private bool clicked;
    private AudioSource buttonClickSound;

    public GameObject obstacle;
    public UnityEvent click;

    // Use this for initialization
    void Start()
    {
        clicked = false;
        buttonClickSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GazeOn()
    {
        if(!clicked)
        {
            clicked = true;
            buttonClickSound.Play();
            GetComponent<Renderer>().material.color = Color.green;
            click.Invoke();
        }
    }

    public void GazeOff()
    {
    }

    public void Move()
    {
        obstacle.transform.position = new Vector3(-12, obstacle.transform.position.y, obstacle.transform.position.z);
    }
}
