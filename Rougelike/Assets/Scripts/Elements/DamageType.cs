using System.Collections.Generic;

public enum DamageType
{
    None = 0,
    Physical = 1,
    Magic = 2
}

public interface IDamageType
{
    List<DamageType> Strengths { get; set; }
    List<DamageType> Weaknesses { get; set; }
}

