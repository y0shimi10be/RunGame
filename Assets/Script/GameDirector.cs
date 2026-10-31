using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    int Score = 0; // スコアの初期値
    public int AddScore = 100; // スコアに加算する値
    public float Damage = 0.2f; // ダメージの値(体力の20%減)
    [SerializeField] GameObject hpGauge;
    [SerializeField] GameObject scoreText;

    void Start()
    {
    }

    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + Score.ToString();
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
    }
}