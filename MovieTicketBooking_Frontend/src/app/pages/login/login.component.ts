import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public text: string = "";
  public isDisabled: boolean = false;
  public loginForm!:FormGroup;
  // formBuider => formGroup
  constructor(private formBuilder:FormBuilder, private authService:AuthService, private router:Router) { }

  ngOnInit(): void {
    this.text = "LOGIN";
    this.loginForm = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]]
      });
  }

  doLogin(){
    console.log(this.loginForm);
    if (this.loginForm.valid) {
      this.authService
        .login(this.loginForm.value)
        .subscribe((response: any) => {
          console.log(response);
        });
      //localStorage.setItem("currentUser", this.loginForm.value.email);
      sessionStorage.setItem("currentUser", this.loginForm.value.email);
      // localStorage.setItem("userIsLogged", "true")
      this.router.navigate(['/dashboard']);
    }
  }

}
