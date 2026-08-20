using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // 弾の速度
    [SerializeField] float speed = 5.0f;
    // 弾の移動方向
    [SerializeField] Vector3 moveDirection = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        moveDirection.y = -1.0f;
    }

    private void FixedUpdate()
    {

        // moveDirectionを使って座標を更新
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -9.0f)
        {
            Destroy(gameObject);
        }
    }

    void SetMoveDirection(float x, float y, float z)
    {
        moveDirection = new Vector3(x, y, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            // 当たったオブジェクトのダメージの処理を呼ぶ
            collision.GetComponent<Player>().Damage();

            Destroy(gameObject);            // 自分を消去
        }
    }

  
}
