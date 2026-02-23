using UnityEngine;

public class ActivatePause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Pause();
    }
    }
    
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
