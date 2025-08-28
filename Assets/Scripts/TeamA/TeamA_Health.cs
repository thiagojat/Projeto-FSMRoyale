using UnityEngine;

public class TeamA_Health : Team_Base
{
    //Variáveis relativas à Base
    public int baseCurrentHitPoints;

    void Start()
    {
        baseCurrentHitPoints = baseHitPoints;
    }

    void Update()
    {
        if (baseCurrentHitPoints <= 0)
        {
            GameOver();
        }
    }

    public void TakeDamage(int damageHit)
    {
        baseCurrentHitPoints -= damageHit;
    }

    public void GameOver()
    {
        Game_Manager.EndGame("TeamB");
        Destroy(gameObject);
    }
}
