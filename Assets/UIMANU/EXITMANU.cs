using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXITMANU : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // เอาไว้ดูใน Editor
        Application.Quit();     // ใช้ตอน Build จริงเท่านั้นถึงจะทำงาน
    }

}
