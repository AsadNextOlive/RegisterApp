import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Register } from './register.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  //Declaration by default for form
  formSubmitted: boolean = false;

  //Calling apiBaseUrl from the environment.ts
  url: string = environment.apiBaseUrl + '/Register'

  //Initializing an array Register from Model
  formData: Register = new Register();

  //Adding HttpClient for API
  constructor(private http: HttpClient) { }

  //Post Method to store data into the Database using API
  postRegister(){
    return this.http.post(this.url,this.formData)
  }

  //Reset Form
  resetForm(form: NgForm){
    form.form.reset();
    this.formData = new Register();
    this.formSubmitted = false;
  }
}
