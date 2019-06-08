import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { MovieDetail } from './movie/movie.model';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getMovie(id: number) : Observable<MovieDetail> {
    return this.http.get<MovieDetail>(`${this.baseUrl}api/Movie/GetMovie/${id}`);
  }

}
