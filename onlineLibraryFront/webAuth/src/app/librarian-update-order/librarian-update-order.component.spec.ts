import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibrarianUpdateOrderComponent } from './librarian-update-order.component';

describe('LibrarianUpdateOrderComponent', () => {
  let component: LibrarianUpdateOrderComponent;
  let fixture: ComponentFixture<LibrarianUpdateOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LibrarianUpdateOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LibrarianUpdateOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
