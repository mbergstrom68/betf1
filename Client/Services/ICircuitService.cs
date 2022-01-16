public interface ICircuitService
{
    Task<IEnumerable<Circuit>> GetCircuitsAsync();
}