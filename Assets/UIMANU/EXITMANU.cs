using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXITMANU : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // �������� Editor
        Application.Quit();     // ��͹ Build ��ԧ��ҹ�鹶֧�зӧҹ
    }

}
