import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RegistrationPageComponent } from './registration-page.component';
import {FeaturesAccountModule} from "../../../features/account/features-account.module";
import {HttpClientModule} from "@angular/common/http";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {RouterTestingModule} from "@angular/router/testing";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

describe('SuccessPageComponent', () => {
  let component: RegistrationPageComponent;
  let fixture: ComponentFixture<RegistrationPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrationPageComponent ],
      imports: [FeaturesAccountModule, HttpClientModule, MatSnackBarModule, RouterTestingModule, BrowserAnimationsModule],
      providers: [{provide: 'BASE_URL', useValue: ''}]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationPageComponent);
    component = fixture.componentInstance;

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
