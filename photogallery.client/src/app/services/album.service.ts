import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  private baseUrl = 'http://localhost:5218'; // Base URL for API
  albumName: string = '';

  constructor(private http: HttpClient) { }

  getAlbums(amountOfAlbums: number, offset: number): Observable<any> {
    let params = new HttpParams()
      .set('AmountOfAlbums', amountOfAlbums.toString())
      .set('Offset', offset.toString());

    return this.http.get<any>(`${this.baseUrl}/api/Album`, { params });
  }

  getAlbumForUser(amountOfAlbums: number, offset: number): Observable<any> {
    let params = new HttpParams()
      .set('AmountOfAlbums', amountOfAlbums.toString())
      .set('Offset', offset.toString());

    return this.http.get<any>(`${this.baseUrl}/api/Album/album_current_user`, { params });
  }

  createAlbum(name: string): Observable<any> {
    const albumData = { albumName: name };

    // POST request to the backend to create a new album
    return this.http.post<any>(`${this.baseUrl}/api/Album`, albumData);
  }
}
