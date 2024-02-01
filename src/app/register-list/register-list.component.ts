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

  //Initial number of Data to be displayed
  displayCount: number = 5;

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

  //LoadMore Function to load items
  loadMore(){
    // this.displayCount += 5;
    const totalItems = this.service.list.length;
    if (this.displayCount < totalItems) {
      // Increase the number of items to display
      this.displayCount += 5;
    }
  }

  //Check if Load More Button should visible or hide
  visibleLoadMore(): boolean {
    return this.displayCount < this.service.list.length;
  }

  //Search functionality
  onSearch(emailInput: HTMLInputElement){
    const email = emailInput.value;
    if (email) {
      this.service.searchByEmail(email)
      .subscribe({
        next: (res: any) => {
          console.log('Search Results:', res);
          // this.service.list = res as Register[] || [];
          this.service.list = res.Data || [];
          
        },
        error: err => {console.log(err);}
      });
    }else{
      this.service.refreshList();
    }
    
  }

}
