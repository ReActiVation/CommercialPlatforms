using System.Security.Cryptography.X509Certificates;

namespace ComPlatforms.CoreLib.Service.Security
{
    public class Certificate
    {
        private readonly string _displayName;
        public string DisplayName => _displayName;

        private readonly X509Certificate _signature;
        public X509Certificate Signature => _signature;

        public Certificate(string displayName, X509Certificate2 signature)
        {
            _displayName = displayName;
            _signature = signature;
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            
            var certificateToCompare = obj as Certificate;
            
            return certificateToCompare?.Signature.GetCertHashString() == Signature.GetCertHashString();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_displayName?.GetHashCode() ?? 0) * 397) ^ (Signature?.GetHashCode() ?? 0);
            }
        }
    }
}