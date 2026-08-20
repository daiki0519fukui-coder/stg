using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BigBullet : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    // 弾の移動方向
    [SerializeField] Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection.y = 1.0f;
    }
    private void FixedUpdate()
    {

        // moveDirectionを使って座標を更新
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
      
        // もしも画面の上端に出たら弾を消去する
        // position.yが6以上の時に消去
        if (transform.position.y >= 20.0f)
        {
            Destroy(gameObject);
        }
    }

    // 直線方向に発車する
    void SetMoveDirection(float x, float y, float z)
    {
        moveDirection = new Vector3(x, y, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            // 当たったオブジェクトのダメージの処理を呼ぶ
            collision.GetComponent<Enemy>().Damage();

           
        }

        if (collision.gameObject.tag == "Boss")
        {
           
            // 当たったオブジェクトのダメージの処理を呼ぶ
            collision.GetComponent<Boss>().Damage();

           
        }
    }
}
