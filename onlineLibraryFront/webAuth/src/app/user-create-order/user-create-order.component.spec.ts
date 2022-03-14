import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserCreateOrderComponent } from './user-create-order.component';

describe('UserCreateOrderComponent', () => {
  let component: UserCreateOrderComponent;
  let fixture: ComponentFixture<UserCreateOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserCreateOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserCreateOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
