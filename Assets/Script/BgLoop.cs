using UnityEngine;

public class BgLoop : MonoBehaviour
{
    private Material Bg;
    public Camera mainCamera;
    [SerializeField] private float speed = 0.05f; // 移動スピード

    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
        {
            Bg = GetComponent<Renderer>().material;
        }

        // 画面の左端と右端のワールド座標を取得
        Vector3 leftWorld = mainCamera.ViewportToWorldPoint(new Vector3(0, 0.5f, mainCamera.nearClipPlane));
        Vector3 rightWorld = mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, mainCamera.nearClipPlane));

        float screenWidth = rightWorld.x - leftWorld.x;
        float screenHeight = mainCamera.orthographicSize * 2;

        // Quadのサイズを画面全体に合わせる
        transform.localScale = new Vector3(screenWidth, screenHeight, 1);

        // 左端をカメラの左端に合わせるため、画面幅の半分だけ右にずらす
        transform.position = new Vector3(leftWorld.x + (screenWidth / 2f), mainCamera.transform.position.y, 0);

        // 画面比率が変わってもテクスチャが引き伸ばされないよう、タイリング（Tiling）を自動調整
        float texAspect = (float)Bg.mainTexture.width / Bg.mainTexture.height;
        float screenAspect = screenWidth / screenHeight;

        // 横方向の繰り返し回数を画面比率に応じて計算
        Bg.mainTextureScale = new Vector2(screenAspect / texAspect, 1);
    }

    void Update()
    {
        // 時間経過でXのオフセット(UV)をずらしてループさせる
        float offset = Time.time * speed;
        Bg.mainTextureOffset = new Vector2(offset, 0);
    }
}