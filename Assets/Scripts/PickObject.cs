using UnityEngine;

public class PickObject : MonoBehaviour {
    private bool pickedUp;
    private AudioSource manGruntSound;

    public GameObject cube;
    public GameObject parent;
    public Transform guide;
    public float upToggleAngle;
    public float downToggleAngle;

    // Use this for initialization
    void Start () {
        pickedUp = false;
        manGruntSound = GetComponent<AudioSource>();

        cube.GetComponent<Rigidbody>().useGravity = true;
	}

    // Update is called once per frame
    void Update()
    {
        if(pickedUp)
        {
            if(Camera.main.transform.eulerAngles.x >= downToggleAngle && Camera.main.transform.eulerAngles.x <= 90F)
            {
                pickedUp = false;
                OnPutDown(false);
            }
            else if (Camera.main.transform.eulerAngles.x <= 360 - upToggleAngle && Camera.main.transform.eulerAngles.x >= 360 - 90) {
                pickedUp = false;
                OnPutDown(true);
            }
        }
    }

    public void OnPickUp()
    {
        if(!pickedUp)
        {
            guide.GetComponent<BoxCollider>().enabled = true;
            cube.GetComponent<BoxCollider>().enabled = false;

            cube.GetComponent<Rigidbody>().useGravity = false;
            cube.GetComponent<Rigidbody>().isKinematic = true;

            Vector3 pos = guide.transform.position;
            Vector3 newPos = new Vector3(pos.x, pos.y + 0.5F, pos.z);
            cube.transform.position = newPos;

            cube.transform.rotation = guide.transform.rotation;

            cube.transform.parent = parent.transform;

            pickedUp = true;

            manGruntSound.Play();
        }
    }

    public void OnPutDown(bool look) // true == up, false == down
    {
        guide.GetComponent<BoxCollider>().enabled = false;
        cube.GetComponent<BoxCollider>().enabled = true;

        cube.GetComponent<Rigidbody>().useGravity = true;
        cube.GetComponent<Rigidbody>().isKinematic = false;

        cube.transform.parent = null;

        if (look)
        {
            cube.transform.position = guide.transform.position;
        }
        else
        {
            cube.transform.position = guide.transform.position + new Vector3(0, 1.5F, 0);
        }
    }
}
