using Test1.Net;

namespace Test1.Core
{

    static class Network
    {
        private static readonly NetWorker _netWorker = new NetWorker();

        static Network()
        {
            _netWorker.Connect();
        }

        public static NetWorker NetWorker
        {
            get { return _netWorker; }
        }
    }
}
