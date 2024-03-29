import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { of } from 'rxjs';

import { IPagination, TokenPagination } from '../shared/models/pagination';
import { IToken } from '../shared/models/token';
import { IProductType } from '../shared/models/productType';
import { TokenParams } from '../shared/models/tokenParams';
import { IStore } from '../shared/models/store';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  baseUrl = environment.apiUrl;
  tokens: IToken[] = [];
  tokensStore: IToken[] = [];
  stores: IStore[] = [];
  productTypes: IProductType[] = [];
  pagination = new TokenPagination();
  tokenParams = new TokenParams();
  tokenCache = new Map();

  constructor(private http: HttpClient) { }

  getTokens(useCache: boolean){
    if (useCache === false){
      this.tokenCache = new Map();
    }
    if (this.tokenCache.size > 0 && useCache){
      if (this.tokenCache.has(Object.values(this.tokenParams).join('-'))){
        this.pagination.data = this.tokenCache.get(Object.values(this.tokenParams).join('-'));
        return of(this.pagination);
      }
    }
    let params = new HttpParams();
    params = params.append('storeUID', this.tokenParams.storeUID.toString());
    // if (this.tokenParams.storeUID !== '00000000-0000-0000-0000-000000000000'){
    //   params = params.append('storeUID', this.shopParams.storeUID.toString());
    // }
    if (this.tokenParams.productTypeId !== 0){
      params = params.append('productTypeId', this.tokenParams.productTypeId.toString());
    }
    if (this.tokenParams.search){
      params = params.append('search', this.tokenParams.search);
    }
    params = params.append('sort', this.tokenParams.sort);
    params = params.append('pageIndex', this.tokenParams.pageNumber.toString());
    params = params.append('pageSize', this.tokenParams.pageSize.toString());

    return this.http.get<TokenPagination>(this.baseUrl + 'tokenuser', {observe: 'response', params})
      .pipe(
        map(response =>{

          this.tokenCache.set(Object.values(this.tokenParams).join('-'), response.body.data);
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }

  setTokenParams(params: TokenParams){
    this.tokenParams = params;
  }

  getTokenParams(){
    return this.tokenParams;
  }

  getToken(id: string){
    let token: IToken;
    this.tokenCache.forEach((tokens: IToken[]) => {

      token = tokens.find(p => p.tokenUID === id);
    })
    if (token){
      return of(token);
    }

    if (token){
      return of(token);
    }
    return this.http.get<IToken>(this.baseUrl + 'tokenuser/' + id);

  }

}
