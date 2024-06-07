/**
 * Basic information about a user.
 */
export class User {
  constructor(
    public stormTrackerId: string,
    public email: string,
    public firstName: string,
    public lastName: string
  ) { }
}
