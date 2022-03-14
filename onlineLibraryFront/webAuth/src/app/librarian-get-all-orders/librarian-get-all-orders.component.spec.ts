import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibrarianGetAllOrdersComponent } from './librarian-get-all-orders.component';

describe('LibrarianGetAllOrdersComponent', () => {
  let component: LibrarianGetAllOrdersComponent;
  let fixture: ComponentFixture<LibrarianGetAllOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LibrarianGetAllOrdersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LibrarianGetAllOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
