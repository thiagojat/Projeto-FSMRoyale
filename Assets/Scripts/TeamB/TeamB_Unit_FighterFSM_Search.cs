using UnityEngine;

public class TeamB_Unit_FighterFSM_Search : Unit_Abstract<TeamB_Unit_FighterManager>
{
    public override void EnterState(TeamB_Unit_FighterManager manager)
    {

    }

    public override void ExitState(TeamB_Unit_FighterManager manager)
    {

    }

    public override void UpdateState(TeamB_Unit_FighterManager manager)
    {

    }

    RaycastHit[] l_raycastHits;
    void Search(TeamB_Unit_DestroyerManager p_manager)
    {
        l_raycastHits = Physics.RaycastAll(p_manager.transform.position, p_manager.transform.forward, Team_Base.destroyerAttackRange, p_manager.targetLayer);

        for (int i = 0; i < l_raycastHits.Length; i++)
        {
            if (l_raycastHits[i].collider.CompareTag("TowerA"))
            {
                p_manager.currentTarget = l_raycastHits[i].transform;
                p_manager.SwitchState(p_manager.MoveState);
            }
        }

    }

    public override void OnDrawGizmos(TeamB_Unit_FighterManager p_manager)
    {
    }
}
