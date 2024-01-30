import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Register } from 'src/app/Shared/register.model';
import { RegisterService } from 'src/app/Shared/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  //Declaring Form by default for form validation
  formSubmitten: boolean=false

  //Adding Register Service to fetch get, post, put etc methods and trigger it on Submit Button
  constructor(public service: RegisterService) { }

  ngOnInit(): void {
  }

  //Submit Button Function
  onSubmit(from: NgForm){
    console.log('clicked')
    this.service.postRegister()
    .subscribe({
      next: res => {
        console.log(res);
        this.service.resetForm(from);
        // this.toastr.success('Record Inserted', 'Registration');
      },
      error: err => {console.log(err)}
    })
  }
  
  

}
