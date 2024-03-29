import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { GenresComponent } from './core/layout/genres/genres.component';
import { MovieCardComponent } from './shared/component/movie-card/movie-card.component';
import { CreateMovieComponent } from './admin/create-movie/create-movie.component';
import { CreateCastComponent } from './admin/create-cast/create-cast.component';
import { UpdateCastComponent } from './admin/update-cast/update-cast.component';
import { UpdateMovieComponent } from './admin/update-movie/update-movie.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { PurchasedMoviesComponent } from './user/purchased-movies/purchased-movies.component';
import { FavoritedMoviesComponent } from './user/favorited-movies/favorited-movies.component';
import { ReviewedMoviesComponent } from './user/reviewed-movies/reviewed-movies.component';
import { ProfileComponent } from './user/profile/profile.component';
import { EditProfileComponent } from './user/edit-profile/edit-profile.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { NotAuthorizedComponent } from './shared/components/not-authorized/not-authorized.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    GenresComponent,
    MovieCardComponent,
    CreateMovieComponent,
    CreateCastComponent,
    UpdateCastComponent,
    UpdateMovieComponent,
    LoginComponent,
    RegisterComponent,
    PurchasedMoviesComponent,
    FavoritedMoviesComponent,
    ReviewedMoviesComponent,
    ProfileComponent,
    EditProfileComponent,
    MovieDetailsComponent,
    NotFoundComponent,
    NotAuthorizedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
