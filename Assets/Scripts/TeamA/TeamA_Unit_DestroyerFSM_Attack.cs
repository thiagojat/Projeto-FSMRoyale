using System.Collections;
using UnityEngine;


public class TeamA_Unit_DestroyerFSM_Attack : Unit_Abstract<TeamA_Unit_DestroyerManager>
{
    public override void EnterState(TeamA_Unit_DestroyerManager manager)
    {

    }

    public override void UpdateState(TeamA_Unit_DestroyerManager manager)
    {

    }

    Coroutine l_attackWait;
    void Attack(TeamA_Unit_DestroyerManager manager)
    {
        if (!m_canAttack) return;

        manager.currentTarget.GetComponent<TeamB_Health>().TakeDamage(Team_Base.destroyerAttackDamage);

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

    public override void ExitState(TeamA_Unit_DestroyerManager manager)
    {

    }
}
