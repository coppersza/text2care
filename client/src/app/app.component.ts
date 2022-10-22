import { Component } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Text2Care';

  constructor(private basketService: BasketService){}
  ngOnInit(): void {
    this.loadBasket();
  }

  loadBasket(){
    const basketId = localStorage.getItem('basket_id');
    if (basketId){
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('initialize basket');
      }, error =>{
        console.log(error);
      });
    }
  }
}
