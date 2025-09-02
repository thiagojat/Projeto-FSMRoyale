using UnityEngine;

public class TeamB_Unit_FighterFSM_Move : Unit_Abstract<TeamB_Unit_FighterManager>
{
    public override void EnterState(TeamB_Unit_FighterManager manager)
    {

    }

    public override void UpdateState(TeamB_Unit_FighterManager manager)
    {
        if (manager.enemyUnit != null)
        {
            manager.transform.position = Vector3.MoveTowards(manager.transform.position, manager.enemyUnit.transform.position, Team_Base.fighterMoveSpeed);

            CheckDistanceUnit(manager);
            return;
        }

        manager.transform.position = Vector3.MoveTowards(manager.transform.position, manager.enemyTower.position, Team_Base.fighterMoveSpeed);
        CheckDistanceTower(manager);

        Track(manager);
    }

    void CheckDistanceUnit(TeamB_Unit_FighterManager manager)
    {
        float distance = Vector3.Distance(manager.transform.position, manager.enemyUnit.transform.position);

        if (distance <= Team_Base.fighterAttackRange)
            manager.SwitchState(manager.AttackState);
    }

    void CheckDistanceTower(TeamB_Unit_FighterManager manager)
    {
        float distance = Vector3.Distance(manager.transform.position, manager.enemyTower.position);

        if (distance <= Team_Base.fighterAttackRange)
            manager.SwitchState(manager.AttackState);
    }

    public override void ExitState(TeamB_Unit_FighterManager manager)
    {

    }

    RaycastHit[] l_raycastHits;
    Transform l_foundTower, l_foundUnit;
    void Track(TeamB_Unit_FighterManager p_manager)
    {
        l_raycastHits = Physics.RaycastAll(p_manager.transform.position, p_manager.transform.forward, Team_Base.fighterSearchRay, p_manager.targetLayer);

        l_foundTower = null;
        l_foundUnit = null;
        for (int i = 0; i < l_raycastHits.Length; i++)
        {
            if (l_raycastHits[i].collider.CompareTag("TowerA")) l_foundTower = l_raycastHits[i].collider.transform;

            if (l_raycastHits[i].collider.CompareTag("UnitA"))
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


    public override void OnDrawGizmos(TeamB_Unit_FighterManager p_manager)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(p_manager.transform.position, p_manager.transform.forward * Team_Base.fighterSearchRay);
    }
}
