using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMove : MonoBehaviour
{
    /*ทำ grid movement มีไรบ้าง
    -check ขนาด grid , -จะทำแบบกดค้างไหม น่าจะดี,
    แล้วไวไหม? ถ้าไวก็ได้เพราะเกมใช้เวลาจำกัดในการเล่นแต่ละด่าน
    Code Grid Movement ได้มาจาก Firnox แต่เอามาเปลี่ยนเพราะนั่งดูเข้าใจแล้วอยากลองเปลี่ยนดู (พังกว่าจะแก้ได้T-T)
    https://github.com/Firnox/GridMovement/blob/main/Assets/Scripts/GridMovement.cs*/
    [SerializeField] private float gridSize = 1f;
    [SerializeField] private float moveDuration = 0.1f;
    [SerializeField] private float repeatDelay = 0.05f;
    [SerializeField] private LayerMask obstacleLayer;

    private bool isMoving = false;
    private Vector2 inputDirection = Vector2.zero;
    

    // Update is called once per frame เกม move ที่ละครั้งใช้ fixed update แล้วพัง T-T
    private void Update() 
    {
        if (!isMoving) 
        {
            inputDirection = ReadInput();
            if (inputDirection != Vector2.zero && CanMove(inputDirection))
            {
                StartCoroutine(Move(inputDirection));
            }
        }
            
    }
    private Vector2 ReadInput()
    {
        if (Input.GetKey(KeyCode.W)) return Vector2.up;
        if (Input.GetKey(KeyCode.S)) return Vector2.down;
        if (Input.GetKey(KeyCode.A)) return Vector2.left;
        if (Input.GetKey(KeyCode.D)) return Vector2.right;
        return Vector2.zero;
    }
    private bool CanMove(Vector2 direction)
    {
        Vector2 targetPos = (Vector2)transform.position + direction * gridSize;
        Collider2D hit = Physics2D.OverlapCircle(targetPos, 0.1f, obstacleLayer);
        return hit == null;
    }
    private IEnumerator Move(Vector2 direction) 
    {
        isMoving = true;

        Vector2 start = transform.position;
        Vector2 endPosi = start + direction * gridSize;
        
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector2.Lerp(start, endPosi, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    

    transform.position = endPosi;
    yield return new WaitForSeconds(repeatDelay); // เพิ่มสำหรับ inputbuffer แล้วก็กดเดินค้าง
    //ถ้าไม่ขยับก็หยุด จะได้ใส่ input ถัดไป
    isMoving = false;
  }


}
