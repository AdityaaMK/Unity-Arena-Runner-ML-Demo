using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Animator enemyAnimator;
    //int direction = 2;
    bool alive = true;
    bool pathDown;
    //      0
    //   3      1
    //      2
    //enum dir
    //{
    //    left, right, up, down
    //}

    //dir playerDir;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        //playerDir = dir.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if(transform.localPosition.y >= 1.5)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(90, -90, 90));
                pathDown = true;
            }
            if (pathDown)
            {
                transform.Translate(Vector3.down / 80, Space.World);
            }
            else
            {
                transform.Translate(Vector3.up / 80, Space.World);
            }
            if (transform.localPosition.y <= -8.5)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(-90, -90, 90));
                pathDown = false;
            }
            enemyAnimator.SetBool("walk", true);
        }
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    if (direction == 3 || direction == 0 || direction == 1)
        //    {
        //        direction = 2;
        //        transform.localRotation = Quaternion.Euler(new Vector3(90, -90, 90));
        //        //playerDir = dir.down;
        //    }
        //    transform.Translate(Vector3.down / 70, Space.World);
        //    enemyAnimator.SetBool("walk", true);
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    if (direction == 0 || direction == 1 || direction == 2)
        //    {
        //        direction = 3;
        //        transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
        //        //transform.localScale = new Vector3(1f, 1f, 1f);
        //        //playerDir = dir.left;
        //    }
        //    transform.Translate(Vector3.left / 70, Space.World);
        //    enemyAnimator.SetBool("walk", true);
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    if (direction == 0 || direction == 2 || direction == 3)
        //    {
        //        direction = 1;
        //        transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        //        //transform.localScale = new Vector3(1f, 1f, -1f);
        //        //playerDir = dir.right;
        //    }
        //    transform.Translate(Vector3.right / 70, Space.World);
        //    enemyAnimator.SetBool("walk", true);
        //}
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    if (direction == 3 || direction == 2 || direction == 1)
        //    {
        //        direction = 0;
        //        transform.localRotation = Quaternion.Euler(new Vector3(-90, -90, 90));
        //        //playerDir = dir.down;
        //    }
        //    transform.Translate(Vector3.up / 70, Space.World);
        //    enemyAnimator.SetBool("walk", true);
        //}
        //else
        //{
        //    enemyAnimator.SetBool("walk", false);
        //}
    }
}
