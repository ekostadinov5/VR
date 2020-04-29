using UnityEngine;

public class OpenDoor : MonoBehaviour {
    private bool clicked;
    private AudioSource buttonClickSound;
    private AudioSource doorSound;
    private bool moving;
    private bool doorSoundOn;

    public GameObject door;
    public float openSpeed;
    public float closeSpeed;

	// Use this for initialization
	void Start () {
        clicked = false;
        buttonClickSound = GetComponent<AudioSource>();
        doorSound = door.GetComponent<AudioSource>();
        moving = false;
        doorSoundOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (clicked)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = Color.green;

            Vector3 pos = door.transform.position;
            if (pos.y < 13.5F)
            {
                door.transform.position = new Vector3(pos.x, pos.y + openSpeed, pos.z);
                moving = true;
            }
            else
            {
                moving = false;
            }
        }
        else
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.color = Color.red;

            Vector3 pos = door.transform.position;
            if (pos.y > 4.0F)
            {
                door.transform.position = new Vector3(pos.x, pos.y - closeSpeed, pos.z);
                moving = true;
            }
            else
            {
                moving = false;
            }
        }
        if(moving && !doorSoundOn)
        {
            doorSound.Play();
            doorSoundOn = true;
        }
        else if(!moving)
        {
            doorSound.Stop();
            doorSoundOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        clicked = true;
        buttonClickSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        clicked = false;
    }
}
