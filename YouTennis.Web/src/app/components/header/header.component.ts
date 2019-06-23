import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private userService: UserService, private router: Router) {
  //   this.userService.authNavStatusSource.subscribe(() => {
  //     this.ngOnInit();
  //         });
  //  }
  }

  ngOnInit() {
  }

  isLoggedIn() {
    return this.userService.isLoggedIn();
  }
  getLoginString() {

    if (this.userService.isLoggedIn()) {
      return "Log out";
    } else {
      return "Log in";
    }
  }

  logClick(){
    console.log("test");
    if (this.userService.isLoggedIn()) {
      this.router.navigate(['/']);
      this.userService.logout();
      

    } else {
      this.router.navigate(['login']);
    }
  }


  
}
