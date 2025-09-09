using System.Collections;
using UnityEngine;

public class TeamB_Unit_FighterFSM_Attack : Unit_Abstract<TeamB_Unit_FighterManager>
{
    public override void EnterState(TeamB_Unit_FighterManager manager)
    {

    }

    public override void ExitState(TeamB_Unit_FighterManager manager)
    {

    }

    public override void UpdateState(TeamB_Unit_FighterManager manager)
    {
        CheckDistanceToUnit(manager);

        if(manager.enemyUnit != null)
        {
            AttackUnit(manager);
            return;
        }

        if(Vector3.Distance(manager.enemyTower.transform.position, manager.transform.position) <= Team_Base.fighterAttackRange)
        {
            AttackTower(manager);
            return;
        }

        manager.SwitchState(manager.MoveState);
    }

    void CheckDistanceToUnit(TeamB_Unit_FighterManager manager)
    {
        if (manager.enemyUnit == null) return;

        float distance = Vector3.Distance(manager.transform.position, manager.enemyUnit.transform.position);

        if (distance > Team_Base.fighterSearchRay) manager.enemyUnit = null;
    }

    Coroutine l_attackWait;
    void AttackTower(TeamB_Unit_FighterManager manager)
    {
        if (!m_canAttack) return;

        if (manager.enemyTower != null && manager.enemyTower.TryGetComponent(out TeamA_Health teamAHealth))
        {
            teamAHealth.TakeDamage(Team_Base.fighterAttackDamage);

            l_attackWait = manager.StartCoroutine(AttackWait());
        }
    }

    void AttackUnit(TeamB_Unit_FighterManager manager)
    {
        if (manager.enemyUnit != null && m_canAttack && manager.enemyUnit.TryGetComponent(out Unit_Health unitHealth))
        {
            unitHealth.TakeDamage(Team_Base.fighterAttackDamage);

            l_attackWait = manager.StartCoroutine(AttackWait());
            return;
        }
    }

    bool m_canAttack
    {
        get { return l_attackWait == null; }
    }
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(Team_Base.fighterAttackInterval);
        l_attackWait = null;
    }
}
