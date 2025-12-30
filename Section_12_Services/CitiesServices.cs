using ServiceContracts;

namespace Section_12_Services
{
    public class CitiesServices :ICitiesServices, IDisposable
    {
        private List<string>   _cities;
        private Guid _instanceId;

        public Guid InstanceId { get { return _instanceId; } }

        public CitiesServices()
        {
            _instanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "Hyderabad",
                "Karimnagar",
                "Jagityal"
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            //
        }
    }
}
