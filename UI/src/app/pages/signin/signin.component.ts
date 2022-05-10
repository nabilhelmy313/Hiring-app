import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { SweetalertService } from 'src/app/shared/services/general/sweetalert.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  loading: boolean = false;
  submitted: boolean = false;
  loginForm!: FormGroup;

  constructor(private _authService: AuthService,
    private _sweetalertService: SweetalertService,
    private formBuilder: FormBuilder,
  ) {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', [Validators.required]],
    });
  }


  ngOnInit(): void {
  }

  get form() { return this.loginForm.controls; }

  onSubmit() {
    console.log(this.loginForm.value);

    if (this.loginForm.invalid) {
      return;
    }
    this.loading = true;
    this._authService.Login(this.loginForm.value)
      .subscribe(res => {
        if (res.success) {
          this._sweetalertService.RunAlert(res.message, true);
        } else {
          this._sweetalertService.RunAlert(res.message, false);
        }
      }

      )
  }


}
