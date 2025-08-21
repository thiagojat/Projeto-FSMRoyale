using UnityEngine;

public class Team_Base : MonoBehaviour
{
    //Propriedades da Base Principal
    public const float unitSpawnTimer = 2f;
    public const int baseHitPoints = 200; 
    
    
    //Propriedades para o Destroyer
    public const float destroyerMoveSpeed = 2f;
    public const float destroyerAttackRange = 1.25f;
    public const float destroyerAttackInterval = 3f;
    public const int destroyerAttackDamage = 20;
    public const int destroyerMaxHealth = 125;
    
    //Propriedades para o Fighter
    public const float fighterMoveSpeed = 4f;
    public const float fighterAttackRange = 1f;
    public const float fighterAttackInterval = 1.25f;
    public const int fighterAttackDamage = 4;
    public const int fighterMaxHealth = 45;
    

}
