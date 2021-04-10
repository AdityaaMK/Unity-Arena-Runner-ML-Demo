using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class PathFinder : Agent
{
    public GameObject enemy;

    public override void OnActionReceived(float[] vectorAction)
    {
        float xMove = vectorAction[0];
        float yMove = vectorAction[1];

        //transform.Translate(new Vector2(xMove, yMove));
        transform.position += new Vector3(xMove, yMove) * Time.deltaTime;
    }

    public override void OnEpisodeBegin()
    {

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(enemy.transform.position);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
