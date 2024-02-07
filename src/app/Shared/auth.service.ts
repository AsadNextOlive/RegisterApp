import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginModel } from './login.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

//Calling apiBaseUrl from the environment.ts
apiUrl: string = environment.apiBaseUrl + '/login'
private loggedIn = false;

constructor(private http: HttpClient) { }

login(credentials: LoginModel): Observable<any> {
  return this.http.post<any>(this.apiUrl,credentials); //Sending post request to login with credentials
}

setLoggedIn(value: boolean){
  this.loggedIn = value;
}

isLoggedIn(){
  return this.loggedIn;
}

}
