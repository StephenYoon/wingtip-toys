import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { ShoppingCart } from '../models/shopping-cart';
import { v4 as uuidv4 } from 'uuid';
import { take, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  private apiPath = 'api/ShoppingCart';
  private shoppingCart$: BehaviorSubject<ShoppingCart>;

  shoppingCartId: string;

  constructor(private http: HttpClient) {
    this.shoppingCart$ = new BehaviorSubject<ShoppingCart>(null);

    if (!this.shoppingCartId) {
      this.shoppingCartId = uuidv4();
    }
  }
  
  // Version 4, cryptographically-strong random values (eg: '9b1deb4d-3b7d-4bad-9bdd-2b0d7b3dcb6d')
  getShoppingCartId(): string {
    if (this.shoppingCartId === '') {
      this.shoppingCartId = uuidv4();
    }

    return this.shoppingCartId;
  }

  getShoppingCart(): BehaviorSubject<ShoppingCart> {
    
    this.http.get<ShoppingCart>(`${this.apiPath}/${this.shoppingCartId}`)
    .pipe(
      tap((data) => console.info(`Retrieved shopping cart ${this.shoppingCartId}. ` + JSON.stringify(data,null,2))),
      take(1)
    )
    .subscribe((shoppingCart: ShoppingCart) => {
      this.shoppingCart$.next(shoppingCart);
    });

    return this.shoppingCart$;
  }
  
  addToShoppingCart(productId: number): BehaviorSubject<ShoppingCart> {
    
    this.http.post<ShoppingCart>(`${this.apiPath}/${this.shoppingCartId}`, productId)
    .pipe(
      tap((data) => console.info(`Added product ${productId} to shopping cart ${this.shoppingCartId}.` + JSON.stringify(data,null,2))),
      take(1)
    )
    .subscribe((shoppingCart: ShoppingCart) => {
      this.shoppingCart$.next(shoppingCart);
    });
    
    return this.shoppingCart$;
  }
  
  removeFromShoppingCart(productId: number): BehaviorSubject<ShoppingCart> {
    
    // TODO: ...
    
    return this.shoppingCart$;
  }
}
