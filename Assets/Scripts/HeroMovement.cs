using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    Animator animator;
    Vector3 previousPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        Debug.Log(velocity.magnitude);

        if(Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("walk", true);
            faceDown();
            if (transform.position.y > -6.5)
            {
                transform.Translate(new Vector2(0, -2) / 70, Space.World);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("walk", true);
            faceLeft();

            if (transform.position.x > -13)
            {
                transform.Translate(new Vector2(-2, 0) / 70, Space.World);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("walk", true);
            faceRight();

            if (transform.position.x < 12)
            {
                transform.Translate(new Vector2(2, 0) / 70, Space.World);
            }
           
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("walk", true);
            faceUp();
            if (transform.position.y < 3.5)
            {
                transform.Translate(new Vector2(0, 2) / 70, Space.World);
            }
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    private void faceDown()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
    private void faceUp()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    private void faceLeft()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
    }
    private void faceRight()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
    }

    public void SetInputs(float forwardAmount, float upAmount)
    {
        animator = GetComponent<Animator>();
        transform.Translate(Vector3.right * forwardAmount * Time.deltaTime * speed, Space.World);
        transform.Translate(Vector3.up * upAmount * Time.deltaTime * speed, Space.World);
        if(forwardAmount > 0)
        {
            faceRight();
        }
        else if(forwardAmount < 0)
        {
            faceLeft();
        }
        if(upAmount > 0)
        {
            faceUp();
        }
        else if(upAmount < 0)
        {
            faceDown();
        }
        if (upAmount != 0 || forwardAmount != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision");
    //    if (collision.gameObject.tag.Equals("Wall"))
    //    {
    //        //AddReward(-0.5f);
    //        Debug.Log("Wall");
    //    }
    //    else if (collision.gameObject.tag.Equals("Enemy"))
    //    {
    //        //AddReward(-0.5f);
    //        //EndEpisode();
    //        Debug.Log("Enemy");
    //    }
    //    else if (collision.gameObject.tag.Equals("End"))
    //    {
    //        //AddReward(2f);
    //        //EndEpisode();
    //        Debug.Log("End");
    //    }
    //}

}
