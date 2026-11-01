using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 60.0f; // ジャンプの力
    [SerializeField] private float spriteInterval = 1.0f; // スプライトの切り替え間隔(秒)
    public Sprite[] walkSprites;
    float time = 0;
    int idx = 0;
    Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer;
    GameObject director;

    void Start()
    {

        Application.targetFrameRate = 600;
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        // ジャンプ
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            rigid2D.AddForce(Vector2.up * jumpForce);
        }

        // アニメーション
        time += Time.deltaTime;
        if (time > spriteInterval)
        {
            time = 0f;
            spriteRenderer.sprite = walkSprites[idx];
            idx = 1 - idx;
        }
    }
}