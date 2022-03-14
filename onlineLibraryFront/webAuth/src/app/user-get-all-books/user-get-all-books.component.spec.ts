import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserGetAllBooksComponent } from './user-get-all-books.component';

describe('UserGetAllBooksComponent', () => {
  let component: UserGetAllBooksComponent;
  let fixture: ComponentFixture<UserGetAllBooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserGetAllBooksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserGetAllBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
