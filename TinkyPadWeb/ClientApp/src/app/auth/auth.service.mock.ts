import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthServiceMock {
  private registeredUsers = new Map([
    ["user@mail.com", "12345678"],
    ["foobar@gmail.com", "qwertyuiop"]
  ]);

  public isUserAuthorized(userName: string, enteredPassword: string): boolean {
    const savedPassword = this.registeredUsers.get(userName);
    return savedPassword === enteredPassword;
  }

  public registerUser(userName: string, password: string) {
    this.registeredUsers.set(userName, password);
  }
}
