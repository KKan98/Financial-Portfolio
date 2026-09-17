import { Role } from "./role.model";

export class User {
  constructor(
    public id: string,
    public email: string,
    public role: Role,
    private _token: string,
    private _expiresAt: Date
  ) {}

  get token() {
    if(!this._token || new Date() > this._expiresAt) return null;

    return this._token;
  }
}
