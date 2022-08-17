import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FooterComponent } from './components/common/footer/footer.component';
import { HeaderComponent } from './components/common/header/header.component';
import { HomepageComponent } from './components/common/homepage/homepage.component';
import { ResetPasswordComponent } from './components/common/reset-password/reset-password.component';
import { SignInComponent } from './components/common/sign-in/sign-in.component';
import { SignOutComponent } from './components/common/sign-out/sign-out.component';
import { SignUpComponent } from './components/common/sign-up/sign-up.component';
import { UserProfilePageComponent } from './components/common/user-profile-page/user-profile-page.component';
import { VerifyEmailComponent } from './components/common/verify-email/verify-email.component';

const routes: Routes = [
  //common 
  { path: '' , component: HomepageComponent },
  { path: 'sign_up' , component: SignUpComponent },
  { path: 'sign_in' , component: SignInComponent },
  { path: 'sign_out' , component: SignOutComponent },
  { path: 'reset-password' , component: ResetPasswordComponent },
  { path: 'verify-email' , component: VerifyEmailComponent },
  { path: 'header' , component: HeaderComponent },
  { path: 'user-profile-page' , component: UserProfilePageComponent },
  { path: 'footer' , component: FooterComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
