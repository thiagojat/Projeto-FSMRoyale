using UnityEngine;

public class TeamA_Unit_DestroyerFSM_Death : Unit_Abstract<TeamA_Unit_DestroyerManager>
{
    public override void EnterState(TeamA_Unit_DestroyerManager manager)
    {
        Object.Destroy(manager.gameObject);
    }

    public override void UpdateState(TeamA_Unit_DestroyerManager manager)
    {
        
    }

    public override void ExitState(TeamA_Unit_DestroyerManager manager)
    {

    }
}
