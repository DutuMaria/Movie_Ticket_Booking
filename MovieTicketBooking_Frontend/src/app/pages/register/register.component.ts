import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public registerForm!:FormGroup;
  // formBuider => formGroup
  constructor(private formBuilder:FormBuilder, private authService:AuthService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]],
        confirmPassword: ['', [Validators.required]],
        role: ['user']
      }, {validator: this.passwordMatchValidator})
  }

  passwordMatchValidator(frm: AbstractControl) {
    return frm.get('password')?.value === frm.get('confirmPassword')?.value
       ? null : {'mismatch': true};
  }

  doRegister(){
    console.log(this.registerForm);
    if (this.registerForm.valid) {
      this.authService
        .register(this.registerForm.value)
        .subscribe((response: any) => {
          console.log(response);
        });
    }
  }

}
