import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignUpComponent } from './components/common/sign-up/sign-up.component';
import { SignInComponent } from './components/common/sign-in/sign-in.component';
import { SignOutComponent } from './components/common/sign-out/sign-out.component';
import { VerifyEmailComponent } from './components/common/verify-email/verify-email.component';
import { ResetPasswordComponent } from './components/common/reset-password/reset-password.component';
import { HeaderComponent } from './components/common/header/header.component';
import { FooterComponent } from './components/common/footer/footer.component';
import { HomepageComponent } from './components/common/homepage/homepage.component';

// Firebase services + environment module
import { AngularFireModule } from '@angular/fire/compat';
import { AngularFireAuthModule } from '@angular/fire/compat/auth';
import { AngularFireStorageModule } from '@angular/fire/compat/storage';
import { AngularFirestoreModule } from '@angular/fire/compat/firestore';
//import { AngularFireDatabaseModule } from '@angular/fire/compat/database';
import { environment } from '../environments/environment';
import { UserProfilePageComponent } from './components/common/user-profile-page/user-profile-page.component';


@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    SignInComponent,
    SignOutComponent,
    VerifyEmailComponent,
    ResetPasswordComponent,
    HeaderComponent,
    FooterComponent,
    HomepageComponent,
    UserProfilePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFireModule.initializeApp(environment.firebase),
    AngularFireAuthModule,
    AngularFireStorageModule,
    AngularFirestoreModule,
    //AngularFireDatabaseModule
    

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
