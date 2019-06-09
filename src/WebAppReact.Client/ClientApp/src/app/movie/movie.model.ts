export interface MovieItem {
    id: number;
    title: string;
    premiereDate: Date;
    rating: number;
    reviewCount: number;
    genre: Genre;
    image: string;
}

export interface MovieDetail {
    id: number;
    title: string;
    premiereDate: Date;
    rating: number;
    genre: Genre;
    image: string;
}

export interface MovieFilter {
    title: string;

    year: number;

    rating: number;

    genre: Genre;

    pageNumber: number;

    size: number;
}

export enum Genre {
    Drama = 0,
    Comedy = 1,
    Action = 2,
    Historical = 3,
    Musical = 4,
    Horror = 5,
    Thriller = 6
}