using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ruzarut : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = UIManager.score.ToString();


    }
}
