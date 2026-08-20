using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour

{
    // ゲームのスコア
    // [SerializeField] int score = 0;
    // スコアを表示しているGameObjct
    [SerializeField] GameObject scorePoint;

    public static int score;
    // クリア得点
    // [SerializeField] int clearPoint = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static UIManager instance;
    // public int score = 0;
    public TMPro.TMP_Text scoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scorePoint.GetComponent<TextMeshProUGUI>().text = score.ToString("D10");

        //if()
      
    }

    public void AddScore()
    {

        score += 100;
        //scorePoint.TextMeshPro = "Score: " + score.ToString();

    }

    
}
