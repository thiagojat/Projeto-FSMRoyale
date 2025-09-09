using UnityEngine;

public class TeamA_Unit_DestroyerFSM_Move : Unit_Abstract<TeamA_Unit_DestroyerManager>
{
    public override void EnterState(TeamA_Unit_DestroyerManager manager)
    {

    }

    public override void UpdateState(TeamA_Unit_DestroyerManager manager)
    {
        manager.transform.position = Vector3.MoveTowards(manager.transform.position, manager.currentTarget.position, Team_Base.destroyerMoveSpeed * Time.timeScale);

        CheckDistance(manager);
    }

    void CheckDistance(TeamA_Unit_DestroyerManager manager)
    {
        float distance = Vector3.Distance(manager.transform.position, manager.currentTarget.position);
        if (distance <= Team_Base.destroyerAttackRange)
        {
            manager.SwitchState(manager.AttackState);
        }
    }

    public override void ExitState(TeamA_Unit_DestroyerManager manager)
    {

    }
}
