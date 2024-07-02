import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {
  NbButtonModule,
  NbLayoutModule,
  NbSidebarModule,
} from '@nebular/theme';
import { NavBarComponent } from 'shared/components';
import { UserService } from 'shared/services';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    NbLayoutModule,
    NbButtonModule,
    NbSidebarModule,
    NavBarComponent,
    RouterOutlet,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  constructor(private readonly userService: UserService) {}

  public ngOnInit(): void {
    // Automatically sign the user in, if their credentials are still valid
    this.userService.trySignIn();
  }
}
