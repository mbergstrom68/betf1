
public class CircuitsService : ICircuitService
{
    public CircuitsService()
    {
        
    }

    public Task<IEnumerable<Circuit>> GetCircuitsAsync()
    {
        List<Circuit> circuitList = new List<Circuit>
        {
            new Circuit {CircuitId = 1, CircuitRef = "monza", Name = "Monza" },
            new Circuit {CircuitId = 2, CircuitRef = "imola", Name = "Imola" },
            new Circuit {CircuitId = 3, CircuitRef = "spa", Name = "Spa" },
            new Circuit {CircuitId = 4, CircuitRef = "silver", Name = "Silverstone" }
        };

        return Task.FromResult<IEnumerable<Circuit>>(circuitList);
    }
}
