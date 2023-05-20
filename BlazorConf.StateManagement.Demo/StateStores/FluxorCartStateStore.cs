using BlazorConf.StateManagement.Demo.Data;
using Fluxor;
using System.Collections.Immutable;

namespace BlazorConf.StateManagement.Demo.StateStores
{
    [FeatureState]
    public class FluxorCartStateStore
    {
        public ImmutableArray<Item> ItemsInCart { get; } = ImmutableArray.Create<Item>();

        private FluxorCartStateStore() { } // Serve a costruire lo stato iniziale

        public FluxorCartStateStore(ImmutableArray<Item> itemsInCart)
        {
            ItemsInCart = itemsInCart;
        }
    }

    public static class Reducers
    {
        [ReducerMethod]
        public static FluxorCartStateStore ReduceAddItemToCartAction(FluxorCartStateStore cartState
            , AddItemToCartAction action)
            => new FluxorCartStateStore(cartState.ItemsInCart.Add(action.ItemToAdd));
    }

    public record AddItemToCartAction(Item ItemToAdd);
}
