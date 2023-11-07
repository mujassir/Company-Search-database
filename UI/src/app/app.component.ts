import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  isLoggedIn$!: Observable<boolean>;
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.authService.AutoLogedIn()
    this.isLoggedIn$ = this.authService.isLoggedIn$;
    this.isLoggedIn$.subscribe(isLoggedIn => {

      if (!isLoggedIn) this.router.navigate(['/login']);
      if (!isLoggedIn && location.pathname === "/login") this.router.navigate(['/']);

    });

  }
}
