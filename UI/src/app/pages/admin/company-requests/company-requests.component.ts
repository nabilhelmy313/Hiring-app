import { Component, OnInit } from '@angular/core';
import { GetEmployerInfoDto } from 'src/app/models/admin/GetEmployerInfodto';
import { EmployerRequestService } from 'src/app/shared/services/admin/employer-request.service';
import { SweetalertService } from 'src/app/shared/services/general/sweetalert.service';

@Component({
  selector: 'app-company-requests',
  templateUrl: './company-requests.component.html',
  styleUrls: ['./company-requests.component.css'],
})
export class CompanyRequestsComponent implements OnInit {
  constructor(
    private _employerRequestService: EmployerRequestService,
    private _sweetalertService: SweetalertService
  ) {}

  GetEmployerInfoDtos!: GetEmployerInfoDto[];
  ngOnInit(): void {
    this.getEmployers();
  }
  getEmployers() {
    this._employerRequestService.GetEmployer('Employer').subscribe((res) => {
      this.GetEmployerInfoDtos = res.data;
    });
  }
  UpdateActivationUser(userId: string) {
    this._employerRequestService
      .UpdateActivationOfUser(userId)
      .subscribe((res) => {
        if (res.success) {
          this._sweetalertService.RunAlert(res.message, true);
        } else {
          this._sweetalertService.RunAlert(res.message, false);
        }
      });
  }

}
