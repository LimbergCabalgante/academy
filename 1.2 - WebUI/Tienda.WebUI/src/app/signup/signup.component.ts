import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    let self = this;
      self.form = this.formBuilder.group({
      name: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      surname: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      birthDate: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      username: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      password: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      confirmPassword: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(30)]]
    });

  }

  sendData(){
    console.log(this.form.value);
    this.form.reset;
  }

}
