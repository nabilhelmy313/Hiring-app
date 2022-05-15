import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ServiceResponse } from 'src/app/models/general/ServiceResponse';
import { GetEmployerInfoDto } from 'src/app/models/admin/GetEmployerInfoDto';

const Url=environment.apiURL
@Injectable({
  providedIn: 'root'
})
export class EmployerRequestService {
  private _apiGetEmployer=`${Url}AcceptOrRefuseEmolyer/GetEmployers`;
  private _apiUpdateActivationOfUser=`${Url}AcceptOrRefuseEmolyer/UpdateActivationOfUser`;

  constructor(private _httpClient:HttpClient) { }
  GetEmployer(roleName:string):Observable<ServiceResponse<GetEmployerInfoDto[]>>{
    return this._httpClient.get<ServiceResponse<GetEmployerInfoDto[]>>(`${this._apiGetEmployer}?RoleName=${roleName}`)
  }
  UpdateActivationOfUser(userId:string):Observable<ServiceResponse<boolean>>{
    return this._httpClient.put<ServiceResponse<boolean>>(`${this._apiUpdateActivationOfUser}?UserId=${userId}`,null)
  }
}
