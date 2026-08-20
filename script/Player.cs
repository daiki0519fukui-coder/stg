using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : MonoBehaviour
{

    // プレイヤーの速度
    [SerializeField] float speed = 4.0f;
    // プレイヤーの移動方向
    [SerializeField] Vector3 moveDirection = Vector3.zero;
    // 弾のプレハブ
    [SerializeField] GameObject bulletObj;
    // 弾のプレハブ
    [SerializeField] GameObject BigbulletObj;
    // プレイヤーの初期位置
    private Vector3 initPlayerPos = new Vector3(-30, 1, 0);
    // カウンタ
    [SerializeField] int counter = 0;
    // 弾の発射間隔調整用
    [SerializeField] int bulletFrame = 5;
    // HP
    [SerializeField] int HitPoint;
    // プレイヤーの最大HP
    [SerializeField] const int hp = 10;
    // UIのGameObject
    [SerializeField] GameObject UIManagerObj;
    // 普通の弾
    private AudioSource AudioSource;
    [SerializeField] AudioClip ShotSE;
    // 大きい弾
    private AudioSource AUdioSource;
    [SerializeField] AudioClip SHOTSE;
    // ダメージ
    private AudioSource AUDIOSource;
    [SerializeField] AudioClip DamageSE;


    // 倒した数
    private int Kill;

    public void COUNTKILL()
    {
        Kill++;
        Kills++;

        Special.AddSpecial(1);
    }

    bool ASS = true;

    [SerializeField] GameObject bossObj;

   // カウンター
   [SerializeField] int Kills = 0;
    // 総計
    //[SerializeField] private Count Count;

    [SerializeField] private Special Special;

    [SerializeField] HP hpSystem;

    // Start関数はシーンが始まって最初のフレームの前に呼ばれる関数
    void Start()
    {
        // FPSを860に
        Application.targetFrameRate = 60;

        transform.position = initPlayerPos;

        // プレイヤーもHPを設定
        HitPoint = hp;

        hpSystem = hpSystem.GetComponent<HP>();

        AudioSource = GetComponent<AudioSource>();

        AUdioSource = GetComponent<AudioSource>();

        AUDIOSource = GetComponent<AudioSource>();
    }

    public void FixedUpdate()
    {

        transform.position += moveDirection * speed * Time.deltaTime;

    } 

    // Updateは一秒間に何回も呼ばれる関数
    void Update()
    {

        hpSystem.TakeDamage(HitPoint);

        

        // Update関数では入力の検地をおこなうとよい
        // 座標の更新はFixedUpdete関数にて行うと等速直線運動できあった速度で移動できる
        counter++;

        moveDirection = Vector3.zero;

        // 左矢印
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            

             if (transform.position.x > -33.78f)
             {

               moveDirection.x = -1.0f;
             }
            
        }
        // 右矢印
        if (Input.GetKey(KeyCode.RightArrow))
        {


            if (transform.position.x < -25.98f)
             {

              moveDirection.x = 1.0f;
            }
            
        }

        // 上矢印
        if (Input.GetKey(KeyCode.UpArrow))
        {

              if (transform.position.y < 8.799f)
            {

            moveDirection.y = 1.0f;
            }

           
        }
        // 矢印
        if (Input.GetKey(KeyCode.DownArrow))
        {

            if (transform.position.y > -0.25f)
            {

              moveDirection.y = -1.0f;
           }
            
        }

        // スペースキーが押されたら弾を発射
        if (Input.GetKey(KeyCode.Space))
        {
            // 弾の発射間隔を調整する
            if (counter % bulletFrame == 0)
            {

                // counter = 0;
                Instantiate(bulletObj, transform.position, Quaternion.identity);

                //  ShotSE
                AudioSource.PlayOneShot(ShotSE);
            }

        }

        // スペースキーが押されたら弾を発射
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Kill >= 10)
            {
                // デカ弾発射
                Instantiate(BigbulletObj, transform.position, Quaternion.identity);

                // 撃ったのでリセット
                Kill = 0;
                // RefreshUI(); // UIを更新！

                AUdioSource.PlayOneShot(SHOTSE);

                Special.ResetSpecial();
            }
            else
            {
                Debug.Log("敵を2体倒していないのでS弾は撃てません");
            }

        }


        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.RightShift)))
        {
            speed = 1.5f;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 8.0f;
        }
        else
        {
            speed = 4.5f;
        }

        if(Kills == 50 && ASS == true)
        {

            Kills = 50;

            ASS = false;


            SpawnBoss();
        }
        
    }

    // ボスの召喚
    void SpawnBoss()
    {
       
        Instantiate(bossObj, new Vector3(-30, 8, 0), Quaternion.identity);

    }
    // ダメージ処理
    public void Damage()
    {
        HitPoint--;

        AudioSource.PlayOneShot(DamageSE);

        if (HitPoint <= 0)
        {

            HitPoint = 0;

            GameOver();
        }

        UpdateUI();

    }

    void UpdateUI()
    {

        if (hpSystem != null)
        {
            
        }
    }

    void GameOver()
    {
        // ゲームオーバー
        SceneManager.LoadScene("result");

    }
}
