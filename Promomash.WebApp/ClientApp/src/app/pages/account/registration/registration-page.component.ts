import {Component, OnInit} from "@angular/core";
import {Country} from "../../../features/account/country.model";
import {CountryService} from "../../../features/account/country.service";
import {Province} from "../../../features/account/province.model";

@Component({
  selector: 'registration-page',
  templateUrl: 'registration-page.component.html'
})

export class RegistrationPageComponent implements OnInit{
  countries: Country[]
  provinces: Province[]
  constructor(private _countryService: CountryService) {
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
}
