import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Club } from 'src/app/models/club';
import { ClubService } from 'src/app/services/club.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-club',
  templateUrl: './add-club.component.html',
  styleUrls: ['./add-club.component.scss']
})
export class AddClubComponent implements OnInit {
  newForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder, private clubService: ClubService, private router: Router) {
  }

  get f() { return this.newForm.controls; }

  ngOnInit() {
    this.newForm = this.formBuilder.group({
      name: ['', Validators.required]
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.newForm.invalid) {
        return;
    }
    let club: Club = {
      id: 0, 
      name: this.newForm.get('name').value
    };
    this.clubService.create(club).subscribe(x => {this.router.navigate(['/clubs'])});
}

}
