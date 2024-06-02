import { Component, OnInit } from '@angular/core';
import { NbButtonModule } from '@nebular/theme';
import { UserService } from 'shared/services';

@Component({
  selector: 'skylight-nav-bar',
  standalone: true,
  imports: [
    NbButtonModule
  ],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent implements OnInit {
  public isSignedIn: boolean = false;

  constructor(private readonly userService: UserService) { }

  public ngOnInit(): void {
    this.userService.isSignedIn()
      .subscribe(result => this.isSignedIn = result);
  }
}
