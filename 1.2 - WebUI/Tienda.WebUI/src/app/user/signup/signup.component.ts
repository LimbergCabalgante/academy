import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import * as moment from 'moment';
import { Moment } from 'moment';
import { UserService } from '../user.service';
import { Router } from '@angular/router'
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  form: FormGroup;
  minDate: Moment;
  maxDate: Moment;

  constructor(private formBuilder: FormBuilder, private usersService: UserService, private router: Router, private snackBar: MatSnackBar) { }

  ngOnInit(): void {

    const currentYear = moment().year();
    this.minDate = moment([currentYear - 120, 0, 1]);
    this.maxDate = moment([currentYear + -6, 11, 31]);

    let self = this;
      self.form = this.formBuilder.group({
      name: [null,[Validators.required, Validators.maxLength(30)]],
      surname: [null,[Validators.required, Validators.maxLength(30)]],
      birthDate: [null,[Validators.required]],
      email: [null, [Validators.required, Validators.maxLength(100), Validators.email]],
      username: [null,[Validators.required, Validators.minLength(6), Validators.maxLength(30)]],
      password: [null,[Validators.required, Validators.minLength(6), Validators.maxLength(30)]],
      confirmPassword: [null,[Validators.required]]
    });

  }

  checkPasswords(){
    if (this.confirmPassword.value == this.password.value) {
      this.confirmPassword.setErrors(null);
    } else {
      this.confirmPassword.setErrors({ mismatch: true });
    }
  }
  
  get password(): AbstractControl {
    return this.form.controls['password'];
  }
  
  get confirmPassword(): AbstractControl {
    return this.form.controls['confirmPassword'];
  }

  sendData(form){
    this.usersService.postUser(this.form.value).subscribe({
      next: ()=>{
        this.form.reset();
        form.resetForm();
        this.snackBar.open("Registrado con exito.", "OK", {panelClass: "success-snackbar"});
        this.router.navigate(['/login']);
      },
      error: ()=>{
        this.snackBar.open("Hubo un error al registrarte...", "OK", {panelClass: "error-snackbar"});
      }
    })
  }


}
