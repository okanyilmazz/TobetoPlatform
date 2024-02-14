namespace Business.Dtos.Requests.CertificateRequests;

public class DeleteCertificateRequest
{
<<<<<<< HEAD
    public Guid Id { get; set; }
=======
    public class DeleteCertificateRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FolderPath { get; set; }
    }
>>>>>>> master
}