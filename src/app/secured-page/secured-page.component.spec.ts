import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecuredPageComponent } from './secured-page.component';

describe('SecuredPageComponent', () => {
  let component: SecuredPageComponent;
  let fixture: ComponentFixture<SecuredPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SecuredPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SecuredPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
