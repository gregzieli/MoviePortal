export class ReviewDto {
    id: number;
    movieId: number;
    rating: number;
    title: string;
    text: string;
    authorName: string;
    reviewDate: Date;
}

export class ReviewItem {
    rating: number;
    title: string;
    text: string;
    authorName: string;
    reviewDate: Date;
}