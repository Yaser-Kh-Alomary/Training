import { Injectable, NgZone } from '@angular/core';
import { User } from './user';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import * as auth from 'firebase/auth';
import{
  AngularFirestore,
  AngularFirestoreDocument
  
} from '@angular/fire/compat/firestore'
import { Route, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userdata:any;
  
  constructor(
    public afs: AngularFirestore,
    public afauth: AngularFireAuth,
    public router: Router,
    public ngzone: NgZone,
   // web: WebService

  ) { 
    this.afauth.authState.subscribe((user) => {
      /*
      if (user) {
        //L6
        this.userdata = user;
        localStorage.setItem('user', JSON.stringify(this.userdata));
        JSON.parse(localStorage.getItem('user')!);

        //
       this.router.navigate([this.redirectURL]);


      } else {
        //L6
        localStorage.setItem('user', 'null');
        JSON.parse(localStorage.getItem('user')!);

      }
      */
    });
  }

/*
  signIn(email: string, password: string) {
    return this.afauth.signInWithEmailAndPassword(email, password)
      .then(result => {
        this.ngzone.run(() => {
          if (result.user?.emailVerified) {
            if (result.user)
              this.web.getUser(result.user.uid).subscribe(user => {
                console.log(user);
                let userProfileDate = {
                  userID: result.user?.uid,
                  email: user.email,
                  phone: user.phone,
                  Name: user.name,
                  roleID: user.roleID,
                  gender: user.gender,
                  statusID: user.statusID,
                  emailVerified: result.user?.emailVerified
                }
                if (user.statusID == UserStatus.Active) {
                  this.SetUserValues('user', userProfileDate);
                  this.SetUserValues('userProfile', userProfileDate);

                  this.navigateToPage(user.roleID);
                } else if (user.statusID == UserStatus.Awaiting) {
                  $('#msg').text('حسابك يحتاج على موافقة مدير النظام')
                } else if (user.statusID == UserStatus.Disabled) {
                  $('#msg').text('حسابك معطل')
                } else if (user.statusID == UserStatus.Rejected) {
                  $('#msg').text('تم رفض تفعيل الحساب')
                }

                ;
              })
          } else {
            $('#msg').text('الرجاء تأكيد الريد الالكتروني,, عن طريق مراجعه البريد الوارد و الدخول الي الرابط المرفق في البريد')
          }


        });

      })
      .catch(err => {
        console.error(err);
        window.alert(err);
      })
  }

  navigateToPage(roleId: number) {
    this.redirectURL = '';
    this.router.navigate([this.redirectURL]);
  }

  SetUserValues(key: string, userProfile: any) {
    this.userdata = userProfile;
    console.log(this.userdata);
    localStorage.removeItem(key)
    localStorage.setItem(key, JSON.stringify(userProfile));
  }
  GetUserValues(key: string): any {

    let user = localStorage.getItem(key);
    if (user) {
      this.userdata = JSON.parse(user);
    }
    return this.userdata;
  }
  ClearUserValues(key: string) {
    localStorage.removeItem(key);
  }

  SignUP(formdata: any, user: any) {
    return this.afauth.createUserWithEmailAndPassword(user.email, user.password)
      .then(result => {
        this.sendverificationEmail();
        this.ngzone.run(() => {
          formdata.append('UserID', result.user?.uid);
          this.web.addUser(formdata).subscribe(result => {

            this.router.navigate(['verify-email']);
            let userProfileDate = {
              userID: result.user?.uid,
              email: user.email,
              phone: user.phone,
              Name: user.name,
              roleID: user.roleID,
              gender: user.gender,
              statusID: user.roleID == UserRole.Doctor ? UserStatus.Awaiting : UserStatus.Active,
              emailVerified: result.user.emailVerified

            }
            this.SetUserValues('user', userProfileDate);
            this.SetUserValues('userProfile', userProfileDate);
          })
        });
      })
      .catch(err => {
        console.error(err);
        window.alert(err);
      })
  }

  sendverificationEmail() {
    return this.afauth.currentUser
      .then(result => {
        result?.sendEmailVerification()

      })
      .then(() => {

      })
      .catch(err => {
        console.error(err);
        window.alert(err);
      })
  }

  ForgetPassword(accountOWnerEmail: string) {
    return this.afauth.sendPasswordResetEmail(accountOWnerEmail)
      .then(() => {
        console.error('email has been sent');
      })
      .catch(err => {
        console.error(err);
        window.alert(err);
      })
  }

  AuthLogin(provider: any) {
    return this.afauth.signInWithPopup(provider)
      .then(result => {
        this.ngzone.run(() => {
          this.redirectURL = 'patient-homepage';
        });
        this.SetUserValues('user', result.user);
      })
      .catch(err => {
        console.error(err);
        window.alert(err);
      })
  }

  signOut() {
    return this.afauth.signOut()
      .then
      (() => {
        localStorage.removeItem('user');
        localStorage.removeItem('userProfile');
        this.router.navigate(['login']);
      }
      )
      .catch(err => {
        console.error(err);
        window.alert(err);
      })
  }


  get isLoggedIn(): boolean {
    const user = JSON.parse(localStorage.getItem('user')!);
    const userProfile = JSON.parse(localStorage.getItem('userProfile')!);
    return user != null && (userProfile != undefined || userProfile != null) && user.emailVerified != false;
  }
  get isAdmin(): boolean {
    if (this.GetUserValues('userProfile'))
      return this.GetUserValues('userProfile').roleID == UserRole.Admin;
    else
      return false
  }
  get getUserID(): string {
    let userToSelect = this.GetUserValues('userProfile').userID;
    if (!userToSelect)
      userToSelect = this.GetUserValues('user').uid;

    return userToSelect;
  }
  get getUserRole(): number {
    let userToSelect = this.GetUserValues('userProfile').roleID;
    if (!userToSelect)
      userToSelect = this.GetUserValues('user').roleID;

    return userToSelect;
  }
  */
}
