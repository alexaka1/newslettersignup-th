import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public text = 'not found';

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<{ text: string }>(baseUrl + 'api/newsletter/test').subscribe({
      next: (value) => {
        this.text = value.text;
      },
    });
  }
}
