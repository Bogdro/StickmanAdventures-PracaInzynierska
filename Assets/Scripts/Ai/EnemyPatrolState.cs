using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyAbstractState {

    EnemyScript enemy;

    public override void OnEnter(EnemyScript enemy)
    {
        enemy.warnIndicator.SetActive(false);
    }

    public override void Update(EnemyScript enemy)
    {
            if (enemy.PlayerInFielOfView() != null)
            {
                ChangeState(enemy, enemy.chaseState);
            }
            else
            {
                enemy.EnemyMovement();
            }
    }    
}
