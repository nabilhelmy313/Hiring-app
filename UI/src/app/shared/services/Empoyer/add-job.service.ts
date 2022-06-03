import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddJobDto } from 'src/app/models/Employer/AddJobDto';
import { DropDown } from 'src/app/models/general/DropDown';
import { ServiceResponse } from 'src/app/models/general/ServiceResponse';
import { environment } from 'src/environments/environment';
const Url=environment.apiURL

@Injectable({
  providedIn: 'root'
})
export class AddJobService {

  private _apiAddJob="https://localhost:7235/Job/AddJob";
  private _apiGetCatgories=`${Url}Job/GetCatgories`;
  private _apiDeleteJob=`${Url}Job/DeleteJob`;

  constructor(private _httpClient:HttpClient) { }
  AddJob(addJobDto:AddJobDto):Observable<ServiceResponse<number>>{
    return this._httpClient.post<ServiceResponse<number>>(this._apiAddJob,addJobDto)
  }
  GetCatgories():Observable<ServiceResponse<DropDown[]>>{
    return this._httpClient.get<ServiceResponse<DropDown[]>>(this._apiGetCatgories)
  }
  DeleteJob(id:string){
    return this._httpClient.put<ServiceResponse<number>>(`${this._apiGetCatgories}?id=${id}`,null)
  }
}
