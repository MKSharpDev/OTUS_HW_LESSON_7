namespace WebClient
{
    public class CustomerCreateRequest
    {
        public CustomerCreateRequest()
        {
        }

        public CustomerCreateRequest(
            long customerId,
            string firstName,
            string lastName)
        {
            Id = customerId;
            Firstname = firstName;
            Lastname = lastName;
        }

        public long Id { get; init; }
        public string Firstname { get; init; }

        public string Lastname { get; init; }
    }
}