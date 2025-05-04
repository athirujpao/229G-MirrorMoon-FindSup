using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    // เดินไปแล้วเกิดการ win หรือ ใส่ scene credit เลยก็ได้

    void OnTriggerEnter2D(Collider2D col)
    {
         if (col.CompareTag("Player"))
        {
            if (CoinManager.Instance != null)
            {
                Debug.Log("Current coin: " + CoinManager.Instance.Coinscurrent);
                Debug.Log("Coin required: " + CoinManager.Instance.coinRequired);

                if (CoinManager.Instance.HasCollectedAllCoins())
                {
                    Debug.Log("WINNN");
                }
                else
                {
                    Debug.Log("ยังเก็บเหรียญไม่ครบ!");
                }
            }
        }
        
    }
}
