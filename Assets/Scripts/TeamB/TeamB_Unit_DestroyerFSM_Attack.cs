using System.Collections;
using UnityEngine;

public class TeamB_Unit_DestroyerFSM_Attack : Unit_Abstract<TeamB_Unit_DestroyerManager>
{
    public override void EnterState(TeamB_Unit_DestroyerManager manager)
    {

    }

    public override void UpdateState(TeamB_Unit_DestroyerManager manager)
    {
        Attack(manager);
    }

    Coroutine l_attackWait;
    void Attack(TeamB_Unit_DestroyerManager manager)
    {
        if (!m_canAttack) return;

        manager.currentTarget.GetComponent<TeamA_Health>().TakeDamage(Team_Base.destroyerAttackDamage);

        l_attackWait = manager.StartCoroutine(AttackWait());
    }

    bool m_canAttack
    {
        get { return l_attackWait == null; }
    }
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(Team_Base.destroyerAttackInterval);
        l_attackWait = null;
    }

    public override void ExitState(TeamB_Unit_DestroyerManager manager)
    {

    }

    public override void OnDrawGizmos(TeamB_Unit_DestroyerManager p_manager)
    {
    }
}
