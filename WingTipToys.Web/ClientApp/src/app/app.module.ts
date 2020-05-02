import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './product-catalog/nav-menu/nav-menu.component';
import { HomeComponent } from './product-catalog/home/home.component';
import { SideMenuComponent } from './product-catalog/side-menu/side-menu.component';
import { MainContentComponent } from './product-catalog/main-content/main-content.component';
import { ShoppingCartComponent } from './product-catalog/shopping-cart/shopping-cart.component';

/* 
  TODO: We can utilize lazy loading by route when the application grows larger in size
        to reduce the what the user has to load if certain features aren't used
        all the time.
        Reference: https://angular.io/guide/lazy-loading-ngmodules
*/

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SideMenuComponent,
    MainContentComponent,
    ShoppingCartComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
