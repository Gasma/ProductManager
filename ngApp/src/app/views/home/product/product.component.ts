import { Component, OnInit, Inject, Optional, ElementRef, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product } from 'src/app/models/product.model';
import { FileUploader } from 'ng2-file-upload';
import { ImageHelper } from 'src/app/helpers/image.helper';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {
  action:string;
  local_data:any;
  // productModel: Product = {
  //   id: 0,
  //   name: '',
  //   price: 0.0,
  //   photoPublicId: '',
  //   photoUrl: '',
  //   File: null
  // };


  // public uploader: FileUploader = new FileUploader({});

  // @ViewChild('fileUploadInput') fileUploadInput: ElementRef;
  // @ViewChild('fakeFileUploadInput') fakeFileUploadInput: ElementRef;

  constructor(public dialogRef: MatDialogRef<ProductComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Product, public imageHelper: ImageHelper) {
    this.local_data = {...data};
    this.action = this.local_data.action;
    // this.setUploaderCallbacks();
  }

  // setUploaderCallbacks() {
  //   this.uploader.onBeforeUploadItem = (item) => {
  //     item.withCredentials = false;
  //   }
  //   this.uploader.onAfterAddingFile = (file) => {
  //     file.withCredentials = false;
  //   };
  //   this.uploader.onCompleteItem = (item: any, response: any, status: any, headers: any) => {
  //     console.log('FileUpload:uploaded:', item, status, response);
  //   };
  // }

  doAction(){
    this.dialogRef.close({event:this.action, data:this.local_data});
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

  ngOnInit() {
  }


  // selectFile() {
  //   this.fileUploadInput.nativeElement.click();
  // }

  // handleFileSelect(evt) {
  //   const files = evt.target.files;
  //   const file = files[0];

  //   if (files && file) {
  //     this.productModel.File = file;
  //     const reader = new FileReader();
  //     reader.onload = this._handleReaderLoaded.bind(this);
  //     reader.readAsBinaryString(file);
  //   }
  // }

  // _handleReaderLoaded(readerEvt) {
  //   const binaryString = readerEvt.target.result;
  //   this.productModel.photoUrl = 'data:image/jpg;base64,' + btoa(binaryString);
  // }
}
