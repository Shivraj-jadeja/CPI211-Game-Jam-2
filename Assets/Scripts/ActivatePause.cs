using UnityEngine;

public class ActivatePause : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu; // Public because it is accessed in the camera script

    void Start()
    {
        pauseMenu.SetActive(false); // Turns off pause menu when game starts
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Pause();
        }
    }
    
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; // This doesn't stop the camera from moving by the way!

        // Unhide cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
