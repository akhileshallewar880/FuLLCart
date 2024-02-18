import { CartItem } from "./cart-item";

export interface ShoppingCart {
    shoppingCartId : number;
    userId : number;
    cartItems : CartItem[];
}
