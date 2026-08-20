using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class first : MonoBehaviour
{

    private AudioSource AudioSource;

    [SerializeField] AudioClip BaanSE;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {

            UIManager.score = 0;

            Time.timeScale = 1f;

            SceneManager.LoadScene("Main");

        }

    }
}
