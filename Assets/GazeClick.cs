using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GazeClick : MonoBehaviour {
    public Image timerImage;
    public float requiredTime;
    public UnityEvent click;

    private bool status;
    private float gazeTime;

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
}
