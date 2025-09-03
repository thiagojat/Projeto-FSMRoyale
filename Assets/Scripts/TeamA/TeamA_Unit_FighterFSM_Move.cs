using UnityEngine;

public class TeamA_Unit_FighterFSM_Move : Unit_Abstract<TeamA_Unit_FighterManager>
{
    public override void EnterState(TeamA_Unit_FighterManager manager)
    {

    }

    public override void UpdateState(TeamA_Unit_FighterManager manager)
    {
        if (manager.enemyUnit != null)
        {
            manager.transform.position = Vector3.MoveTowards(manager.transform.position, manager.enemyUnit.transform.position, Team_Base.fighterMoveSpeed * Time.timeScale);

            CheckDistanceUnit(manager);
            return;
        }

        manager.transform.position = Vector3.MoveTowards(manager.transform.position, manager.enemyTower.position, Team_Base.fighterMoveSpeed * Time.timeScale);
        CheckDistanceTower(manager);

        Track(manager);
    }

    void CheckDistanceUnit(TeamA_Unit_FighterManager manager)
    {
        float distance = Vector3.Distance(manager.transform.position, manager.enemyUnit.transform.position);

        if (distance <= Team_Base.fighterSearchRay)
            manager.SwitchState(manager.AttackState);
    }

    void CheckDistanceTower(TeamA_Unit_FighterManager manager)
    {
        float distance = Vector3.Distance(manager.transform.position, manager.enemyTower.position);

        if (distance <= Team_Base.fighterSearchRay)
            manager.SwitchState(manager.AttackState);
    }


    public override void ExitState(TeamA_Unit_FighterManager manager)
    {

    }

    RaycastHit[] l_raycastHits;
    Transform l_foundTower, l_foundUnit;
    void Track(TeamA_Unit_FighterManager p_manager)
    {
        l_raycastHits = Physics.RaycastAll(p_manager.transform.position, p_manager.transform.forward, Team_Base.fighterSearchRay, p_manager.targetLayer);

        l_foundTower = null;
        l_foundUnit = null;
        for (int i = 0; i < l_raycastHits.Length; i++)
        {
            if (l_raycastHits[i].collider.CompareTag("TowerB")) l_foundTower = l_raycastHits[i].collider.transform;

            if (l_raycastHits[i].collider.CompareTag("UnitB"))
            {
                l_foundUnit = l_raycastHits[i].collider.transform;
                break;
            }
        }

        if (l_foundUnit)
        {
            p_manager.enemyUnit = l_foundUnit.gameObject;
            return;
        }
    }
    public override void OnDrawGizmos(TeamA_Unit_FighterManager p_manager)
    {

    }
}
