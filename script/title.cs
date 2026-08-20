using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{

    private AudioSource audioSOURCE;
    [SerializeField] AudioClip BaaanSE;
    // Start is called before the first frame update
    void Start()
    {
        audioSOURCE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            audioSOURCE.PlayOneShot(BaaanSE);

            SceneManager.LoadScene("Main");

        }
    }
}
