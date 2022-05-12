import { Observable } from 'rxjs';
import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ServiceResponse } from 'src/app/models/general/ServiceResponse';
import { CreatejobCategoryDto } from 'src/app/models/admin/CreatejobCategoryDto';
import { GetJobCategoriesDto } from 'src/app/models/admin/GetJobCategoriesDto';
const Url=environment.apiURL

@Injectable({
  providedIn: 'root'
})
export class AdminServiceService {
  private _apiCreateUpdateCategory=`${Url}AdminJobCategory/CreateUpdateCategory`;
  private _apiGetAllJobCategory=`${Url}AdminJobCategory/GetAllJobCategory`;
  private _apiDeleteJobCategory=`${Url}AdminJobCategory/DeleteJobCategory`;
  constructor(private _httpClient:HttpClient) { }

  CreateUpdateCategory(createjobCategoryDto:CreatejobCategoryDto):Observable<ServiceResponse<number>>
  {
    console.log(createjobCategoryDto);
    let params = new FormData();
    params.append("Id",createjobCategoryDto.id+"")
    params.append("Title_En",createjobCategoryDto.title_En)
    params.append("Title_Fr",createjobCategoryDto.title_Fr)
    params.append("Title_du",createjobCategoryDto.title_du)
    params.append("CategoryPic",createjobCategoryDto.categoryPic)
    console.log('params',params);
    return this._httpClient.post<ServiceResponse<number>>(this._apiCreateUpdateCategory,params)
  }
  GetJobCategory():Observable<ServiceResponse<GetJobCategoriesDto[]>>{
    return this._httpClient.get<ServiceResponse<GetJobCategoriesDto[]>>(this._apiGetAllJobCategory)
  }
  del(id:string):Observable<ServiceResponse<number>>{
    return this._httpClient.put<ServiceResponse<number>>(this._apiDeleteJobCategory+"?id="+id,null)
  }
}
