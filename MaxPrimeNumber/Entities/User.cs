using Microsoft.AspNetCore.Identity;

namespace MaxPrimeNumber.Entities;

public class User: IdentityUser //TODO remove this it is unnecessary after asp net users
{
    public String Name { get; set; }
}