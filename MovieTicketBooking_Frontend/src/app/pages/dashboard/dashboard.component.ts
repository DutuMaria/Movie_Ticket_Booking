import { Component, OnInit } from '@angular/core';
import { PrivateService } from 'src/app/services/private.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public movies:any[]=[];
  public isEnabled: boolean = true;

  constructor(private privateService:PrivateService) { }
  public users:any[]=[];

  ngOnInit(): void {
    this.getAllUsers();
    this.getAllMovies();
    this.getUserStatus();
    var array = this.movies;
  }

  getAllUsers(){
    this.privateService.getAllUsers().subscribe((response:any)=>{
      this.users=response.allUsers;
    });
  }

  getAllMovies(){
    this.privateService.getAllMovies().subscribe((response:any)=>{
      this.movies=response;
    });
  }

  getUserStatus(){
    if("currentUser" in sessionStorage){
      this.isEnabled = false;
    }
  }

}
