import { NgModule, CUSTOM_ELEMENTS_SCHEMA, DEFAULT_CURRENCY_CODE, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialFileInputModule } from 'ngx-material-file-input';

import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { LoginService } from './services/login.service';

import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from  '@angular/material/card';
import { MatAutocompleteModule } from  '@angular/material/autocomplete';
import { MatToolbarModule } from  '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { HomeComponent } from './views/home/home.component';
import { ProductComponent } from './views/home/product/product.component';
import { LoginComponent } from './views/login/login.component';
import { CurrencyMaskModule } from "ng2-currency-mask";
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    FormsModule,
    MatTableModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatInputModule,
    MatToolbarModule,
    MatAutocompleteModule,
    MatCardModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    CurrencyMaskModule,
    MaterialFileInputModule
  ],
  providers: [ LoginService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi:true
  }, { provide: LOCALE_ID, useValue: 'pt-BR' } ],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }
