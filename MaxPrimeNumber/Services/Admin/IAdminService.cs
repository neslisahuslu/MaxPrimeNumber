namespace MaxPrimeNumber.Services.Admin;

public interface IAdminService

{
 Task<List<Entities.EnteredNumber>> FindAll();
}