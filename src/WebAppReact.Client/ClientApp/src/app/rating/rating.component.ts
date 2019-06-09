import { Component, OnInit } from '@angular/core';
import { MovieService } from '../movie-service.service';
import { ActivatedRoute } from '@angular/router';
import { MovieDetail } from '../movie/movie.model';
import { ReviewDto, ReviewDetail } from './rate.model';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnInit {
  movie: MovieDetail;
  review: ReviewDetail;
  public rating: number;
  public title: string;
  public textValue: string;

  constructor(private route: ActivatedRoute, private movieService: MovieService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.movieService.getMovie(+params.get("id"))
        .subscribe(x => {
          this.movie = x;
        }, err => console.log(err));        
    });
  }

  ngOnInit2() {
    this.route.paramMap.subscribe(params => {
      this.movieService.getReviewDetail(+params.get("id"))
        .subscribe(x => {
          this.review = x;
        }, err => console.log(err));        
    });
  }

  rateMovie() {
    let input = new ReviewDto();
    input.movieId = this.movie.id;
    input.rating = this.rating;
    input.text = this.textValue;
    input.title = this.title;

    this.movieService.rateMovie(input)
      .subscribe(x => {
        location.href = "/movies/" + this.movie.id;
      }, err => console.log(err));
  }

}
