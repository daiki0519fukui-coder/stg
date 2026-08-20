using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class HP : MonoBehaviour
{

    // TextMeshProUGUI型で直接受け取ると処理が楽になります
    [SerializeField] TextMeshProUGUI HPUIManager;

    // 現在のHPを保存する変数
    private int currentHP = 20;

    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
      //  HPUIManager.GetComponent<TextMeshProUGUI>().text = HPUIManager.ToString();
    }

    public void TakeDamage( int hp)
    {
      

        currentHP=hp; // 1減らす

        UpdateDisplay(); // 表示を更新
    }

    void UpdateDisplay()
    {
        if (HPUIManager != null)
        {
            HPUIManager.text = currentHP.ToString(); // 数字を文字列にして表示
        }
      
    }
}

