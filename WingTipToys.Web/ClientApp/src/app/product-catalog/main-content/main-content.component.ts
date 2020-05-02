import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-main-content',
  templateUrl: './main-content.component.html',
  styleUrls: ['./main-content.component.scss']
})
export class MainContentComponent implements OnInit {
  @Input() products: Product[];
  @Input() selectedProductTypeId: number;
  @Output() addProductId = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  filteredProducts(): Product[] {
    if (!this.selectedProductTypeId) {
      return this.products;
    }

    var filteredResults = this.products.filter(p => p.type == this.selectedProductTypeId);
    return filteredResults;
  }
}
