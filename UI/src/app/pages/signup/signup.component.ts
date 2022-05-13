import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { SweetalertService } from 'src/app/shared/services/general/sweetalert.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  loading: boolean = false;
  submitted: boolean = false;
  empType!: string;
  isCompany: boolean = false;
  signupForm!: FormGroup;
  error: string = '';
  direction: string = '';
  constructor(
    private _authService: AuthService,
    private _sweetalertService: SweetalertService,
    private formBuilder: FormBuilder
  ) {
    this.signupForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required]],
      confirmPassword: ['', Validators.required],
      role: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      companyName: [''],
      validator: this.MustMatch('password', 'confirmPassword'),
    });
  }

  ngOnInit(): void {}
  changeType() {
    if (this.empType == 'Employer') this.isCompany = true;
    else this.isCompany = false;
  }
  onSubmit() {
    console.log(this.signupForm.value);

    if (this.signupForm.invalid) {
      this._sweetalertService.RunAlert(
        'form not valid sholud check all inputs',
        false
      );
      return;
    }
    this.loading = true;
    this._authService.Register(this.signupForm.value).subscribe((res) => {
      if (res.success) {
        this._sweetalertService.RunAlert(res.message, true);
      } else {
        this._sweetalertService.RunAlert(res.message, false);
      }
    });
  }
  MustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors['mustMatch']) {
        // return if another validator has already found an error on the matchingControl
        return;
      }

      // set error on matchingControl if validation fails
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }
  get form() {
    return this.signupForm.controls;
  }
}
