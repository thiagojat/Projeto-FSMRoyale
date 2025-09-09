using UnityEngine;

public abstract class Unit_Abstract<ManagerType>
{
    public abstract void EnterState(ManagerType manager);

    public abstract void UpdateState(ManagerType manager);

    public abstract void ExitState(ManagerType manager);
}
