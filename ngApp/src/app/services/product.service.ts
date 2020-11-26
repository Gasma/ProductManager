import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { RestService } from './rest.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private rest: RestService) { }

  getAllProduct()
  {
    return this.rest.sendGetRequest('api/product');
  }

  saveProduct(product: any)
  {
    if (!product.has('id'))
      return this.rest.sendPostRequest('api/product', product);
    else
      return this.rest.sendPutRequest('api/product', product);

  }

  deleteProduct(product)
  {
    return this.rest.sendDeleteRequest('api/product', product);
  }
}
