using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    int Score = 0; // スコアの初期値
    [SerializeField] private int AddScore = 100; // スコアに加算する値
    [SerializeField] private float Damage = 0.2f; // ダメージの値(体力の20%減)
    [SerializeField] GameObject hpGauge;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject RetryPanel;
    [SerializeField] GameObject FinalScore;

    private bool isGameOver = false; // 二重処理を防ぐフラグ

    void Start()
    {
        // ゲーム開始時は必ず時間を通常の速さに戻しておく
        Time.timeScale = 1.0f;

        // ゲーム開始時はゲームオーバーパネルを非表示にしておく
        if (RetryPanel != null)
        {
            RetryPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver) return; // ゲームオーバー中は更新を止める

        scoreText.GetComponent<TextMeshProUGUI>().text = "SCORE : " + Score.ToString();
    }

    // アイテムをキャッチするとスコア加算(アイテムから呼ばれる)
    public void CatchItem()
    {
        Score += AddScore;
    }

    // HPを減らす(アイテムから呼ばれる)
    public void DecreaseHp()
    {
        Image hpImage = hpGauge.GetComponent<Image>();
        hpImage.fillAmount -= Damage;

        // HPが0以下になったらゲームオーバー処理を実行する
        if (hpImage.fillAmount <= 0.1f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        // 最終スコアを表示する
        if (FinalScore != null)
        {
            FinalScore.GetComponent<TextMeshProUGUI>().text = Score.ToString();
        }

        // ゲームオーバーパネルを表示する
        if (RetryPanel != null)
        {
            RetryPanel.SetActive(true);
        }

        // ゲームの時間を止める
        Time.timeScale = 0f;
    }


    // Retryボタンから呼び出すメソッド
    public void RetryGame()
    {
        // シーンをロードし直す前に、止まっていた時間を必ず元に戻す
        Time.timeScale = 1.0f;

        // 現在のシーン（SceneInGame）を再度読み込む
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}