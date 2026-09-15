import { Role } from "../role.model"

export type LoginResponse = {
  id: string,
  email: string,
  role: Role,
  jwt: string,
  expiresAt: number
}
