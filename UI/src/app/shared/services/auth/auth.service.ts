import { LoginDto } from './../../../models/auth/loginDto';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServiceResponse } from 'src/app/models/general/ServiceResponse';
import { TokenDto } from 'src/app/models/auth/TokenDto';
import { RegisterDto } from 'src/app/models/auth/RegisterDto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _apiLogin=`${URL}Auth/Login`;
  private _apiRegister=`${URL}Auth/Register`;

  constructor(private _httpClient:HttpClient) { }

  Login(loginDto:LoginDto):Observable<ServiceResponse<TokenDto>>{
    return this._httpClient.post<ServiceResponse<TokenDto>>(this._apiLogin,loginDto)
  }
  Register(registerDto:RegisterDto):Observable<ServiceResponse<number>>{
    return this._httpClient.post<ServiceResponse<number>>(this._apiRegister,registerDto)
  }
}
