import { Component } from '@angular/core';
import { ImageService } from '../services/image.service';
import {Album} from "../interfaces/album";
import {AlbumService} from "../services/album.service";

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})
export class UploadImageComponent {
  albums: Album[] = [];
  selectedAlbumId: string | null = null;
  selectedAlbumName: string | null = null;
  selectedFile: File | null = null;
  imageTitle: string = '';

  constructor(private imageService: ImageService,
              private albumService: AlbumService) {
    this.albumService.getAlbumForUser(10, 0)
      .subscribe(albums => {
        this.albums = albums;
      });
  }

  selectAlbum(album: any): void {
    this.selectedAlbumId = album.id;
    this.selectedAlbumName = album.name;
  }

    onFileSelected(event: Event): void {
    const element = event.currentTarget as HTMLInputElement;
    let fileList: FileList | null = element.files;
    if (fileList && fileList.length > 0) {
      this.selectedFile = fileList[0];
    } else {
      this.selectedFile = null;
    }
  }

  uploadImage(): void {
    if (this.selectedFile && this.imageTitle && this.selectedAlbumId) {
      this.imageService.uploadImage(this.selectedAlbumId, this.imageTitle, this.selectedFile)
        .subscribe({
          next: (response) => {
            console.log('Image uploaded successfully!', response);
            alert('Image uploaded successfully!');
          },
          error: (error) => {
            console.error('Error uploading image:', error);
            alert('Failed to upload image.');
          }
        });
    } else {
      alert('Please select a file, enter a title, and select an album.');
    }
  }
}
