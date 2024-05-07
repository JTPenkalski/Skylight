import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NbButtonComponent, NbButtonModule, NbLayoutComponent, NbLayoutModule, NbSidebarComponent, NbSidebarModule } from '@nebular/theme';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NbLayoutModule, NbSidebarModule, NbButtonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Skylight-WebUI';
}
