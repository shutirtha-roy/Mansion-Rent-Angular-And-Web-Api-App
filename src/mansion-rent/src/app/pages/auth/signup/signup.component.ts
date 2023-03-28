import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  type: string = "password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  signUpForm!: FormGroup;

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router, private toaster: ToastrService) { }

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      name: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
      role: ['admin'],
    });
  }

  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye";
    this.isText ? this.type = "text" : this.type = "password";
  }

  onSignUp() {
    if(this.signUpForm.valid) {
      //Send the obj to database
      console.log(this.signUpForm.value);

      this.auth.signUp(this.signUpForm.value)
      .subscribe({
        next: (res) => {
          this.toaster.success("SignUp Successful, please login now");
          console.log(res);
          this.signUpForm.reset();
          this.router.navigate(['auth/login']);
        },
        error: (err) => {
          alert(err?.err.message)
        }
      });

    }

    //console.log(this.loginForm.value);
    //if not valid throw the error using toaster and required fields
    ValidateForm.validateAllFormFields(this.signUpForm);
    //alert("Your form is invalid");
  }
}