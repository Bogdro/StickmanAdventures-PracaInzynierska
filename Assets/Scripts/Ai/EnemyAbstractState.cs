using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstractState  {

    public virtual void OnEnter(EnemyScript enemy) { }
    public virtual void ChangeState(EnemyScript enemy, EnemyAbstractState state) {
        enemy.state = state;
        enemy.state.OnEnter(enemy);
    }
    public abstract void Update(EnemyScript enemy);
}
