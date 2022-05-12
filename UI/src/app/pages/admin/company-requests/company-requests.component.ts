import { Component, OnInit } from '@angular/core';
import { GetEmployerInfoDto } from 'src/app/models/admin/GetEmployerInfodto';

@Component({
  selector: 'app-company-requests',
  templateUrl: './company-requests.component.html',
  styleUrls: ['./company-requests.component.css']
})
export class CompanyRequestsComponent implements OnInit {
  constructor() { }

  GetEmployerInfoDtos!:GetEmployerInfoDto[];
  ngOnInit(): void {
  }

}
