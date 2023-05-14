using BlazorConf.StateManagement.Demo.Data;

namespace BlazorConf.StateManagement.Demo.StateStores
{
    public class StateContainerServiceCartStore
    {
        public StateContainerServiceCartStore(List<Item>? items = null)
        {
            ItemsInCart = items ?? new List<Item>();
        }

        public event Action? CartChanged;
        public List<Item> ItemsInCart { get; }

        public void AddItemToCart(Item itemToAdd)
        {
            ItemsInCart.Add(itemToAdd);
            CartChanged?.Invoke();
        }
    }
}
