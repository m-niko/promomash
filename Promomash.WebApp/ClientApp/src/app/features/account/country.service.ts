import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Country} from "./country.model";
import {Province} from "./province.model";
import {Inject, Injectable} from "@angular/core";
import {map, tap} from "rxjs/operators";

@Injectable()
export class CountryService {
    private readonly apiHost: string;
    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      debugger
      this.apiHost = `${baseUrl}api/countries`;
    }

    getCountries(): Observable<Country[]> {
        return this._http.get<any>(this.apiHost)
          .pipe(map(val => val.countries as Country[]));
    }

    getProvincesByCountryId(countryId: number): Observable<Province[]> {
        return this._http.get<any>(`${this.apiHost}/${countryId}/provinces`)
          .pipe(map(val => val.provinces as Province[]));
    }
}
