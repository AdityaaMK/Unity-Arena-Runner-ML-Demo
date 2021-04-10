using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class HeroLearningScript : Agent
{
    public Transform enemy, enemy2, enemy3, enemy4, enemy5;
    private Vector2 startingEnemyPosition, e2, e3;
    private Vector2 startingHeroPosition;
    private HeroMovement heroMovement;
    public GameObject goal;
    int count;

    public void Start()
    {
        startingHeroPosition = transform.position;
        startingEnemyPosition = enemy.position;
        e2 = enemy2.position;
        e3 = enemy3.position;
    }

    public override void OnEpisodeBegin()
    {
        count = 7000;
        heroMovement = GetComponent<HeroMovement>();
        transform.position = startingHeroPosition;
        enemy.position = startingEnemyPosition;
        enemy2.position = e2;
        enemy3.position = e3;
        //transform.localPosition = new Vector3(-9, -4f, 0);
        //enemy.localPosition = new Vector3(12.1f, 0, 0);
        //enemy2.localPosition = new Vector3(1.9f, -2, 0);
        //enemy3.localPosition = new Vector3(7.1f, -1, 0);
        //enemy5.localPosition = new Vector3(9.9f, 3, 0);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //count = 0;
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(enemy.transform.localPosition);
        sensor.AddObservation(enemy2.transform.localPosition);
        sensor.AddObservation(enemy3.transform.localPosition);
        //sensor.AddObservation(enemy4.transform.localPosition);
        //sensor.AddObservation(enemy5.transform.localPosition);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        //transform.Translate(new Vector3(vectorAction[0] * Time.deltaTime, 0, vectorAction[1] * Time.deltaTime));
        count--;
        //Debug.Log(count);
        if(count == 0)
        {
            AddReward(-0.1f);
            EndEpisode();
        }

        float moveX = vectorAction[0]; // 0 = Dont Move; 1 = Left; 2 = Right
        float moveY = vectorAction[1]; // 0 = Dont Move; 1 = Down; 2 = Up

        float forwardAmount = 0f;
        float upAmount = 0f;

        switch (moveX)
        {
            case 0: forwardAmount = 0f; break;
            case 1: forwardAmount = -1f; break;
            case 2: forwardAmount = +1f; break;
        }

        switch (moveY)
        {
            case 0: upAmount = 0f; break;
            case 1: upAmount = -1f; break;
            case 2: upAmount = +1f; break;
        }

        float distance = Vector3.Distance(transform.position, goal.transform.position);

        heroMovement.SetInputs(forwardAmount, upAmount);
        //transform.Translate(Vector3.right * forwardAmount * Time.deltaTime, Space.World);
        //transform.Translate(Vector3.up * upAmount * Time.deltaTime, Space.World);

        float newDistance = Vector3.Distance(transform.position, goal.transform.position);

        if(newDistance < distance)
        {
            AddReward(0.01f);
        }
        else if(newDistance > distance)
        {
            AddReward(-0.01f);
        }
        
        
    }

    public override void Heuristic(float[] actionsOut)
    {
        int forwardAction = 0;
        int upAction = 0;

        if (Input.GetKey(KeyCode.UpArrow))
            upAction = 2;
        if (Input.GetKey(KeyCode.DownArrow))
            upAction = 1;
        if (Input.GetKey(KeyCode.RightArrow))
            forwardAction = 2;
        if (Input.GetKey(KeyCode.LeftArrow))
            forwardAction = 1;

        actionsOut[0] = forwardAction;
        actionsOut[1] = upAction;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision");
        if (collision.gameObject.tag == "Wall")
        {
            AddReward(-0.01f);
            Debug.Log("Wall");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            AddReward(-100f);
            EndEpisode();
            Debug.Log("Enemy");
        }
        if (collision.gameObject.tag == "End")
        {
            AddReward(count);
            EndEpisode();
            Debug.Log("End");
        }
    }
}
