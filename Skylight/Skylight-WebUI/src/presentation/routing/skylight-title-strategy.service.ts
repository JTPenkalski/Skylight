import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { RouterStateSnapshot, TitleStrategy } from '@angular/router';

@Injectable()
export class SkylightTitleStrategy extends TitleStrategy {
  private static readonly APP_NAME: string = 'Skylight';

  constructor(private readonly title: Title) {
    super();
  }

  public override updateTitle(routerState: RouterStateSnapshot): void {
    const title = this.buildTitle(routerState);

    this.title.setTitle(
      (title !== undefined && title !== '')
        ? `${SkylightTitleStrategy.APP_NAME} | ${title}`
        : SkylightTitleStrategy.APP_NAME
    );
  }
}
