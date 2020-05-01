import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Product } from '../models/product';
import { ProductType } from '../models/product-type';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  /*
    Making use of BehaviorSubject because it can emit the current value.
    Easier to share out the latest value between other components if needed.
    Two ways to access the latest value:
      1. using the .value property
      2. subscribe to the subject
  */

  /* 
    TODO: We can utilize localStorage to "cache" the results for a period of time,
          in addition to adding cache in the .NET Core Web API.
  */
 
  private apiPath = 'api/Products';
  private products$: BehaviorSubject<Product[]>;
  
  constructor(private http: HttpClient) {
    this.products$ = new BehaviorSubject<Product[]>(null);
  }

  getProducts(): BehaviorSubject<Product[]> {

    this.http.get<Product[]>(this.apiPath)
    .pipe(take(1))
    .subscribe((products: Product[]) => {
      this.products$.next(products);
    });

    return this.products$;
  }

  getProductsByType(productType: ProductType): BehaviorSubject<Product[]> {
    
    this.http.get<Product[]>(`${this.apiPath}/Type/${productType}`)
    .pipe(take(1))
    .subscribe((products: Product[]) => {
      this.products$.next(products);
    });

    return this.products$;
  }
}
