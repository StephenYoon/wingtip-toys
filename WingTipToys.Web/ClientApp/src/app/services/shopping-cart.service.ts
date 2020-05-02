import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { ShoppingCart } from '../models/shopping-cart';
import { v4 as uuidv4 } from 'uuid';

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
    
    // TODO: ...

    return this.shoppingCart$;
  }
  
  addToShoppingCart(productId: number): BehaviorSubject<ShoppingCart> {
    
    // TODO: ...
    
    return this.shoppingCart$;
  }
  
  removeFromShoppingCart(productId: number): BehaviorSubject<ShoppingCart> {
    
    // TODO: ...
    
    return this.shoppingCart$;
  }
}
