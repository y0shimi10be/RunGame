using TMPro;
using UnityEngine;

public class ScreenPositioner : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] GameObject player;
    [SerializeField] GameObject playerGround;

    [SerializeField] private float leftScreenPercent = 0.14f; // 画面左を基準にしたプレイヤーの横位置（0.2で20%）
    [SerializeField] private float verticalPositionPlayer = 0.3f; // プレイヤーの縦位置（0.5で中央）
    [SerializeField] private float groundOffsetY = -2f; // プレイヤーを基準にした足場の位置（下なのでマイナス）
    [SerializeField] private float Layer = 2; // 重なり順(Z軸)

    private Rigidbody2D rbPlayer;
    private Rigidbody2D rbGround;

    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
        rbPlayer = player.GetComponent<Rigidbody2D>();
        rbGround = playerGround.GetComponent<Rigidbody2D>();


        // プレイヤーの位置計算
        Vector3 targetViewportPosPlayer = new Vector3(leftScreenPercent, verticalPositionPlayer, Layer);
        Vector3 worldPosPlayer = mainCamera.ViewportToWorldPoint(targetViewportPosPlayer);

        // 足場の位置計算
        Vector3 worldPosGround = worldPosPlayer;
        worldPosGround.y += groundOffsetY;


        // Rigidbodyがあるので、MovePositionまたはpositionで反映させる
        if (rbPlayer != null)
            rbPlayer.MovePosition(worldPosPlayer);
        else
        {
            player.transform.position = worldPosPlayer;
        }

        if (rbGround != null)
        {
            rbGround.MovePosition(worldPosGround);
        }
        else
        {
            playerGround.transform.position = worldPosGround;
        }
    }
}
