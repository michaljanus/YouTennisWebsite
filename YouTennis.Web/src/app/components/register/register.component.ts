import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Credentials } from 'src/app/models/credentials';
import { UserService } from 'src/app/services/user.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  private subscription: Subscription;

  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;
  newForm: FormGroup;

  get f() { return this.newForm.controls; }

  //credentials: Credentials = { userName: '', userFirstName: '', userLastName: '', email: '', password: '', confirmPassword: '' };

  constructor(private userService: UserService, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.newForm = this.formBuilder.group({
      userName: '',
      firstName: '',
      email: '',
      password: '',
      confirmPassword: '',
      lastName: '',
    });
  }

  register() {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    this.userService.register(
      this.newForm.get('email').value,
      this.newForm.get('password').value,
      this.newForm.get('confirmPassword').value,
      this.newForm.get('firstName').value,
      this.newForm.get('lastName').value,
      this.newForm.get('userName').value
    )
      .subscribe(
        result => {
          if (result) {
            this.router.navigate(['/login']);
          }
        },
        error => this.errors = error);
  }

}