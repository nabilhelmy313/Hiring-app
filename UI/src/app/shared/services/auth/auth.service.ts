import { environment } from './../../../../environments/environment';
import { LoginDto } from './../../../models/auth/loginDto';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { ServiceResponse } from 'src/app/models/general/ServiceResponse';
import { TokenDto } from 'src/app/models/auth/TokenDto';
import { RegisterDto } from 'src/app/models/auth/RegisterDto';
const Url=environment.apiURL
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _apiLogin=`${Url}Auth/Login`;
  private _apiRegister=`${Url}Auth/Register`;

  constructor(private _httpClient:HttpClient) { }

  private IsLogin = new Subject<any>();

  Login(loginDto:LoginDto):Observable<ServiceResponse<TokenDto>>{
    return this._httpClient.post<ServiceResponse<TokenDto>>(this._apiLogin,loginDto)
  }
  Register(registerDto:RegisterDto):Observable<ServiceResponse<number>>{
    return this._httpClient.post<ServiceResponse<number>>(this._apiRegister,registerDto)
  }
  GetToken(){
    let token = JSON.parse( localStorage.getItem('currentUser')!);
    return token;
 }
 logout() {
  // remove user from local storage to log user out
  localStorage.clear();
}
sendIsLogin(login:boolean = false){
  this.IsLogin.next(login)
}
getIsLogin(){
  return this.IsLogin.asObservable();
}
}
