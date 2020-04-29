using UnityEngine;

public class PickObject : MonoBehaviour {
    private bool pickedUp;

    public GameObject obj;
    public GameObject parent;
    public Transform guide;
    public float upToggleAngle;
    public float downToggleAngle;

    // Use this for initialization
    void Start () {
        pickedUp = false;

        obj.GetComponent<Rigidbody>().useGravity = true;
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

            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.GetComponent<Rigidbody>().isKinematic = true;

            Vector3 pos = guide.transform.position;
            Vector3 newPos = new Vector3(pos.x, pos.y + 0.5F, pos.z);
            obj.transform.position = newPos;

            obj.transform.rotation = guide.transform.rotation;

            obj.transform.parent = parent.transform;

            pickedUp = true;
        }
    }

    public void OnPutDown(bool look) // true == up, false == down
    {
        guide.GetComponent<BoxCollider>().enabled = false;

        obj.GetComponent<Rigidbody>().useGravity = true;
        obj.GetComponent<Rigidbody>().isKinematic = false;

        obj.transform.parent = null;

        if (look)
        {
            obj.transform.position = guide.transform.position;
        }
        else
        {
            obj.transform.position = guide.transform.position + new Vector3(0, 1.5F, 0);
        }
    }
}
