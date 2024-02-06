import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Home/home/home.component';
import { RegisterListComponent } from './register-list/register-list.component';
import { SecuredPageComponent } from './secured-page/secured-page.component';
import { AuthGuardGuard } from './Guard/auth-guard.guard';


const routes: Routes = [
  // {path:"",  component: HomeComponent},
  {path:"register-list", component: RegisterListComponent},
  {path:"login", component: SecuredPageComponent, canActivate: [AuthGuardGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
   declarations: []
})
export class AppRoutingModule { }
