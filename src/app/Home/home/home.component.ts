import { Component, OnInit } from '@angular/core';
import { Register } from 'src/app/Shared/register.model';
import { RegisterService } from 'src/app/Shared/register.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public service: RegisterService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Register){
    this.service.formData = Object.assign({}, selectedRecord);
  }

}
