using Entities.Concretes;

namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateCertificateRequest
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FolderPath { get; set; }
        public Account Account { get; set; }
    }
}