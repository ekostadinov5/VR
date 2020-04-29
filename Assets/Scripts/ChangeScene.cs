using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void Pocetok()
    {
        SceneManager.LoadScene("scene");
    }

    public void Upatstvo()
    {
        SceneManager.LoadScene("instructionsMenu");
    }

    public void Nazad()
    {
        SceneManager.LoadScene("startMenu");
    }

    public void Kraj()
    {
        Application.Quit();
    }
}
