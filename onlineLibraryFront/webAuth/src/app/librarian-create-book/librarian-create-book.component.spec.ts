import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibrarianCreateBookComponent } from './librarian-create-book.component';

describe('LibrarianCreateBookComponent', () => {
  let component: LibrarianCreateBookComponent;
  let fixture: ComponentFixture<LibrarianCreateBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LibrarianCreateBookComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LibrarianCreateBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
