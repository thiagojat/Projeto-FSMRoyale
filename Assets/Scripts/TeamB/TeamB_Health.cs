using UnityEngine;

public class TeamB_Health : Team_Base
{
    //Variáveis relativas à Base
    public int baseCurrentHitPoints = baseHitPoints;

    void Start()
    {

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
        Destroy(gameObject);
    }
}
