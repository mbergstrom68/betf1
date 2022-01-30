 public class Circuit
 {
     public int CircuitId { get; set; }
     public string CircuitRef { get; set; }
     public string Name { get; set; }

    public Circuit()
        :this(0, string.Empty, string.Empty)
    {
        
    }
    public Circuit(int circuitId, string circuitRef, string name)
    {
        CircuitRef = circuitRef;
        CircuitId = circuitId;
        Name = name;
    }
}