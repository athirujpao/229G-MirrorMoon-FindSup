using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Stair : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private float messageDisplayTime = 2f;
    [SerializeField] private string sceneToLoad = "WinScene"; // ชื่อซีนที่จะโหลดเมื่อชนะ

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (CoinManager.Instance != null)
            {
                if (CoinManager.Instance.HasCollectedAllCoins())
                {
                    ShowMessage("Loading...");
                    StartCoroutine(LoadSceneAfterDelay());
                }
                else
                {
                    ShowMessage("Not enough coins!");
                }
            }
        }
    }

    void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageText.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(HideMessageAfterDelay());
        }
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayTime);
        messageText.gameObject.SetActive(false);
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayTime); // รอให้เห็นข้อความก่อน
        SceneManager.LoadScene(sceneToLoad);
    }
}
