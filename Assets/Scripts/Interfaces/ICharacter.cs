public interface ICharacter
{
    /// <summary>
    /// Name of the character
    /// </summary>
    IName Name { get; set; }
    /// <summary>
    /// Level of the character
    /// </summary>
    ILevel { get; set; }
    /// <summary>
    /// Faction of the character
    /// </summary>
    FactionType Faction { get; set; }
    /// <summary>
    /// Attribute list of the character
    /// </summary>
    IAttribute[] Attributes { get; set; }
    /// <summary>
    /// Spell List of the character
    /// </summary>
    ISpell[] Spells { get; set; }
    /// <summary>
    /// Aura List of the character
    /// </summary>
    ISpell[] Auras { get; set; }
    /// <summary>
    /// Reputation list of the character
    /// </summary>
    IReputation[] Reputations { get; set; }
}
