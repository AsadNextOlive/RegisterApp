import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterListComponent } from './register-list.component';

describe('RegisterListComponent', () => {
  let component: RegisterListComponent;
  let fixture: ComponentFixture<RegisterListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
