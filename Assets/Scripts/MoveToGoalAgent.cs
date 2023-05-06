using DefaultNamespace;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MoveToGoalAgent : Agent
{
    [SerializeField] private Transform target;
    [SerializeField] private Character character;
    [SerializeField] private Transform startPoint;

    public override void OnActionReceived(ActionBuffers actions)
    {
        var moveX = actions.ContinuousActions[0];
        var moveZ = actions.ContinuousActions[1];
        character.Move(moveX, moveZ);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Target")
        {
            AddReward(1f);
            Debug.Log($"{other.name}");
            EndEpisode();
        }
        if (other.name == "Wall")
        {
            AddReward(-1f);
            Debug.Log($"{other.name}");
            EndEpisode();
        }
    }

    public override void OnEpisodeBegin()
    {
        Debug.Log("Episode begin");
        transform.position = startPoint.position;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(target.position);
    }
}