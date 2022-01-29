import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrivateService {
  private baseUrl:string = environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      Authorization: 'Bearer ' +  localStorage.getItem('token')
    }),
  };
  constructor(private http:HttpClient) { }

  getAllUsers() {
    return this.http.get(this.baseUrl + 'api/Auth/getAllUsers', this.privateHttpHeaders);
  }

  getAllMovies(){
    return this.http.get(this.baseUrl + 'api/Movie/GetMovies', this.privateHttpHeaders);
  }

  getScreenings(){
    return this.http.get(this.baseUrl + 'api/Movie/GetAllMoviesScreenings', this.privateHttpHeaders);
  }

  // getMovie(){
  //   return this.http.get(this.baseUrl + 'api/Movie/GetMovieById', this.privateHttpHeaders);
  // }

}
