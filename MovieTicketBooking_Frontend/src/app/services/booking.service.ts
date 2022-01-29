import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  public userName!:string | null;
  private baseUrl:string = environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'responseType': 'json'
    }),
  };
  constructor(private http:HttpClient) { }

  getUser(){
    var username = sessionStorage.getItem("currentUser");
    this.userName = username;
    return this.http.get(this.baseUrl + 'api/Auth/GetUserId' + username, this.privateHttpHeaders);
  }

  addBooking(data:any){
    return this.http.post(this.baseUrl + 'api/Booking/AddBooking', data, this.privateHttpHeaders);
  }
}
