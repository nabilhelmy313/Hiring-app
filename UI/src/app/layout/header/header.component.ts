import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { ApplicationUserDto } from 'src/app/models/auth/TokenDto';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  fullName!: string;
  currentUser!: ApplicationUserDto;
  islogin!:boolean;
  constructor(private _authService:AuthService,private _router:Router) {

  }

  ngOnInit(): void {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser') + '');
   this. _authService.getIsLogin().subscribe(res=>{
      this.islogin= res;
      console.log('nabil test comonent value ',this.islogin);
     })
  }
  logout(){
    this._authService.logout();
    this.ngOnInit();
    this._router.navigate(['/'])
  }
}
