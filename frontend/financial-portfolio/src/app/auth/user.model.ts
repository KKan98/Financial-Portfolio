import { Role } from "./role.model";

export class User {
  constructor(
    public id: string,
    public email: string,
    public role: Role,
    private _token: string,
    private _expiresAt: number
  ) {}
}
