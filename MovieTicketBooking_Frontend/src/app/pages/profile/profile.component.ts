import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public username!:string | null;
  constructor() { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser(){
    this.username = sessionStorage.getItem("currentUser");
  }

}
