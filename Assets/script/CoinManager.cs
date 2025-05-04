using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public int coinRequired = 5;
    private int currentCoins = 0;

    public int Coinscurrent => currentCoins;

    public GameObject stairObject; // บันไดที่จะเปิดเมื่อครบ
    public TextMeshProUGUI coinText; // UI แสดงจำนวนเหรียญ

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateCoinUI(); // อัปเดต UI ตอนเริ่มเกม
    }

    public void CollectCoin()
    {
        currentCoins++;
        UpdateCoinUI();

        if (currentCoins >= coinRequired && stairObject != null)
        {
            stairObject.SetActive(true); // แสดงบันได
        }
    }
    public bool HasCollectedAllCoins()
    {
        return currentCoins >= coinRequired;
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = $"Coins: {currentCoins} / {coinRequired}";
        }
    }
}
