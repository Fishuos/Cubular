using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 3;
    private bool isMoving;


    public Transform enemy;
    public Transform player;

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (player.position.z > enemy.position.z)
        {
            Assemble(Vector3.forward);
        }
        else if (player.position.z < enemy.position.z)
        {
            Assemble(Vector3.back);
        }
        else if (player.position.x > enemy.position.x)
        {
            Assemble(Vector3.right);
        }
        else if (player.position.x < enemy.position.x)
        {
            Assemble(Vector3.left);
        }
    }




    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }


        Vector3 pos = transform.position;

        transform.position = new Vector3(
            Mathf.Round(pos.x),
            Mathf.Round(pos.y),
            Mathf.Round(pos.z)
        );

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
}
