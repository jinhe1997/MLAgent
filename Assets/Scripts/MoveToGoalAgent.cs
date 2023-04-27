using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MoveToGoalAgent : Agent
{
    public override void OnActionReceived(ActionBuffers actions)
    {
        base.OnActionReceived(actions);
        Debug.Log(actions.DiscreteActions[0]);
    }
}