import { Component, Inject } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { HeardAboutUs } from '../../core/heard-about-us';
import { HttpClient } from '@angular/common/http';

const API = 'api/newsletter/signup';

@Component({
  templateUrl: './newsletter.component.html',
  styleUrls: ['./newsletter.component.scss'],
})
export class NewsletterComponent {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  fg = new FormGroup({
    email: new FormControl<string | undefined>(undefined, [
      Validators.required /*, Validators.email*/,
      (control: AbstractControl<string | undefined>) => {
        const email = control.value;
        if (email == null) {
          return null;
        }
        const at = email.indexOf('@');
        if (!(at > 0 && at < email.length - 1)) {
          return {
            email: 'Email address is invalid',
          };
        }
        return null;
      },
    ]),
    other: new FormControl<string | undefined>(undefined),
    heardAboutUs: new FormControl<HeardAboutUs | undefined>(HeardAboutUs.Advert, [Validators.required]),
  });

  submit() {
    this.http.post(this.baseUrl + API, this.fg.value).subscribe({
      next: () => {
        alert('Thank you for signing up!');
      },
      error: (err) => {
        alert('Error: ' + err.error);
      },
    });
  }

  protected readonly HeardAboutUs = HeardAboutUs;
}
