using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    Vector2 mousePos;
    
    
   
 

    [SerializeField] private float rollSpeed = 3;
    private bool isMoving;
    bool topWallStop;
    bool leftWallStop;
    bool bottomWallStop;
    bool rightWallStop;




    private void Update()
    {
        mousePos = Input.mousePosition;
        Debug.Log(mousePos);

       

        MousePosition2();
    }
    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.5f);

        isMoving = false;
    }


    void Assemble(Vector3 dir)
    {
        if (isMoving) return;

        var anchor = transform.position + (Vector3.down + dir) * 1.1f;
        var axis = Vector3.Cross(Vector3.up, dir);
        Vector3 rotationCenter = transform.position + Vector3.Scale((dir + Vector3.down), GetComponent<Renderer>().bounds.size) / 2;
        StartCoroutine(Roll(anchor, axis));
    }
    void MousePosition2()
    {
        if (mousePos.x >= 327  && mousePos.x <= 1475 && mousePos.y >= 626 && topWallStop == false)
        {

            Assemble(Vector3.forward);

        }
        else if (mousePos.x >= 493  && mousePos.x <= 1476 && mousePos.y <= 360 && bottomWallStop == false)
        {

            Assemble(Vector3.back);

        }

        else if (mousePos.x <= 492 && leftWallStop == false)
        {

            Assemble(Vector3.left);

        }
        else if (mousePos.x >=  1475 && rightWallStop == false)
        {

            Assemble(Vector3.right);

        }
       

        
    }
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TopWall")
        {
            topWallStop = true;
        }
        if (other.tag == "BottomWall")
        {
            bottomWallStop = true;
        }
        if (other.tag == "LeftWall")
        {
            leftWallStop = true;
        }
        if (other.tag == "RightWall")
        {
            rightWallStop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TopWall")
        {
            topWallStop = false;
        }
        if (other.tag == "BottomWall")
        {
            bottomWallStop = false;
        }
        if (other.tag == "LeftWall")
        {
            leftWallStop = false;
        }
        if (other.tag == "RightWall")
        {
            rightWallStop = false;
        }
    }
}
