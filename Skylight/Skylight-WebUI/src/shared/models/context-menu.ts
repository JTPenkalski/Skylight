import { NbMenuBag, NbMenuItem } from '@nebular/theme';

/**
 * An individual Context Menu option.
 */
export type ContextMenuItem = {
  item: NbMenuItem,
  action: () => void
}

/**
 * A strongly typed model for a Context Menu that handles when an item is interacted with.
 */
export class ContextMenu {
  constructor(
    public readonly tag: string,
    public readonly items: ContextMenuItem[]
  ) { }

  public get displayItems(): NbMenuItem[] { return this.items.map(x => x.item); }

  public handle(menu: NbMenuBag): void {
    if (menu.tag === this.tag) {
      this.items.find(x => x.item.title === menu.item.title)?.action()
    }
  }
}