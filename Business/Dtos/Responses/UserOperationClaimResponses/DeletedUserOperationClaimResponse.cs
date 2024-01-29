namespace Business.Dtos.Responses.UserOperationClaimResponses
{
    public class DeletedUserOperationClaimResponse
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}