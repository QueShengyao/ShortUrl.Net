import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  originalUrl = '';
  latestResult: ShortUrlResult | null = null;
  recentUrls: ShortUrlResult[] = [];
  errorMessage = '';
  isSubmitting = false;

  constructor(
    private readonly http: HttpClient,
    @Inject('BASE_URL') private readonly baseUrl: string
  ) {}

  ngOnInit(): void {
    this.loadRecentUrls();
  }

  shortenUrl(): void {
    this.errorMessage = '';
    this.isSubmitting = true;

    this.http.post<ShortUrlResult>(`${this.baseUrl}api/shorturls`, {
      originalUrl: this.originalUrl
    }).subscribe(
      result => {
        this.latestResult = {
          ...result,
          fullShortUrl: `${this.baseUrl.replace(/\/$/, '')}/${result.shortUrl}`
        };
        this.originalUrl = '';
        this.isSubmitting = false;
        this.loadRecentUrls();
      },
      (error: HttpErrorResponse) => {
        this.errorMessage = error.error && error.error.detail
          ? error.error.detail
          : 'Unable to shorten that URL.';
        this.isSubmitting = false;
      }
    );
  }

  private loadRecentUrls(): void {
    this.http.get<ShortUrlResult[]>(`${this.baseUrl}api/shorturls?count=10`).subscribe(
      result => this.recentUrls = result.map(item => ({
        ...item,
        fullShortUrl: `${this.baseUrl.replace(/\/$/, '')}/${item.shortUrl}`
      })),
      () => this.errorMessage = 'Unable to load recent short URLs.'
    );
  }
}

interface ShortUrlResult {
  shortUrl: string;
  originalUrl: string;
  createdTime: string;
  fullShortUrl?: string;
}
