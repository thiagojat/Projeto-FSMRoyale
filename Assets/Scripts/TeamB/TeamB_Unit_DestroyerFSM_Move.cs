using UnityEngine;

public class TeamB_Unit_DestroyerFSM_Move : Unit_Abstract<TeamB_Unit_DestroyerManager>
{
    public override void EnterState(TeamB_Unit_DestroyerManager manager)
    {
        
    }

    public override void UpdateState(TeamB_Unit_DestroyerManager manager)
    {
        manager.transform.position = Vector3.MoveTowards(manager.transform.position, manager.currentTarget.position, Team_Base.destroyerMoveSpeed* Time.timeScale);

        CheckDistance(manager);
    }

    void CheckDistance(TeamB_Unit_DestroyerManager manager)
    {
        float distance = Vector3.Distance(manager.transform.position, manager.currentTarget.position);
        if (distance <= Team_Base.destroyerAttackRange)
        {
            manager.SwitchState(manager.AttackState);
        }
    }

    public override void ExitState(TeamB_Unit_DestroyerManager manager)
    {

    }

    public override void OnDrawGizmos(TeamB_Unit_DestroyerManager p_manager)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(p_manager.transform.position, Team_Base.destroyerAttackRange);
    }
}
