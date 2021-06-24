import {Component, EventEmitter, Input, OnInit, Output} from "@angular/core";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Country} from "../country.model";
import {Province} from "../province.model";
import {MatSelectChange} from "@angular/material/select";
import {RegistrationModel} from "./registration.model";

@Component({
  selector: 'registration-stepper',
  templateUrl: 'registration-stepper.component.html',
  styleUrls: ['registration-stepper.component.css']
})

export class RegistrationStepperComponent implements OnInit {
  @Input() countries: Country[] = []
  @Input() provinces: Province[] = []
  @Output() onCountryChanged = new EventEmitter<Country>();
  @Output() onCreate = new EventEmitter<RegistrationModel>();

  accountFormGroup: FormGroup;
  locationFormGroup: FormGroup;
  private readonly _passwordValidationPattern: string = '^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$'

  constructor(private _fb: FormBuilder) {
  }

  ngOnInit() {

    this.accountFormGroup = this._fb.group({
      login: ['', Validators.email],
      password: ['', Validators.pattern(this._passwordValidationPattern)],
      confirmPassword: [''],
      agreeToWorkForFood: [false, Validators.required]
    }, {validators: this.checkPasswords})

    this.locationFormGroup = this._fb.group({
      country: [null, Validators.required],
      province: [null, Validators.required]
    })
  }

  onCountrySelected(evt: MatSelectChange){
    if(evt.value)
      this.onCountryChanged.emit(evt.value);
    this.provinces = [];
  }

  checkPasswords(group: FormGroup) {
    const password = group.get('password');
    const confirmPassword = group.get('confirmPassword');

    if(password.value === confirmPassword.value)
      confirmPassword.setErrors(null);
    else
      confirmPassword.setErrors({notSame: true});
  }

  onSubmit(){

  }
}
