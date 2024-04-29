import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AlbumsTableComponent } from './albums-table/albums-table.component';
import { MyAlbumsComponent } from './my-albums/my-albums.component';
import { AlbumViewComponent } from './album-view/album-view.component';
import {RegisterComponent} from "./register/register.component";
import {CreateAlbumComponent} from "./create-album/create-album.component";
import {AuthGuard} from "./auth.guard";
import {UploadImageComponent} from "./upload-image/upload-image.component";
import { BrowserModule } from '@angular/platform-browser';

const routes: Routes = [
  { path: '', redirectTo: '/albums', pathMatch: 'full' },
  { path: 'add-album', component: CreateAlbumComponent, canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'albums', component: AlbumsTableComponent },
  { path: 'my-albums', component: MyAlbumsComponent },
  { path: 'upload-image', component: UploadImageComponent },
  { path: 'albums/:id', component: AlbumViewComponent },
];

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
