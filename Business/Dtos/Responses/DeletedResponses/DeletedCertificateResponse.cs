using Entities.Concretes;

namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedCertificateResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FolderPath { get; set; }
        public Account Account { get; set; }
    }
}