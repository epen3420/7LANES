using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void UnPauseGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
