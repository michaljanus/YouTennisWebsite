import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CourtService } from 'src/app/services/court.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Court } from 'src/app/models/court';

@Component({
  selector: 'app-add-court',
  templateUrl: './add-court.component.html',
  styleUrls: ['./add-court.component.scss']
})
export class AddCourtComponent implements OnInit {
  newForm: FormGroup;
  submitted = false;

  clubId: string;


  constructor(private formBuilder: FormBuilder, private clubService: CourtService, private router: Router, private route: ActivatedRoute) { }

  get f() { return this.newForm.controls; }

  ngOnInit() {
    this.newForm = this.formBuilder.group({
      city: ['', Validators.required],
      zipCode: '',
      street: '',
      streetNumber: '',
      hourPrice: '',
      image: '',
    });

    this.route.paramMap.subscribe(params => {
      this.clubId = (<any>params).params.id;
    });
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.newForm.invalid) {
      return;
    }
    let court: Court = {
      id: 0,
      clubId: parseInt(this.clubId),
      city: this.newForm.get('city').value,
      zipCode: this.newForm.get('zipCode').value,
      street: this.newForm.get('street').value,
      streetNumber: this.newForm.get('streetNumber').value,
      hourPrice: this.newForm.get('hourPrice').value,
      image: ''
    };
    this.clubService.create(court).subscribe(x => { this.router.navigate(['/']) });
  }
}
