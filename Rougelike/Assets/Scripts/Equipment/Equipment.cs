public enum EquipmentType
{
    None   = 0,
    Weapon = 1,
    Armor  = 2
}

public class Equipment : DamageModifier
{
    public IStats stats = new Stats();
    public EquipmentType equipmentType;
    public Element element { get; set; }

    public string equipmentName;

    public Equipment()
    {
        stats.HP = 0;
        stats.MP = 0;
        stats.PhysAtk = 0;
        stats.MagAtk = 0;
        stats.Speed = 0;
    }
    
    public Equipment(EquipmentType _equipmentType)
    {
        stats.HP = 0;
        stats.MP = 0;
        stats.PhysAtk = 0;
        stats.MagAtk = 0;
        stats.Speed = 0;

        equipmentType = _equipmentType;
    }

    public void OnPickUp()
    {

    }
}

