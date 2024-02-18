import { Category } from "./category";

export interface Product {
    productId : number;
    name : string;
    description : string;
    price : number;
    categoryId : number;
    category? : Category | null; //Category is not returned from the API, so we set it to null initially. It will be
}
