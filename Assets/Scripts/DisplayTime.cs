using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public GameObject obj;

    // Use this for initialization
    void Start()
    {
        int bestTime = PlayerPrefs.GetInt("bestTime");
        if (bestTime == 0)
        {
            bestTime = int.MaxValue;
        }

        int currentTime = (int)GameTimer.currentTime;

        if (bestTime > currentTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetInt("bestTime", bestTime);
        }

        obj.GetComponent<Text>().text = "Тековно време: " + ((currentTime < 75) ? currentTime.ToString() + " секунди" : "---") + "\n\n";
        obj.GetComponent<Text>().text += "Најдобро време: " + ((bestTime < 75) ? bestTime.ToString() + " секунди" : "---") + "\n\n";

        if (bestTime < 75 && currentTime == bestTime)
        {
            obj.GetComponent<Text>().text += "НОВО НАЈДОБРО ВРЕМЕ!";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
