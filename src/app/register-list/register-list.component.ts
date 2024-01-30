import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../Shared/register.service';
import { Register } from '../Shared/register.model';

@Component({
  selector: 'app-register-list',
  templateUrl: './register-list.component.html',
  styleUrls: ['./register-list.component.css']
})
export class RegisterListComponent implements OnInit {

  constructor(public service: RegisterService) { }

  ngOnInit(): void {
    debugger;
    this.service.refreshList();
  }

  populateForm(selectedRecord: Register){
    this.service.formData = Object.assign({}, selectedRecord);
  }

}
