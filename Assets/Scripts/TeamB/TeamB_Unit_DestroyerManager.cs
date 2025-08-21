using UnityEngine;

public class TeamB_Unit_DestroyerManager : MonoBehaviour
{

    public TeamB_Manager teamManager;

    public TeamB_Unit_DestroyerFSM_Search SearchState = new TeamB_Unit_DestroyerFSM_Search();
    public TeamB_Unit_DestroyerFSM_Move MoveState = new TeamB_Unit_DestroyerFSM_Move();
    public TeamB_Unit_DestroyerFSM_Attack AttackState = new TeamB_Unit_DestroyerFSM_Attack();
    public TeamB_Unit_DestroyerFSM_Death DeathState = new TeamB_Unit_DestroyerFSM_Death();

    public int currentHealth;
    public LayerMask targetLayer;
    public Transform currentTarget;

    Unit_Abstract<TeamB_Unit_DestroyerManager> currentState;

    void Start()
    {

        currentHealth = Team_Base.destroyerMaxHealth;

        currentState = SearchState;

        currentState.EnterState(this);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(Unit_Abstract<TeamB_Unit_DestroyerManager> newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void UnitTakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            SwitchState(DeathState);
        }
    }
}
