import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';


const routes: Routes = [
  // {path: '', component: HomeComponent, data:{breadcrumb: 'Home'}},
  // {path: '', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule), data:{breadcrumb: 'Shop'}},
  {path: '', component: ShopComponent},
  {path: 'donate', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule), data:{breadcrumb: 'Donate'}},
  {path: 'tokens', canActivate:[AuthGuard], loadChildren: () => import('./token/token.module').then(mod => mod.TokenModule), data:{breadcrumb: 'Tokens'}},

  {path: 'test-error', component: TestErrorComponent, data:{breadcrumb: 'Test Errors'}},
  {path: 'server-error', component: ServerErrorComponent, data:{breadcrumb: 'Server Errors'}},
  {path: 'not-found', component: NotFoundComponent, data:{breadcrumb: 'Not found Errors'}},
  {path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), data:{breadcrumb: 'Basket'}},

  {path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule), data:{breadcrumb: {skip: true}}},

  {path: 'checkout', canActivate:[AuthGuard], loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule), data:{breadcrumb: 'Checkout'}},
  {path: 'orders', canActivate:[AuthGuard], loadChildren: () => import('./orders/orders.module').then(mod => mod.OrdersModule), data:{breadcrumb: 'Orders'}},

  {path: '**', redirectTo:'not-found', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
