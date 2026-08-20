using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class pose : MonoBehaviour
{


   [SerializeField] public GameObject pauseMenuUI; // É|Å[ÉYâÊñ (Canvas)
    public Button continueButton;     // ë±ÇØÇÈ
    public Button quitButton;         // Ç‚ÇﬂÇÈ
 
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f; // éûä‘Çå≥Ç…ñﬂÇ∑

        isPaused = false;
 
    }

    // ÉQÅ[ÉÄÇàÍéûí‚é~
    void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f; // éûä‘í‚é~

     
        isPaused = true;


    }


    void QuitGame()
    {
        Time.timeScale = 1f;
      
        
    }

    
}
