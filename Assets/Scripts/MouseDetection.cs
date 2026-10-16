using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MouseDetection : MonoBehaviour
{
    Vector2 mousePos;
    
    
   
 

    [SerializeField] private float rollSpeed = 3;
    private bool isMoving;
    public bool topLeft;
    public bool topRight; 
    public bool bottomLeft;
    public bool bottomRight;




    private void Update()
    {
        mousePos = Input.mousePosition;
        //   Debug.Log(mousePos);

       

        






        MousePosition();
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

    void MousePosition()
    {
        if (mousePos.x <= 950 && mousePos.y >= 500)
        {

            Assemble(Vector3.forward);




            topLeft = true;
            topRight = false;
            bottomLeft = false;
            bottomRight = false;
        }
        else if (mousePos.x >= 951 && mousePos.y >= 500)
        {
            Assemble(Vector3.right);



            topRight = true;
            topLeft = false;
            bottomLeft = false;
            bottomRight = false;
        }
       else  if (mousePos.x <= 950 && mousePos.y <= 500)
        {
            Assemble(Vector3.left);

            bottomLeft = true;
            topLeft = false;
            topRight = false;
            bottomRight = false;
        }
       else  if (mousePos.x >= 951 && mousePos.y <= 500)
        {
            Assemble(Vector3.back);

            bottomRight = true;
            topLeft = false;
            topRight = false;
            bottomLeft = false;
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        isMoving = false;
        Debug.Log("entertrigger");
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
