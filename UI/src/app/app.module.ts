import { MasterLayoutModule } from './layout/master-layout.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { PublicHomeComponent } from './pages/public-home/public-home.component';
import { PublicModule } from './pages/public.module';

@NgModule({
  declarations: [
    AppComponent,
    PublicHomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PublicModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }