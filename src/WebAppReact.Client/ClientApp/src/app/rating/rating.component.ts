import { Component, OnInit } from '@angular/core';
import { MovieService } from '../movie-service.service';
import { ActivatedRoute } from '@angular/router';
import { MovieDetail } from '../movie/movie.model';
import { RateInput } from './rate.model';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnInit {
  movie: MovieDetail;
  public rate: number;
  public title: string = "";
  public text: string = "";

  constructor(private route: ActivatedRoute, private movieService: MovieService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.movieService.getMovie(+params.get("id"))
        .subscribe(x => {
          this.movie = x;
        }, err => console.log(err));        
    });
  }

  rateMovie() {
    let input = new RateInput();
    input.movieId = this.movie.id;
    input.rate = this.rate;
    input.reviewText = this.text;
    input.reviewTitle = this.title;

    this.movieService.rateMovie(input)
      .subscribe(x => {
        console.log(x);
      }, err => console.log(err));
  }

}
