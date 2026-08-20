using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RANK : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI rankText;
    // Start is called before the first frame update
    void Start()
    {
        // 自分自身の TextMeshProUGUI を取る
        rankText = GetComponent<TextMeshProUGUI>();

        // UIManager からスコアを取得
        int score = UIManager.score;

        // ランクを計算して表示
        rankText.text = GetRank(score);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    string GetRank(int score)
    {
        if (score >= 25000) return "SSS";
        if (score >= 18000) return "S";
        if (score >= 14000) return "A";
        if (score >= 10000) return "B";
        if (score >= 5000) return "C";
        if (score == 0) return "Huh?";
        return "D";
    }
}
