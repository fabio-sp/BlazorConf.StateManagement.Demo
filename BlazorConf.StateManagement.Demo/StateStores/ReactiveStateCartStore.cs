using BlazorConf.StateManagement.Demo.Data;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace BlazorConf.StateManagement.Demo.StateStores
{
    public class ReactiveStateCartStore
    {
        private readonly BehaviorSubject<List<Item>> itemsInCart;

        public IObservable<List<Item>> Value => itemsInCart.AsObservable();

        public ReactiveStateCartStore()
        {
            itemsInCart = new BehaviorSubject<List<Item>>(new List<Item>());
        }

        public void AddItem(Item item)
        {
            var nextState = itemsInCart.Value.Append(item).ToList();
            this.itemsInCart.OnNext(nextState);
        }
    }
}
