import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AlbumsTableComponent } from './albums-table/albums-table.component';
import { MyAlbumsComponent } from './my-albums/my-albums.component';
import { AlbumViewComponent } from './album-view/album-view.component';
import { AppRoutingModule } from './app-routing.module';
import { RegisterComponent } from './register/register.component';
import { CreateAlbumComponent } from './create-album/create-album.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthGuard } from './auth.guard';
import {TokenInterceptorService} from "./services/token-interceptor.service";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { UploadImageComponent } from './upload-image/upload-image.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AlbumsTableComponent,
    MyAlbumsComponent,
    AlbumViewComponent,
    RegisterComponent,
    CreateAlbumComponent,
    UploadImageComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    MatSnackBarModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatMenuModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
