import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MovieItem, Genre } from './movie.model';
// import { MovieService } from './movie.service';

@Component({
  selector: 'movies',
  templateUrl: './movies.component.html'
})
export class MoviesComponent {
  public movies: MovieItem[];

  public getMovie(id: number): void {
    debugger
    // this.service.getMovie(id)
    // .subscribe(result => {
    //   debugger;
    // }, error => console.error(error));
  }

  constructor(http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string,
    // private service: MovieService
    ) {
    http.get<MovieItem[]>(baseUrl + 'api/Movie/GetAllMovies').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }
}