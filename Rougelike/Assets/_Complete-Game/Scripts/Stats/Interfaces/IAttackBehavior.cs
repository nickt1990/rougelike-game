using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackBehavior
{
    void Attack();
}

public class CannotAttack : IAttackBehavior
{
    public void Attack()
    {
        // Logic for being unable to attack
    }
}

public class CanAttackWithBar : IAttackBehavior
{
    public void Attack()
    {
        // Logic for attacking with the bar above your head (for the players)
    }
}

public class CanAttackWithoutBar : IAttackBehavior
{
    public void Attack()
    {
        // Logic for attacking without the bar above you head (for the enemies)
    }
}

