using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject player;
    GameDirector director;

    //落下設定
    [SerializeField] private float throwSpeed = 5.0f; // 1秒間に進む距離
    [SerializeField] private float destroyXPosition = -11f; // 画面外に出て消去するx座標

    // 回転設定
    [SerializeField] private float minRotationSpeed = 100f;
    [SerializeField] private float maxRotationSpeed = 300f;

    private float rotationSpeed;

    void Start()
    {
        player = GameObject.Find("Player");
        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        // 生まれた時にランダムな回転速度（正負で回転方向もランダム）を決める
        float direction;
        if (Random.Range(0, 2) == 0)
        {
            direction = (float)1f;
        }
        else
        {
            direction = (float)-1f;
        }

        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed) * direction;
    }

    void Update()
    {
        // 左方向へ移動させる
        transform.Translate(Vector3.left * throwSpeed * Time.deltaTime, Space.World);

        // Z軸を中心に回転させる
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // 画面外に出たらHPを減らして削除
        if (transform.position.x < destroyXPosition)
        {
            // GameDirectorに「画面外に消えた（取り逃した）」と知らせる
            director.DecreaseHp();

            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // GameDirectorに「プレイヤーが取得した（スコア加算）」と知らせる
            director.CatchItem();

            // 当たったリンゴを消す
            Destroy(gameObject);
        }
    }
}