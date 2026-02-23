using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timer = 5f;       
    public TextMeshProUGUI timerText;
    
    
    void Update()
    {
         if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                SceneManager.LoadSceneAsync(2);
            }

            timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
        } 
}
}
