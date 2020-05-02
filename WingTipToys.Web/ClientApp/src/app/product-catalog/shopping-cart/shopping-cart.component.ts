import { Component, OnInit, Input } from '@angular/core';
import { ShoppingCart } from 'src/app/models/shopping-cart';
import { ShoppingCartItem } from 'src/app/models/shopping-cart-item';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.scss']
})
export class ShoppingCartComponent implements OnInit {
  @Input() shoppingCart: ShoppingCart;

  constructor() { }

  ngOnInit() {
  }

  getShoppingCartContents(): ShoppingCartItem[] {
    return this.shoppingCart.items;
  }

  getSubTotal(): number {
    if (!this.shoppingCart) {
      return 0;
    }
    
    let subTotal = 0;
    this.shoppingCart.items.forEach(i => {
      subTotal += (i.productItem.unitPrice * i.quantity);
    });

    return subTotal;
  }
}
