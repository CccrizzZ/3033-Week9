using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Health;

public class ZombieAttackState : ZombieState
{
    private GameObject FollowTarget;

    private float AttackRange = 2.0f;


    private IDamagable DamagableObject;


    private static readonly int MovementHash = Animator.StringToHash("Z_Movement");
    private static readonly int IsAttackingHash = Animator.StringToHash("Z_Attacking");

    public ZombieAttackState(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;

        DamagableObject = followTarget.GetComponent<IDamagable>();

    }

    public override void Start()
    {
        Z_Component.Z_NavMesh.isStopped = true;
        Z_Component.Z_NavMesh.ResetPath();
        Z_Component.Z_Animator.SetFloat(MovementHash, 0.0f);
        Z_Component.Z_Animator.SetBool(IsAttackingHash, true); 

    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        if (!FollowTarget) return;


        DamagableObject?.TakeDamage(Z_Component.Z_Damage);
    }

    public override void Update()
    {
        if (!FollowTarget) 
        {
            StateMachine.ChanceState(ZombieStateType.Idle);
            return;
        }

        Z_Component.transform.LookAt(FollowTarget.transform.position, Vector3.up);

        float distanceBetween = Vector3.Distance(Z_Component.transform.position, FollowTarget.transform.position);
        if (distanceBetween > AttackRange)
        {
            // Debug.Log("inrange");
            StateMachine.ChanceState(ZombieStateType.Follow);
        }

    }

    public override void Exit()
    {
        base.Exit();
        Z_Component.Z_Animator.SetBool(IsAttackingHash, false);
    }
}
