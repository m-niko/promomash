import {Component, OnInit} from "@angular/core";
import {Country} from "../../../features/account/country.model";
import {CountryService} from "../../../features/account/country.service";
import {Province} from "../../../features/account/province.model";
import {RegistrationModel} from "../../../features/account/registration/registration.model";
import {AccountService} from "../../../features/account/user.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Router} from "@angular/router";

@Component({
  selector: 'registration-page',
  templateUrl: 'registration-page.component.html'
})

export class RegistrationPageComponent implements OnInit{
  countries: Country[]
  provinces: Province[]
  constructor(private _countryService: CountryService,
              private _accountService: AccountService,
              private _snackBar: MatSnackBar,
              private _router: Router) {
  }

  ngOnInit(): void {
    this._countryService
      .getCountries()
      .subscribe(c => {
        this.countries = c
      });
  }

  onCountryChanged(country: Country){
    this._countryService
      .getProvincesByCountryId(country.id)
      .subscribe(p => this.provinces = p);
  }

  onCreate(data: RegistrationModel){
    this._accountService.create(data).subscribe(() => {
      this._router.navigate(["account/registration/success"])
    }, error => {
      this._snackBar.open(error.message, 'Ok', {
        duration: 5000
      });
    })
  }
}
