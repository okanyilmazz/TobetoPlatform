using Entities.Concretes;

namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedAccountResponse
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ProfilePhotoPath { get; set; }
    }
}