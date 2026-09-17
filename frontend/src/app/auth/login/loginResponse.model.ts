import { Role } from "../role.model"

export type LoginResponse = { //Duplicate type of User?
  id: string,
  email: string,
  role: Role,
  jwt: string,
  expiresAt: string
}
