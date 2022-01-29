import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookingService } from 'src/app/services/booking.service';
import { PrivateService } from 'src/app/services/private.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent implements OnInit {
  public bookingForm!:FormGroup;
  public defaultDate:Date = new Date();
  public idUser: number = 0;
  public movies:any[]=[];
  public screenings:any[]=[];

  constructor(private formBuilder:FormBuilder, private bookingService:BookingService, private privateService:PrivateService) { }

  ngOnInit(): void {
    this.getAllMovies();
    this.getAllScreenings();
    this.bookingForm = this.formBuilder.group(
      {
        userId: [],
        screeningId: [],
        date: [this.defaultDate],
        nrOfTickets: [1]
      });
  }

  getAllMovies(){
    this.privateService.getAllMovies().subscribe((response:any)=>{
      this.movies=response;
    });
  }

  getAllScreenings(){
    this.privateService.getScreenings().subscribe((response:any)=>{
      this.screenings=response;
    });
  }

  getUserId(){
    this.bookingService.getUser().subscribe((response:any) => {
        this.idUser = response;
    });
  }

  doBooking(){
    console.log(this.bookingForm);
    if (this.bookingForm.valid) {
      this.bookingForm.value.userId = this.idUser;
      this.bookingService
        .addBooking(this.bookingForm.value)
        .subscribe((response: any) => {
          console.log(response);
      });
    }
  }

}
