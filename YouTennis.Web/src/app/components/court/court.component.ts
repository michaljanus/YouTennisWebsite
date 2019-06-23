import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CourtService } from 'src/app/services/court.service';
import { Court } from 'src/app/models/court';
import { UserService } from 'src/app/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-court',
  templateUrl: './court.component.html',
  styleUrls: ['./court.component.scss']
})
export class CourtComponent implements OnInit {
  public courts: Observable<Court[]>;
  public clubId: string;

  constructor(private courtService: CourtService, private userService: UserService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.clubId = (<any>params).params.id;
    });
    this.getAllCourts();
  }

  private getAllCourts() {
    this.courts = this.courtService.getByCourtId(this.clubId);
  }

  public isLogged(): boolean {
    return this.userService.isLoggedIn();
  }

  public isAdmin(): boolean {
    return this.userService.isAdmin();
  }

  public delete(item: Court) {
    this.courtService.delete(item.id).subscribe(() => {
      this.ngOnInit();
    });
  }

}
