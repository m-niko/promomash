import {NgModule} from "@angular/core";
import {RouterModule} from "@angular/router";
import {MatSliderModule} from "@angular/material/slider";
import {RegistrationPageComponent} from "./account/registration/registration-page.component";
import {FeaturesAccountModule} from "../features/account/features-account.module";
import { SuccessPageComponent } from './shared/success-page/success-page.component';
import {MatSnackBarModule} from "@angular/material/snack-bar";

@NgModule({
  imports: [
    RouterModule.forChild([
      {path: 'account/registration', component: RegistrationPageComponent},
      {path: 'account/registration/success', component: SuccessPageComponent}

    ]),
    MatSliderModule,
    MatSnackBarModule,
    FeaturesAccountModule
  ],
  declarations: [RegistrationPageComponent, SuccessPageComponent],
  exports: [RegistrationPageComponent],
})

export class PagesAccountModule { }
