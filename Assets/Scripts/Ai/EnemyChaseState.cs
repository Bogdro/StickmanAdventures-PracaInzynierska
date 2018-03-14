using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyAbstractState
{

    public override void OnEnter(EnemyScript enemy)
    {
        enemy.warnIndicator.SetActive(true);
    }

    public override void Update(EnemyScript enemy)
    {
        Collider2D player = enemy.PlayerInFielOfView();
        if (player != null)
        {
            if (enemy.IsOnPlatform())
            {
                enemy.ChasePlayer(player);
            }
            else
            {
                //powrót do patrolowania
                enemy.FlipEnemy(enemy.direction*-1);
                ChangeState(enemy, enemy.patrolState);

            }
        }
        else
        {
            //powrót do patrolowania
            ChangeState(enemy, enemy.patrolState);
        }
    }
}
