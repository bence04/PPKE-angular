import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RegisterComponent } from '../dialog/register/register.component';
import { ApiService } from 'src/app/shared/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user = {
    felhasznaloNev: '',
    jelszo: ''
  };
  errorMsg: string;

  constructor(public dialog: MatDialog, private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.apiService.login(this.user).subscribe((token: any) => {
      localStorage.setItem('jwt', token.accessToken);
      this.router.navigate(['/semesters']);
    },
    (error) => this.errorMsg = error.error);
  }

  register() {
    const dialogRef = this.dialog.open(RegisterComponent, {
      width: '450px'
    });

    dialogRef.afterClosed().subscribe(result => {
      this.apiService.register(result).subscribe(resp => {
        alert('Sikeres regisztráció!');
      });
    });
  }

}
