public class Undead : Enemy
{
    public override void Start()
    {
        base.Start();

        enemyType = EnemyType.Undead;
        AddBaseWeaknesses();
        AddBaseResistances();
    }

    public void AddBaseWeaknesses()
    {
        weaknesses.Add(new Holy());
    }

    public void AddBaseResistances()
    {
        resistances.Add(new Fire());
    }

    public void AddBaseImmunities()
    {

    }

    public void AddBaseAdvantages()
    {
        advantages.Add(new Shadow());
    }
}

