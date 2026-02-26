using UnityEngine;

public class ActivatePause : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu; // Pause menu UI
    [SerializeField] private GameObject player;   // Player GameObject with FirstPersonLook

    private FirstPersonLook playerLook;
    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);

        if (player != null)
        {
            // Grab the FirstPersonLook component from the player
            playerLook = player.GetComponent<FirstPersonLook>();
            if (playerLook == null)
            {
                Debug.LogWarning("No FirstPersonLook component found on player!");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        if (playerLook != null)
            playerLook.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        if (playerLook != null)
            playerLook.enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        isPaused = false;
    }
}