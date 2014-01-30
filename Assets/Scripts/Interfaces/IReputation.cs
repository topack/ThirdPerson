public interface IReputation
{
    /// <summary>
    /// Name of the faction
    /// </summary>
    IName Name { get; set; }
    /// <summary>
    /// Level of the reputation
    /// </summary>
    ILevel Level { get; set; }
}
