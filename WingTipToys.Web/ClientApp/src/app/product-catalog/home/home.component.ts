import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product';
import { ProductType } from 'src/app/models/product-type';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  selectedProductTypeId: number;
  products$: Observable<Product[]>;
  
  constructor(private productService: ProductService){}

  ngOnInit(): void {
    this.selectedProductTypeId = ProductType.Cars;
    this.products$ = this.productService.getProducts();    
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
