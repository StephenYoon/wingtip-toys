import { ProductType } from "./product-type";

export class Product {
  id: number;
  name: string;
  unitPrice: number;
  imageUrl: string;
  type: ProductType;  
}
