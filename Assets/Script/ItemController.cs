using UnityEngine;

public class ItemController : MonoBehaviour
{
    GameObject player;

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

        // 画面外に出たら削除
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
            return;
        }

        // 当たり判定(円と円)
        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            // 当たったリンゴを消す
            Destroy(gameObject);
        }
    }
}