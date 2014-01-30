public interface IReputation
{
    /// <summary>
    /// Name of the reputation
    /// </summary>
    IName Name { get; set; }
    /// <summary>
    /// Type of reputation for the reputation
    /// </summary>
    ReputationType ReputationType { get; set; }
    /// <summary>
    /// Level of the reputation
    /// </summary>
    ILevel Level { get; set; }
}
