using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject ItemApplePrefab; // アイテムのPrefabを設定する
    float delta = 0; // 前回アイテムを作ってからの経過時間(秒)
    [SerializeField] private float span = 1.0f; // アイテムを作る間隔(秒)
    [SerializeField] private int maxY = 5;// 生成位置Y(高)
    [SerializeField] private int minY = -3; // 生成位置Y(低)
    [SerializeField] private float spawnX = 11f; // 生成位置X(右端)

    void Update()
    {
        // 経過時間をためていく
        delta += Time.deltaTime;

        // 1秒たったらアイテムを1個作る
        if (delta > span)
        {
            delta = 0;

            // Prefabからアイテムを作る
            GameObject go = Instantiate(ItemApplePrefab);

            // 縦の位置をランダムにして、画面の右端(11)に置く
            int py = Random.Range(minY, maxY);
            go.transform.position = new Vector3(spawnX, py, 0);
        }
    }
}