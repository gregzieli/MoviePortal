import { Component, OnInit, Input } from '@angular/core';
import { ReviewDto, ReviewItem } from '../rating/rate.model';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from '../movie-service.service';

@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {
  reviews: ReviewItem[];

  @Input()
    movieId: number;

  constructor(private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.getReviews(this.movieId)
        .subscribe(x => {
          this.reviews = x;
        }, err => console.log(err));  
  }

}
