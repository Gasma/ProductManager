import { AfterViewInit, Component, ViewChild } from '@angular/core';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ProductService } from 'src/app/services/product.service';
import { ProductComponent } from './product/product.component';
import { Product } from 'src/app/models/product.model';
import { LoginService } from 'src/app/services/login.service';
import { ImageHelper } from 'src/app/helpers/image.helper';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements AfterViewInit {

  displayedColumns: string[] = ['name', 'price', 'photoUrl', 'action'];
  dataSource: MatTableDataSource<Product>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<any>;

  constructor(private service: LoginService,
    private productService: ProductService,
    public dialog: MatDialog)
    {
    this.getAllProduct();
  }

  onLogOut()
  {
    this.service.logout();
  }

  ngAfterViewInit()
  {

  }

  applyFilter(event: Event)
  {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getAllProduct()
  {
    this.productService.getAllProduct().subscribe(data => {
      if (data.length > 0) {
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
      else
      this.dataSource = new MatTableDataSource();
    });
  }

  openDialogLend(action, obj) {
    obj.action = action;
    const dialogRef = this.dialog.open(ProductComponent, {
      width: '300px',
      height: (obj.action == 'Apagar')? '250px': '450px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == null)
        return;
      if(result.event == 'Adicionar'){
        this.addRowData(result.data);
      }else if(result.event == 'Editar'){
        this.updateRowData(result.data);
      }else if(result.event == 'Apagar'){
        this.deleteRowData(result.data);
      }
    });
  }

  private populateFormData(row_obj: any) {
    const formData = new FormData();
    for (var key in row_obj)
      formData.append(key, row_obj[key]);

    return formData;
  }

  addRowData(row_obj)
  {
    let body = this.populateFormData(row_obj);
    this.productService.saveProduct(body).subscribe(res => {
      if (res != null)
      {
        this.getAllProduct();
        this.table.renderRows();
      }
    });
  }

  updateRowData(row_obj)
  {
    this.productService.saveProduct(row_obj).subscribe(res => {
      if (res != null)
      {
        this.getAllProduct();
        this.table.renderRows();
      }
    });
  }

  deleteRowData(row_obj)
  {
    // this.dataSource = this.dataSource.filter((value,key)=>{
    //   return value.id != row_obj.id;
    // });
  }

}
