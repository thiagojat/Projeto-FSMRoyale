using UnityEngine;
using System.Collections;

public class TeamA_Unit_FighterFSM_Attack : Unit_Abstract<TeamA_Unit_FighterManager>
{
    public override void EnterState(TeamA_Unit_FighterManager manager)
    {

    }

    public override void UpdateState(TeamA_Unit_FighterManager p_manager)
    {
        CheckDistanceToUnit(p_manager);

        if (p_manager.enemyUnit != null)
        {
            AttackUnit(p_manager);
            return;
        }

        if (Vector3.Distance(p_manager.enemyTower.transform.position, p_manager.transform.position) <= Team_Base.fighterAttackRange)
        {
            AttackTower(p_manager);
            return;
        }

        p_manager.SwitchState(p_manager.MoveState);

    }
    void CheckDistanceToUnit(TeamA_Unit_FighterManager p_manager)
    {
        if (p_manager.enemyUnit == null) return;

        float distance = Vector3.Distance(p_manager.transform.position, p_manager.enemyUnit.transform.position);

        if (distance > Team_Base.fighterSearchRay) p_manager.enemyUnit = null;
    }

    Coroutine l_attackWait;
    void AttackTower(TeamA_Unit_FighterManager manager)
    {
        if (!m_canAttack) return;

        manager.enemyTower.GetComponent<TeamB_Health>().TakeDamage(Team_Base.fighterAttackDamage);

        l_attackWait = manager.StartCoroutine(AttackWait());
    }

    void AttackUnit(TeamA_Unit_FighterManager manager)
    {
        if (manager.enemyUnit != null && m_canAttack)
        {
            manager.enemyUnit.GetComponent<Unit_Health>().TakeDamage(Team_Base.fighterAttackDamage);

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

    public override void ExitState(TeamA_Unit_FighterManager manager)
    {

    }

    public override void OnDrawGizmos(TeamA_Unit_FighterManager p_manager)
    {
    }
}
