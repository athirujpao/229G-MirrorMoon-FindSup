using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public string boxTag = "Box"; 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(boxTag)) 
        {
            CoinManager.Instance.CollectCoin(); 
            Destroy(gameObject); 
        }
    }
}
