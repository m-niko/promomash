import {Inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {RegistrationModel} from "./registration/registration.model";

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  private readonly apiHost: string;
  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiHost = `${baseUrl}api/users`;
  }

  create(formData: RegistrationModel): Observable<any> {
    return this._http.post(this.apiHost, formData);
  }
}

