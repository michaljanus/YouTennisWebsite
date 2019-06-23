import { Component, OnInit } from '@angular/core';
import { ClubService } from 'src/app/services/club.service';
import { Observable } from 'rxjs';
import { Club } from 'src/app/models/club';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clubs',
  templateUrl: './clubs.component.html',
  styleUrls: ['./clubs.component.scss']
})
export class ClubsComponent implements OnInit {
  public clubs: Observable<Club[]>;

  constructor(private clubService: ClubService, private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.getAllClubs();
  }

  private getAllClubs() {
    this.clubs = this.clubService.getAll();
  }

  public isLogged(): boolean  {
    return this.userService.isLoggedIn();
  }

  public isAdmin(): boolean {
    return this.userService.isAdmin();
  }

  public delete(item: Club) {
    this.clubService.delete(item.id).subscribe(() => {
      this.ngOnInit();
    });
  }
/*
  public getCourtRoute(club: Club): string {
    return `clubs/:${club.id}/courts`;
  }*/
}
