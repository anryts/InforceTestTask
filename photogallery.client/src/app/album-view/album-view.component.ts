import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; // Import ActivatedRoute
import { MatDialog } from '@angular/material/dialog';
import {ImageService} from "../services/image.service";
import {Image} from "../interfaces/image";
import {UploadImageComponent} from "../upload-image/upload-image.component";

@Component({
  selector: 'app-album-view',
  templateUrl: './album-view.component.html',
  styleUrls: ['./album-view.component.css']
})
export class AlbumViewComponent implements OnInit {

  images: Image[] = [];
  currentPage: number = 0;
  pageSize: number = 5;
  disableNextButton: boolean = false;
  albumId: string = '';
  private baseUrl = 'http://localhost:5218'; // Base URL for API
  constructor(private imageService: ImageService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    const albumId = this.route.snapshot.paramMap.get('id') as string;
    this.loadImages(albumId);
  }

  loadImages(albumId: string) {
    // Load images for the current album
    this.imageService
      .getImages(albumId, this.pageSize, this.currentPage * this.pageSize)
      .subscribe(images => {
        this.images = images.map((image: Image) => {
          return {
            ...image,
            url: `${this.baseUrl}/${image.url}` // Prepend base URL to the image URL
          };
        });
        if (images.length < this.pageSize) {
          this.disableNextButton = true;
        }
      });
  }

  nextPage(albumId: string) {
    if (!this.disableNextButton) {
      this.currentPage++;
      this.loadImages(albumId);
    }
  }

  previousPage(albumId: string) {
    if (this.currentPage > 0) {
      this.currentPage--;
      this.loadImages(albumId);
    }
  }
}
