using DefaultNamespace;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MoveToGoalAgent : Agent
{
    [SerializeField] private Transform target;
    [SerializeField] private Character _character;
    public override void OnActionReceived(ActionBuffers actions)
    {
        var moveX = actions.ContinuousActions[0];
        var moveZ = actions.ContinuousActions[1];
        _character.Move(moveX, moveZ);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Target")
        {
            AddReward(1f);
            EndEpisode();
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(target.position);
    }

    public override void OnEpisodeBegin() { }
}