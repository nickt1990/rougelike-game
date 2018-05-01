using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public interface ISkill
{
    string name { get; set; }
    int damage { get; set; }
    DamageType damageType { get; set; }
    IElement element { get; set; }

    void Cast(Enemy target);
}

public class DoubleStab : ISkill
{
    public string name { get; set; }
    public int damage { get; set; }

    public IElement element { get; set; }
    public DamageType damageType { get; set; }

    public List<IElement> strengths { get; set; }

    public List<IElement> weaknesses { get; set; }

    public DoubleStab()
    {
        name = "Double Stab";
        damage = 15;
        damageType = DamageType.Physical;
    }

    public void Cast(Enemy target)
    {
        throw new NotImplementedException();
    }
}

public class FireBall : ISkill
{
    public string name { get; set; }
    public int damage { get; set; }
    public DamageType damageType { get; set; }
    public IElement element { get; set; }
    public FireBall()
    {
        name = "Fireball";
        damage = 30;
        element = new Fire();
    }
    public void Cast(Enemy target)
    {
        int elementalDamage = 0; //Damage that is modified based on elemental strengths and weaknesses

        elementalDamage = CalculateDamage(target);

        target.TakeDamage(elementalDamage);

    }
    /// <summary>
    /// This method will calculate damage depending on the enemies strengths and weaknesses
    /// </summary>
    /// <returns></returns>
    public int CalculateDamage(Enemy target)
    {
        int modifiedDamage = damage;

        // Check if skill is strong against enemy
        foreach (Element anElement in element.Strengths)
        {
            if (target.ElementalWeaknesses.Contains(anElement))   // If the enemy is weak to the element, then...
            {
                // Damage is doubled
                modifiedDamage = modifiedDamage * 2;
            }
        }
        
        // Check if skill is weak against enemy
        foreach (Element anElement in element.Weaknesses)
        {
            if (target.ElementalResistances.Contains(anElement))    // If enemy has resistance to element, then...
            {
                // Damage is halved
                modifiedDamage = (int)(modifiedDamage * .5);
            }
        }

        return modifiedDamage;
    }
}
public class Heal : ISkill
{
    public string name { get; set; }
    public int damage { get; set; }

    public IElement element { get; set; }

    public DamageType damageType { get; set; }

    public Heal()
    {
        name = "Heal";
        damage = -60;
        damageType = DamageType.Magic;
        element = new Holy();
    }

    public int CalculateDamage(Enemy target)
    {
        int modifiedDamage = damage;

        if (target.ElementalWeaknesses.Contains(Element.Holy))    // If enemy has resistance to element, then...
        {
            // Damage is halved
            modifiedDamage = (int)(-(modifiedDamage) * 2);
        }

        return modifiedDamage;
    }

    public void Cast(Enemy target)
    {
        int elementalDamage = 0; //Damage that is modified based on elemental strengths and weaknesses

        elementalDamage = CalculateDamage(target);

        target.TakeDamage(elementalDamage);
    }
}


