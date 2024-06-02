import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NbButtonModule, NbLayoutModule, NbSidebarModule } from '@nebular/theme';
import { NavBarComponent } from 'shared/components';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    NbLayoutModule,
    NbButtonModule,
    NbSidebarModule,
    NavBarComponent,
    RouterOutlet
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent { }
