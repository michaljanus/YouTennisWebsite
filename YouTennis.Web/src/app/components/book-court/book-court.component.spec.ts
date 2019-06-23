import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookCourtComponent } from './book-court.component';

describe('BookCourtComponent', () => {
  let component: BookCourtComponent;
  let fixture: ComponentFixture<BookCourtComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookCourtComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookCourtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
