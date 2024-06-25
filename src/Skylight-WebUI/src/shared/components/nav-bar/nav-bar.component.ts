import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbButtonModule, NbContextMenuModule, NbMenuService, NbUserModule } from '@nebular/theme';
import { ContextMenu } from 'shared/models';
import { User, UserService } from 'shared/services';

@Component({
  selector: 'skylight-nav-bar',
  standalone: true,
  imports: [NbButtonModule, NbContextMenuModule, NbUserModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
})
export class NavBarComponent implements OnInit {
  public userName: string = User.UNKNOWN;
  public user?: User;
  public userContextMenu: ContextMenu = new ContextMenu('skylight-nav-bar-user-menu', [
    {
      item: {
        title: 'Profile',
      },
      action: () => console.log('Profile clicked!'),
    },
    {
      item: {
        title: 'Sign Out',
      },
      action: () => {
        this.userService.signOut().subscribe();
        this.router.navigate(['/home']);
      },
    },
  ]);

  constructor(
    private readonly router: Router,
    private readonly userService: UserService,
    private readonly menuService: NbMenuService,
  ) {}

  public get isSignedIn(): boolean {
    return !!this.user;
  }

  public ngOnInit(): void {
    this.userService.currentUserChanged.subscribe((result) => {
      this.user = result;
      this.userName = result?.fullName ?? User.UNKNOWN;
    });

    this.menuService.onItemClick().subscribe((x) => this.userContextMenu.handle(x));
  }
}
