namespace RAS.Bootcamp.Api.Net {
    public interface IGuidRandom {
        Guid GetRandomString();
    }
    public class GuidRandom : IGuidRandom {
        private Guid _randomString;
        public GuidRandom()
        {
            _randomString = Guid.NewGuid();
        }

        public Guid GetRandomString()
        {
            return _randomString;
        }
    }
}