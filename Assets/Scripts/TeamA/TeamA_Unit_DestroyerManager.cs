using UnityEngine;

public class TeamA_Unit_DestroyerManager : MonoBehaviour
{

    public TeamA_Manager teamManager;

    public TeamA_Unit_DestroyerFSM_Search SearchState = new TeamA_Unit_DestroyerFSM_Search();
    public TeamA_Unit_DestroyerFSM_Move MoveState = new TeamA_Unit_DestroyerFSM_Move();
    public TeamA_Unit_DestroyerFSM_Attack AttackState = new TeamA_Unit_DestroyerFSM_Attack();
    public TeamA_Unit_DestroyerFSM_Death DeathState = new TeamA_Unit_DestroyerFSM_Death();

    public int currentHealth;
    public LayerMask targetLayer;
    public Transform currentTarget;

    Unit_Abstract <TeamA_Unit_DestroyerManager> currentState;

    void Start()
    {
        gameObject.SetActive(true);

        currentHealth = Team_Base.destroyerMaxHealth;

        currentState = SearchState;

        currentState.EnterState(this);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(Unit_Abstract<TeamA_Unit_DestroyerManager> newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void DamageTaken(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            SwitchState(DeathState);
        }
    }
}
