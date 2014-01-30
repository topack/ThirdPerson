public interface IAttribute
{
    string Name { get; set; };
    float Value { get; set; };
    float MaximumValue { get; set; };
    
    void Add();
    void UpdateValue();
}
