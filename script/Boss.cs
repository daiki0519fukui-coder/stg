using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static System.Net.WebRequestMethods;
using static Unity.Burst.Intrinsics.X86;

public class Boss : MonoBehaviour
{

    // ボスの速度
    [SerializeField] float speed = 6.0f;
 
    // ボスの最大HP
    [SerializeField] int maxHP = 50; // ★ const をやめる
    // HP
    int nowHP;
    // ボスの移動方向
    [SerializeField] Vector3 moveDirection = Vector3.zero;
    // 弾のプレハブ
    [SerializeField] GameObject bulletObj;

    [SerializeField] float minInterval = 1.0f;

    [SerializeField] float maxInterval = 3.0f;

    [SerializeField] float minX = -33.8f; // 指定の左端
    [SerializeField] float maxX = -24.8f; // 指定の右端

    private AudioSource audiosource;

    [SerializeField] AudioClip shotse;

    private AudioSource AudioSOURCE;

    [SerializeField] AudioClip TEESE;
    // Start is called before the first frame update
    void Start()
    {
        nowHP = maxHP;

        Debug.Log("HP初期化: " + nowHP);

        StartCoroutine(AutoShoot());

        audiosource = GetComponent<AudioSource>();
        AudioSOURCE = GetComponent<AudioSource>();
    }

    //public void FixedUpdate()
    //{

    //    transform.position += moveDirection * speed * Time.deltaTime;

    //}

    // Update is called once per frame
    void Update()
    {
        moveDirection = Vector3.zero;

        // --- 左右往復移動 ---
        float width = maxX - minX;
        // 0からwidthの間を往復する
        float xOffset = Mathf.PingPong(Time.time * speed, width);
        // y座標は現在の位置を維持、x座標だけをminX?maxXで動かす
        transform.position = new Vector3(minX + xOffset, transform.position.y, 0);


    }
    void SetMoveDirection(float x, float y, float z)
    {
        moveDirection = new Vector3(x, y, 0.0f);
    }

    IEnumerator AutoShoot()
    {
        while (true)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            audiosource.PlayOneShot(shotse);
           

            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletObj, transform.position, Quaternion.identity);
    }
    public void Damage()
    {
        nowHP--;

        UIManager.instance.AddScore();

        if (nowHP <= 0)
        {

            nowHP = 0;
        

            GameaClear();

            Destroy(gameObject);            // 自分を消去
        }

        Debug.Log("減りました");
    }

    void GameaClear()
    {

         SceneManager.LoadScene("result");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            // 当たったオブジェクトのダメージの処理を呼ぶ
            collision.GetComponent<Player>().Damage();
            
        }

       
    }
  
}
