import { Component, OnInit } from '@angular/core';
import { AlbumService } from '../services/album.service';
import {Album} from "../interfaces/album";
import {Image} from "../interfaces/image";
import { Router } from '@angular/router';

@Component({
  selector: 'app-albums-table',
  templateUrl: './albums-table.component.html',
  styleUrls: ['./albums-table.component.css']
})
export class AlbumsTableComponent implements OnInit {
  albums: Album[] = [];
  currentPage: number = 0;
  pageSize: number = 5;
  disableNextButton: boolean = false;
  private baseUrl = 'http://localhost:5218'; // Base URL for API

  constructor(private albumService: AlbumService,
              private router: Router) {}

  ngOnInit() {
    this.loadAlbums();
  }

  viewAlbum(albumId: string) {
    this.router.navigate(['/albums', albumId]);
  }


  loadAlbums() {
    this.albumService
      .getAlbums(this.pageSize, this.currentPage * this.pageSize)
      .subscribe( albums => {
          this.albums = albums.map((album: Album) => {
            return {
              ...album,
              coverImageUrl: `${this.baseUrl}/${album.coverImageUrl}` // Prepend base URL to the image URL
            };
          });
          // Disable next button if the returned items are less than page size
          if (albums.length < this.pageSize) {
            this.disableNextButton = true;
          }
        });
  }

  nextPage() {
    if (!this.disableNextButton) {
      this.currentPage++;
      this.loadAlbums();
    }
  }

  previousPage() {
    if (this.currentPage > 0) {
      this.currentPage--;
      this.loadAlbums();
    }
  }
}
