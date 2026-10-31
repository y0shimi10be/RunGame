using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TopManager : MonoBehaviour
{
    void Update()
    {
        // 画面のどこかがクリックされたらインゲームへ遷移する
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene("SceneInGame");
        }
    }
}