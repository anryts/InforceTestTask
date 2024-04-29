import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  private baseUrl = 'http://localhost:5218'; // Base URL for API

  constructor(private http: HttpClient) {
  }

  getImages(albumId: string, amountOfImages: number, offset: number) {
    return this.http.get<any>(`${this.baseUrl}/api/Image/${albumId}`, {
      params: {
        AmountOfImages: amountOfImages.toString(),
        Offset: offset.toString()
      }
    });
  }

  uploadImage(albumId: string, title: string, image: File) {
    const formData = new FormData();
    formData.append('file', image);

    // Note: The 'title' is passed as a query parameter in the URL
    const uploadUrl = `${this.baseUrl}/api/Image/${albumId}?title=${encodeURIComponent(title)}`;

    return this.http.post<any>(uploadUrl, formData);
  }
}
