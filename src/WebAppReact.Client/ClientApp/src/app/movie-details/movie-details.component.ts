import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieDetail } from '../movie/movie.model';
import { MovieService } from '../movie-service.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  movie: MovieDetail;

  constructor(private route: ActivatedRoute, private movieService: MovieService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.movieService.getMovie(+params.get("id"))
        .subscribe(x => {
          this.movie = x;
        }, err => console.log(err));        
    });
  }

}
