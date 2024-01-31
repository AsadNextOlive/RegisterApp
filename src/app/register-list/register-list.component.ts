import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../Shared/register.service';
import { Register } from '../Shared/register.model';
import { LordiconService } from '../Shared/Lordicon.service';


@Component({
  selector: 'app-register-list',
  templateUrl: './register-list.component.html',
  styleUrls: ['./register-list.component.css']
})
export class RegisterListComponent implements OnInit {

  constructor(public service: RegisterService,
              public Lordicon: LordiconService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  //Function to Delete registered user from the Database
  onDelete(id: number){
    if(confirm('Are you sure to delete the record?'))
    this.service.deleteRegisteredUser(id)
    .subscribe({
      next: res => {
        this.service.list = res as Register[];
        this.service.refreshList();
      }
    })
  }

  populateForm(selectedRecord: Register){
    this.service.formData = Object.assign({}, selectedRecord);
  }

}
