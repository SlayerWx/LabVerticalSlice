using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class ChaserEnemy : BaseEnemy
{
    NavMeshAgent agent;
    public delegate Vector3 SearchTargetLocation();
    public static event SearchTargetLocation OnSearchTargetLocation;
    public override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }
    private void LateUpdate()
    {
        agent.SetDestination((Vector3)OnSearchTargetLocation?.Invoke());
    }
}
