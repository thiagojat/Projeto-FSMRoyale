using UnityEngine;

public class TeamA_Unit_DestroyerFSM_Search : Unit_Abstract<TeamA_Unit_DestroyerManager>
{

    public override void EnterState(TeamA_Unit_DestroyerManager manager)
    {
        Search(manager);
    }

    public override void UpdateState(TeamA_Unit_DestroyerManager manager)
    {

    }
    public override void ExitState(TeamA_Unit_DestroyerManager manager)
    {

    }

    RaycastHit[] l_raycastHits;
    void Search(TeamA_Unit_DestroyerManager p_manager)
    {
        l_raycastHits = Physics.RaycastAll(p_manager.transform.position, p_manager.transform.forward, Team_Base.destroyerSearchRay, p_manager.targetLayer);

        for (int i = 0; i < l_raycastHits.Length; i++)
        {
            if (l_raycastHits[i].collider.CompareTag("TowerB"))
            {
                p_manager.currentTarget = l_raycastHits[i].transform;
                p_manager.SwitchState(p_manager.MoveState);
            }
        }

    }

    public override void OnDrawGizmos(TeamA_Unit_DestroyerManager p_manager)
    {
    }

}
