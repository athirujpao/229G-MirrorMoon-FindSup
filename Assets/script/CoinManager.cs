using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public int coinRequired = 5;
    private int currentCoins = 0;

    public GameObject stairObject; // บันไดที่จะเปิดเมื่อครบ

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CollectCoin()
    {
        currentCoins++;

        if (currentCoins >= coinRequired && stairObject != null)
        {
            stairObject.SetActive(true); // แสดงบันได
        }
    }
}
