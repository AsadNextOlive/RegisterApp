import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Register } from './register.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  //Initialising and Array to get the Register List
  list: Register[] = [];

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

  //Method to delete the data from Database through API
  deleteRegisteredUser(id: number){
    return this.http.delete(this.url + '/' + id)
  }

  //Method to update the data
  putRegisteredUser(){
    return this.http.put(this.url +'/'+ this.formData.userId, this.formData)
  }

  //Method to search data by Email
  searchByEmail(email: string){    
    // return this.http.get(`${this.url}?email=${email}`);
    return this.http.get(`${this.url}/search?email=${email}`);
  }

  //Get the Data from the Database
  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: res => {
        console.log(res);
        this.list = res as Register[];
      },
      error: err => {console.log(err)}
    })
  }

  //Reset Form
  resetForm(form: NgForm){
    form.form.reset();
    this.formData = new Register();
    this.formSubmitted = false;
  }
}
