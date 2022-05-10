import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreatejobCategoryDto } from 'src/app/models/admin/CreatejobCategoryDto';
import { GetJobCategoriesDto } from 'src/app/models/admin/GetJobCategoriesDto';
import { AdminServiceService } from 'src/app/shared/services/admin/admin-service.service';
import { SweetalertService } from 'src/app/shared/services/general/sweetalert.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-job-category',
  templateUrl: './job-category.component.html',
  styleUrls: ['./job-category.component.css'],
})
export class JobCategoryComponent implements OnInit {
  CategoryForm!: FormGroup;
  loading!: boolean;
  file: any;
  getJobCategoriesDto!: GetJobCategoriesDto[];
  ImageNotValidMessage: string = '';
  URL = environment.apiURL;
  imageUrl!: string;
  constructor(
    private _adminService: AdminServiceService,
    private _sweetalertService: SweetalertService,
    private formBuilder: FormBuilder
  ) {
    this.CategoryForm = this.formBuilder.group({
      id: [''],
      title_En: ['', [Validators.required]],
      title_Fr: ['', [Validators.required]],
      title_du: ['', [Validators.required]],
      categoryPic: ['', [Validators.required]],
    });
  }
  ngOnInit(): void {
    this.GetJobCategory();
  }
  chooseFile(e: any) {
    this.file = e.target.files[0];
    if (this.file) {
      console.log('Fileeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee', this.file);
      const reader = new FileReader();
      reader.onload = () => {
        this.imageUrl = reader.result as string;
      };
      reader.readAsDataURL(this.file);
      if (this.file.type.split('/')[0].toLowerCase() != 'image') {
        localStorage.getItem('lang');
        this.ImageNotValidMessage =
          localStorage.getItem('lang') == 'ar'
            ? 'تاكد ان الملف المرفوع صوره'
            : 'Please check that uploaded File is image';
      }
    }
  }
  onSubmit() {
    console.log(this.CategoryForm.value);

    if (this.CategoryForm.invalid) {
      return;
    }
    this.loading = true;
    let createjobCategoryDto: CreatejobCategoryDto = this.CategoryForm.value;
    createjobCategoryDto.categoryPic = this.file;
    this._adminService
      .CreateUpdateCategory(createjobCategoryDto)
      .subscribe((res) => {
        if (res.success) {
          this._sweetalertService.RunAlert(res.message, true);
          this.CategoryForm.value==null;
          this.GetJobCategory();
        } else {
          this._sweetalertService.RunAlert(res.message, false);
        }
      });
  }
  GetJobCategory() {
    this._adminService.GetJobCategory().subscribe((res) => {
      if(res.success){
        this.getJobCategoriesDto = res.data;
        console.log(res.data)
      }
    });
  }
  del(id:string){
    console.log(id);

    this._adminService.del(id).subscribe((res) => {
      if(res.success){
        this._sweetalertService.RunAlert(res.message, true);
        this.GetJobCategory();
      }else{
        this._sweetalertService.RunAlert(res.message, false);

      }
    });
  }
}
