using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returrn : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.T))
        {
          

            Time.timeScale = 1f;

            UIManager.score = 0;

            SceneManager.LoadScene("title"); // ƒ^ƒCƒgƒ‹‚É–ß‚é
        }

    }
}
