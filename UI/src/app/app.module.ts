import { MasterLayoutModule } from './layout/master-layout.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicHomeComponent } from './pages/public-home/public-home.component';
import { PublicModule } from './pages/public.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './core/Interceptor/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    PublicHomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule ,
    PublicModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },

  ],  bootstrap: [AppComponent]
})
export class AppModule { }
