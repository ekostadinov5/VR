using UnityEngine;

public class OpenDoor : MonoBehaviour {
    private bool clicked;

    public GameObject door;
    public float openSpeed;
    public float closeSpeed;

	// Use this for initialization
	void Start () {
        clicked = false;
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
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        clicked = true;
    }

    private void OnTriggerExit(Collider other)
    {
        clicked = false;
    }
}
