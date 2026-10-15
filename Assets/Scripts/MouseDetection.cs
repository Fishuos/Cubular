using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetection : MonoBehaviour
{
    Vector2 mousePos;
    

    public bool topLeft;
    public bool topRight; 
    public bool bottomLeft;
    public bool bottomRight;

    private void Update()
    {
        mousePos = Input.mousePosition;
        Debug.Log(mousePos);
      

        MousePosition();
    }

    void MousePosition()
    {
        if (mousePos.x <= 950 && mousePos.y >= 500)
        {
            topLeft = true;

            topRight = false;
            bottomLeft = false;
            bottomRight = false;
        }
        if (mousePos.x >= 951 && mousePos.y >= 500)
        {
            topRight = true;

            topLeft = false;
            bottomLeft = false;
            bottomRight = false;
        }
        if (mousePos.x <= 950 && mousePos.y <= 500)
        {
            bottomLeft = true;

            topLeft = false;
            topRight = false;
            bottomRight = false;
        }
        if (mousePos.x >= 951 && mousePos.y <= 500)
        {
            bottomRight = true;

            topLeft = false;
            topRight = false;
            bottomLeft = false;
        }

        
    }

}
