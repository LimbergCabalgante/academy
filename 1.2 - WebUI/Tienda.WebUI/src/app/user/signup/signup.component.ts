import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import * as moment from 'moment';
import { Moment } from 'moment';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  form: FormGroup;
  minDate: Moment;
  maxDate: Moment;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {

    const currentYear = moment().year();
    this.minDate = moment([currentYear - 120, 0, 1]);
    this.maxDate = moment([currentYear + -6, 11, 31])

    let self = this;
      self.form = this.formBuilder.group({
      name: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      surname: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      birthDate: [null, [Validators.required]],
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
