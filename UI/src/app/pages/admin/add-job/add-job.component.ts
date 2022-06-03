import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { AddJobDto } from 'src/app/models/Employer/AddJobDto';
import { DropDown } from 'src/app/models/general/DropDown';
import { AddJobService } from 'src/app/shared/services/Empoyer/add-job.service';
import { SweetalertService } from 'src/app/shared/services/general/sweetalert.service';

@Component({
  selector: 'app-add-job',
  templateUrl: './add-job.component.html',
  styleUrls: ['./add-job.component.css'],
})
export class AddJobComponent implements OnInit {
  dropDown!: DropDown[];
  AddJobForm!: FormGroup;
  constructor(
    private _addJobService: AddJobService,
    private _sweetalertService: SweetalertService,
    private formBuilder: FormBuilder
  ) {
    this.AddJobForm = this.formBuilder.group({
      jobTitle: ['', [Validators.required]],
      closedDate: [''],
      location: [''],
      language: [''],
      email: ['', [Validators.required]],
      salary: [''],
      website: [''],
      requirement:['',Validators.required],
      jobCategoryId: ['', Validators.required],
      jobType:['',Validators.required]
    });
  }

  ngOnInit(): void {
    this.getCategories();
  }
  getCategories() {
    this._addJobService.GetCatgories().subscribe((e) => {
      this.dropDown = e.data;
    });
  }
  OnSubmit() {
    if (this.AddJobForm.invalid) {
      return;
    }
    this._addJobService.AddJob(this.AddJobForm.value).subscribe((res) => {
      if (res.success) {
        this._sweetalertService.RunAlert(res.message, true);
        this.AddJobForm.value == null;
      } else {
        this._sweetalertService.RunAlert(res.message, false);
      }
    });
  }
}
