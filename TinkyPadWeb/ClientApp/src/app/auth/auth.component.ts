import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthServiceMock } from './auth.service.mock';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  isLoginMode = true;

  constructor(private authService: AuthServiceMock, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }

    const email = form.value.email;
    const password = form.value.password;

    if (this.isLoginMode) {
      this.login(email, password);
    } else {
      this.signUp(email, password);
    }

    form.reset();
  }

  onSwitchMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  login(email: string, password: string) {
    if (this.authService.isUserAuthorized(email, password)) {
      this.router.navigate(['/']);
    } else {
      alert("Incorrect email or password");
    }
  }

  signUp(email: string, password: string) {
    this.authService.registerUser(email, password);
    this.login(email, password);
  }
}
