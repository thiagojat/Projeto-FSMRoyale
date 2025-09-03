using UnityEngine;

public class TeamB_Unit_FighterFSM_Move : Unit_Abstract<TeamB_Unit_FighterManager>
{
    public override void EnterState(TeamB_Unit_FighterManager manager)
    {
        if (manager.debug) Debug.Log("EnterState MOVE");
    }

    public override void UpdateState(TeamB_Unit_FighterManager manager)
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

    void CheckDistanceUnit(TeamB_Unit_FighterManager manager)
    {
        float distance = Vector3.Distance(manager.transform.position, manager.enemyUnit.transform.position);

        if (distance <= Team_Base.fighterSearchRay)
            manager.SwitchState(manager.AttackState);
    }

    void CheckDistanceTower(TeamB_Unit_FighterManager manager)
    {
        if (manager.enemyTower == null) return;

        float distance = Vector3.Distance(manager.transform.position, manager.enemyTower.position);

        if (distance <= Team_Base.fighterSearchRay)
            manager.SwitchState(manager.AttackState);
    }

    public override void ExitState(TeamB_Unit_FighterManager manager)
    {

    }

    RaycastHit[] l_raycastHits;
    Transform l_foundUnit;
    void Track(TeamB_Unit_FighterManager manager)
    {
        l_raycastHits = Physics.SphereCastAll(manager.transform.position, Team_Base.fighterSearchRay, manager.transform.forward, 0f, manager.targetLayer);

        l_foundUnit = null;
        for (int i = 0; i < l_raycastHits.Length; i++)
        {
            if (l_raycastHits[i].collider.CompareTag("TowerA")) continue;

            if (l_raycastHits[i].collider.CompareTag("UnitA"))
            {
                l_foundUnit = l_raycastHits[i].collider.transform;
                break;
            }
        }

        if (l_foundUnit)
        {
            manager.enemyUnit = l_foundUnit.gameObject;
            return;
        }
    }

    public override void OnDrawGizmos(TeamB_Unit_FighterManager p_manager)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(p_manager.transform.position, Team_Base.fighterSearchRay);
    }
}
