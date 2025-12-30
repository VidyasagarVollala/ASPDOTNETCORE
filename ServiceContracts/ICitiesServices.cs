namespace ServiceContracts
{
    public interface ICitiesServices
    {
        Guid InstanceId { get; }
        List<string> GetCities();

    }
}
