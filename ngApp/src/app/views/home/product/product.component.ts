import { Component, OnInit, Inject, Optional, ElementRef, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {
  action:string;
  local_data:any;

  public uploader: File;
  public urlString: string = "/assets/img/imgDefault.png";

  constructor(public dialogRef: MatDialogRef<ProductComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Product) {
    this.local_data = {...data};
    this.action = this.local_data.action;
  }

  doAction(){
    this.local_data.file = this.uploader;
    this.dialogRef.close({event:this.action, data:this.local_data});
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

  ngOnInit() {
  }

  handleFileSelect(file: FileList) {
    this.uploader = file.item(0);
    var reader = new FileReader();
    reader.onload = (event:any) => {
      this.urlString = event.target.result;
    };
    reader.readAsDataURL(this.uploader)
  }
}
