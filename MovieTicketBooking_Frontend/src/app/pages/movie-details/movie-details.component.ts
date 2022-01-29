import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
// import { Movie, movies } from '../dashboard/dashboard.component';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss']
})

export class MovieDetailsComponent implements OnInit {

  // movie: Movie | undefined;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
  //   // First get the movie id from the current route.
  //   const routeParams = this.route.snapshot.paramMap;
  //   const movieIdFromRoute = Number(routeParams.get('movieId'));
  
  //   // Find the movie that correspond with the id provided in route.
  //   this.movie = movies.find((movie: { id: number; }) => movie.id === movieIdFromRoute);
  }
}
