import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.scss']
})
export class SideMenuComponent implements OnInit {
  @Input() selectedProductTypeId: number;
  @Output() selectedProductType = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }
  
  selectType(typeId: number): void {
    this.selectedProductType.emit(typeId);
  }
}
