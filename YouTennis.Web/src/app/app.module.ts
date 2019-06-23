import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClubsComponent } from './components/clubs/clubs.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AuthGuard } from './auth.guard';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpConfigInterceptor } from './httpconfig.interceptor';
import { AddClubComponent } from './components/add-club/add-club.component';
import { CourtComponent } from './components/court/court.component';
import { AddCourtComponent } from './components/add-court/add-court.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { BookCourtComponent } from './components/book-court/book-court.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {DemoMaterialModule} from './material-module';
import {MatNativeDateModule} from '@angular/material';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import { TermsAndConditionsComponent } from './components/terms-and-conditions/terms-and-conditions.component';
import { StepsComponent } from './components/steps/steps.component';
import { DeleteCourtComponent } from './components/delete-court/delete-court.component';
import { DeleteClubComponent } from './components/delete-club/delete-club.component';
import { BookingsComponent } from './components/bookings/bookings.component';
import { AboutComponent } from './components/about/about.component';
//import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import {NgbDateStruct, NgbCalendar, NgbModule} from '@ng-bootstrap/ng-bootstrap';



const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },

  { path: 'clubs', component: ClubsComponent },
  { path: 'clubs/new', component: AddClubComponent, canActivate: [AuthGuard] },
  { path: 'clubs/:id/edit', component: AddClubComponent, canActivate: [AuthGuard] },
  { path: 'clubs/:id/courts', component: CourtComponent },
  { path: 'clubs/:id/courts/new', component: AddCourtComponent, canActivate: [AuthGuard] },
  { path: 'clubs/:id/courts/:courtId/book', component: BookCourtComponent, canActivate: [AuthGuard] },
  
  { path: 'login', component: LoginComponent },
  { path: 'account/register', component: RegisterComponent},
  { path: 'bookings', component: BookingsComponent, canActivate: [AuthGuard]},
  
  { path: 'terms-and-conditions', component: TermsAndConditionsComponent },
  { path: 'about', component: AboutComponent},

  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent }
];


@NgModule({
  declarations: [
    AppComponent,
    ClubsComponent,
    AddClubComponent,
    HeaderComponent,
    FooterComponent,
    RegisterComponent,
    LoginComponent,
    HomeComponent,
    NotFoundComponent,
    CourtComponent,
    AddCourtComponent,
    BookCourtComponent,
    TermsAndConditionsComponent,
    StepsComponent,
    DeleteCourtComponent,
    DeleteClubComponent,
    BookingsComponent,
    AboutComponent,
  ],
  imports: [
    BrowserModule,
    // AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
    MDBBootstrapModule.forRoot(),
    BrowserAnimationsModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    DemoMaterialModule,
    //FontAwesomeModule
    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpConfigInterceptor, multi: true },
    [AuthGuard]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
