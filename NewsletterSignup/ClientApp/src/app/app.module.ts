import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NewsletterComponent } from './components/newsletter/newsletter.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { TextFieldModule } from '@angular/cdk/text-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSnackBarModule } from '@angular/material/snack-bar';
@NgModule({
  declarations: [AppComponent, NewsletterComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([{ path: '', component: NewsletterComponent, pathMatch: 'full' }]),
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatRadioModule,
    TextFieldModule,
    MatCardModule,
    MatSnackBarModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
