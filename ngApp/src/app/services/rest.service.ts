import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class RestService {
  readonly BaseUrl = 'http://localhost:61489/';

  constructor(private http: HttpClient) { }

  sendLoginRequest(url: string, body: any)
  {
    return this.http.post(this.BaseUrl + url, body);
  }

  sendPostRequest(url: string, body: any)
  {
    return this.http.post<Product>(this.BaseUrl + url, body);
  }

  sendPutRequest(url: string, body: any)
  {
    return this.http.put<Product>(this.BaseUrl + url, body);
  }

  sendDeleteRequest(url: string, body: any)
  {
    return this.http.delete(this.BaseUrl  + url + '/' + body);
  }

  sendGetRequest(url: string)
  {
    return this.http.get<Product[]>(this.BaseUrl + url);
  }
}
