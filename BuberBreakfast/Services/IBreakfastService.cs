using BuberBreakfast.Contract.Breakfast;
using BuberBreakfast.Models;

namespace BuberBreakfast.Services
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Breakfast breakfast);
        Breakfast GetBreakfast(Guid id);
        void UpsertBreakfast(Guid id, Breakfast breakfast);
        void DeleteBreakfast(Guid id);
    }
}
