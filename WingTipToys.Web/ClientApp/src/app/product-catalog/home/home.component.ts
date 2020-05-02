import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product';
import { ProductType } from 'src/app/models/product-type';
import { ShoppingCart } from 'src/app/models/shopping-cart';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  selectedProductTypeId: number;
  products$: Observable<Product[]>;
  shoppingCart$: Observable<ShoppingCart>;
  
  constructor(
    private productService: ProductService,
    private shoppingCartService: ShoppingCartService
  ){}

  ngOnInit(): void {
    this.selectedProductTypeId = ProductType.Cars;
    this.products$ = this.productService.getProducts();    
  }

  addProductToCart(productId: number): void {
    this.shoppingCart$ = this.shoppingCartService.addToShoppingCart(productId);        
  }
  
  onProductTypeChange(typeId: number): void {
    this.selectedProductTypeId = typeId;

    /* 
      TODO: Optionally we can request the filtered data from the API backend
            if the requested data becomes large.
      */
    // if (typeId === 0) {
    //   this.products$ = this.productService.getProducts();
    // } else {
    //   this.products$ = this.productService.getProductsByType(typeId);
    // }
  }
}
