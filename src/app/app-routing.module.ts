import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Home/home/home.component';
import { RegisterListComponent } from './register-list/register-list.component';

const routes: Routes = [
  // {path:"",  component: HomeComponent},
  {path:"register-list", component: RegisterListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
