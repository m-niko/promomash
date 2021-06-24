import {NgModule} from "@angular/core";
import {RegistrationStepperComponent} from "./registration/registration-stepper.component";
import {MatStepperModule} from "@angular/material/stepper";
import {ReactiveFormsModule} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {CommonModule} from "@angular/common";
import {MatSelectModule} from "@angular/material/select";
import {CountryService} from "./country.service";
import {AccountService} from "./user.service";

@NgModule({
    imports: [
        MatStepperModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatCheckboxModule,
        CommonModule,
        MatSelectModule
    ],
  exports: [
    RegistrationStepperComponent
  ],
  declarations: [RegistrationStepperComponent],
  providers: [CountryService, AccountService]
})

export class FeaturesAccountModule{}
