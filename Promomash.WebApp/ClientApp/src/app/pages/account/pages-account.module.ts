import {NgModule} from "@angular/core";
import {RegistrationPageComponent} from "./registration/registration-page.component";
import {RouterModule} from "@angular/router";
import {MatSliderModule} from "@angular/material/slider";
import {FeaturesAccountModule} from "../../features/account/features-account.module";

@NgModule({
  imports: [
    RouterModule.forChild([
      {path: 'account/registration', component: RegistrationPageComponent}
    ]),
    MatSliderModule,
    FeaturesAccountModule
  ],
  declarations: [RegistrationPageComponent],
  exports: [RegistrationPageComponent],
})

export class PagesAccountModule { }
