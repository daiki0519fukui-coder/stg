using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{

    // 敵の速度
    [SerializeField] float speed = 3.0f;
    // 敵の移動方向
    [SerializeField] Vector3 moveDirection = Vector3.zero;
    // 弾のプレハブ
    [SerializeField] GameObject bulletObj;
    // 弾の発射間隔調整用
    //  [SerializeField] int bulletFrame = 5;
    // 敵の体力
    [SerializeField] int hp = 2;

   

    [SerializeField] float minInterval = 1.0f;

    [SerializeField] float maxInterval = 3.0f;


    private AudioSource audioSource;

    [SerializeField] AudioClip stSE;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoShoot());

        audioSource = GetComponent<AudioSource>();
    }

    public void FixedUpdate()
    {

        transform.position += moveDirection * speed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        // もしも画面の上端に出たら弾を消去する
        // position.yが6以上の時に消去
        if (transform.position.y <= -2.00f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーが、敵に当たったらプレイヤーのダメージ処理を呼ぶ
        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);

            // 当たったオブジェクトのダメージの処理を呼ぶ
            collision.GetComponent<Player>().Damage();

            
        
        //UIManager.instance.AddScore(100);
        // collision.GetComponent<UIManager>().AddScore();
    }

    }
    IEnumerator AutoShoot()
    {
        while (true)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            audioSource.PlayOneShot(stSE);
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletObj, transform.position, Quaternion.identity);
    }

    public void Damage()
    {

        hp--;

        // もし敵のhpが０になったら敵を消す
        if (hp <= 0)
        {

            UIManager.instance.AddScore();

            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                playerObj.GetComponent<Player>().COUNTKILL();
            }
            Death();

            
            
        }

    }
    // 死亡処理
    void Death()
    {

      
        Destroy(gameObject);

    }
}
