using BuberBreakfast.Contract.Breakfast;
using BuberBreakfast.Models;

namespace BuberBreakfast.Services
{
    public class BreakfastService: IBreakfastService
    {
        private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();

        public void CreateBreakfast(Breakfast breakfast)
        {
            _breakfasts.Add(breakfast.Id, breakfast);
        }

        public void DeleteBreakfast(Guid id)
        {
            _breakfasts.Remove(id);
        }

        public Breakfast GetBreakfast(Guid id)
        {
            return _breakfasts[id];
        }

        public void UpsertBreakfast(Guid id, Breakfast breakfast)
        {
            _breakfasts[id] = breakfast;
        }
    }
}
