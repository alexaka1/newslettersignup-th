import { Component, Inject } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { HeardAboutUs } from '../../core/heard-about-us';
import { HttpClient } from '@angular/common/http';

const API = 'api/newsletter/signup';
const emailValidation: ValidatorFn = (control: AbstractControl<unknown | null | undefined>) => {
  const email = control.value;
  if (email == null) {
    return null;
  }
  if (typeof email !== 'string') {
    return {
      email: 'Email address is invalid',
    };
  }
  const at: number = email.indexOf('@');
  if (!(at > 0 && at < email.length - 1)) {
    return {
      email: 'Email address is invalid',
    };
  }
  return null;
};

@Component({
  templateUrl: './newsletter.component.html',
  styleUrls: ['./newsletter.component.scss'],
})
export class NewsletterComponent {
  fg = new FormGroup({
    email: new FormControl<string | undefined>(undefined, [
      Validators.required,
      Validators.maxLength(450) /*, Validators.email*/,
      emailValidation,
    ]),
    other: new FormControl<string | undefined>(undefined, [Validators.maxLength(500)]),
    heardAboutUs: new FormControl<HeardAboutUs | undefined>(HeardAboutUs.Advert, [Validators.required]),
  });
  protected readonly HeardAboutUs = HeardAboutUs;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  submit() {
    this.http.post(this.baseUrl + API, this.fg.value).subscribe({
      next: () => {
        alert('Thank you for signing up!');
      },
      error: (e) => {
        // not my proudest work :)
        const err = e?.error;
        if (
          err != null &&
          typeof err === 'object' &&
          'errors' in err &&
          err.errors != null &&
          typeof err.errors === 'object' &&
          Object.keys(err.errors).length > 0
        ) {
          const error = err.errors[Object.keys(err.errors)[0]] as unknown;
          if (typeof error === 'string') {
            alert(error);
            return;
          }
          if (Array.isArray(error) && error.length > 0 && typeof error[0] === 'string') {
            alert(error[0]);
            return;
          }
        }
        alert('There was an error with your submission. We apologize for any inconveniences, please try again later!');
      },
    });
  }
}
