using System.Text;

namespace SimpleHttpStressTester
{
    public class Target
    {
        private readonly string _domain;
        private readonly int _port;
        private readonly string _uri;
        private readonly Protocol _protocol;

        public Target(string domain, string uri, int port, Protocol protocol)
        {
            this._domain = domain;
            this._port = port;
            this._uri = uri;
            this._protocol = protocol;
        }

        public string Url => $"{this._protocol}://{this._domain}:{this._port}/{this._uri}";

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Target");
            sb.AppendLine($"Url: {this._protocol.ToString()}://{this._domain}");
            sb.AppendLine($"Port: {this._port}");
            sb.AppendLine($"Uri: {this._uri}");

            return sb.ToString().TrimEnd();
        }
    }
}
