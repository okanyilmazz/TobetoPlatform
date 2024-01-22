using Entities.Concretes;

namespace Business.Dtos.Requests.CertificateRequests
{
    public class CreateCertificateRequest
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FolderPath { get; set; }
    }
}