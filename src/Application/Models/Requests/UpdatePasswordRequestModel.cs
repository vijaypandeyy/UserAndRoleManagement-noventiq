namespace Application.Models.Requests
{
    public class UpdatePasswordRequestModel
    {
        public Guid Id { get; private set; }
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }

    }
}
