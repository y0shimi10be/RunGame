using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject ItemApplePrefab;   // アイテムのPrefabを設定する
    float span = 1.0f;               // アイテムを作る間隔(秒)
    float delta = 0;                 // 前回アイテムを作ってからの経過時間(秒)

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

            // 縦の位置をランダムにして、画面の右端に置く
            int py = Random.Range(-4, 5);
            go.transform.position = new Vector3(11, py, 0);
        }
    }
}