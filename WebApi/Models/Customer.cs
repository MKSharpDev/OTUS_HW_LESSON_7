using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Customer
    {
            public long Id { get; init; }
        
            
            public string Firstname { get; init; }

            public string Lastname { get; init; }
    }
}