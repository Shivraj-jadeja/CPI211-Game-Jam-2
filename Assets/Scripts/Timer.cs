using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timer = 5f;       
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI ExplanationText;
    
    //void Start()
    //{
       // Invoke("hideText()", 5f);
    //}
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

        if (timer < 56f && timer > 54f)
        {
            ExplanationText.gameObject.SetActive(false);
        }
    }

   // void hideText()
   // {
   //     ExplanationText.gameObject.SetActive(false);
    //}
}
