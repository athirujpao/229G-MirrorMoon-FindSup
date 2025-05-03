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
            Debug.Log("WINNN");
        }
    }
}
