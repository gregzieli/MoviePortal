// import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { Observable } from "rxjs";
// import { MovieDetail } from "./movie.model";
// import { Inject } from '@angular/core';
// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root',
// })
// export class MovieService {
//     constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){ }

//     getMovie(id: number): Observable<MovieDetail> {
//         return this.http.get(`${this.baseUrl}api/Movie/GetAllMovies/${id}`)
//     }
// }