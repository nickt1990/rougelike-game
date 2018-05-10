public class Undead : Enemy
{
    public override void Start()
    {
        base.Start();
        
        AddStrengthsAndWeakness();
    }

    private void AddStrengthsAndWeakness()
    {
        AddBaseWeaknesses();
        AddBaseResistances();
        AddBaseImmunities();
        AddBaseAdvantages();
    }

    private void AddBaseWeaknesses()
    {
        weaknesses.Add(new Holy());
    }

    private void AddBaseResistances()
    {
        resistances.Add(new Fire());
    }

    private void AddBaseImmunities()
    {

    }

    private void AddBaseAdvantages()
    {

    }
}

