import {Component} from '@angular/core';
import {AlbumService} from '../services/album.service';
import {Router} from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-create-album',
  templateUrl: './create-album.component.html',
  styleUrls: ['./create-album.component.css']
})
export class CreateAlbumComponent {
  albumName: string = '';

  constructor(private albumService: AlbumService,
              private router: Router,
              private snackBar: MatSnackBar) {
  }

  createAlbum() {
    if (this.albumName) {
      this.albumService.createAlbum(this.albumName).subscribe({
        next: (album) => {
           this.snackBar.open('Album created successfully!', 'Close', {
            duration: 3000 // lasts for 3 seconds
          });
          this.router.navigate(['/albums']); // Redirect or handle response
        },
        error: (error) => {
          this.snackBar.open('Failed to create album', 'Close', {
            duration: 3000
          });
        }
      });
    }
  }
}
