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
            id = customerId;
            firstname = firstName;
            lastname = lastName;
        }

        public long id { get; init; }
        public string firstname { get; init; }

        public string lastname { get; init; }
    }
}